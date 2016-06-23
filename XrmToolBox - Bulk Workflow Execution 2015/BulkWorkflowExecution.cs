using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox___Bulk_Workflow_Execution
{
    public partial class BulkWorkflowExecution : PluginControlBase, IGitHubPlugin, ICodePlexPlugin, IPayPalPlugin, IHelpPlugin, IMessageBusHost
    {
        // BUGS
        /*
          1. (FIXED) When Clicking the View area but not selecting anything
          2. (FIXED) Running the same workflow twice seems to not update the progress bar
          3. (FIXED) refreshing does not clear the progress bar
        */

        // Enhancements
        /*
           4. Finished Dialog/Message Box 
         * 1. Show Error Count somewhere (in finish dialog)
            2. Fix the Text on Progress Bar or show it elsewhere
            3. Estimated Time Remaining / Batches per Min / same stats as bulk delete system jobs cleanup tool
            
            5. Cancel/Stop button, and make it the only button that you can press when WF is running. add text to the help about stop
        */

        #region Custom Variables

        // Andy Popkin's Variables
        public EntityCollection _workflows = new EntityCollection();
        public EntityCollection _views = new EntityCollection();
        public EntityCollection ExecutionRecordSet = new EntityCollection();
        public Entity _selectedWorkflow;
        public Entity _selectedView;
        public Guid _defaultGuid = new Guid();

        public int emrCount = 0;
        public int errorCount = 0;
        public int emrBatchSize = 200;
        public ExecuteMultipleRequest requestWithResults;
        public bool boolStopProcessing = false;

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        #endregion Custom Variables

        public BulkWorkflowExecution()
        {
            InitializeComponent();            
        }

        private void BulkWorkflowExecution_Load(object sender, System.EventArgs e)
        {
            ExecuteMethod(getWorkflows);

            UIStatusUpdated("Initial Load");
        }

        #region Tool Strip Button Methods

        private void tsbtnClose_Click(object sender, System.EventArgs e)
        {
            CloseTool();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            ExecuteMethod(getWorkflows);
            UIStatusUpdated("Initial Load");
        }

        private void workflowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteMethod(getWorkflows);
            UIStatusUpdated("Initial Load");
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteMethod(getViews);
            UIStatusUpdated("Initial Load");
        }

        private void tsbtnCount_Click(object sender, EventArgs e)
        {
            string txtFetch = "";

            this.Invoke((MethodInvoker)delegate()
            {
                txtFetch = rtxtFetchXML.Text;
            });

            if (txtFetch != null && txtFetch != "") { ExecuteMethod(getRecordCount); }
            else { MessageBox.Show("Please Enter a FetchXML Query", "Bulk Workflow Execution"); }
        }

        private void tsbExecuteWF_Click(object sender, EventArgs e)
        {
            UIStatusUpdated("Running Workflows");
            ExecuteMethod(startWorkflows);
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                rtxtFetchXML.Clear();
                rtxtFetchXML.AppendText("INSTRUCTIONS");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("-------------------");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("1. Click the Refresh Button.");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("2. Select an On-Demand Workflow (Your workflow MUST be set as On-Demand).");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("3. Select an existing view, customize an existing view, or create a fully custom view.");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("4. Click 'Validate Query' to validate the FetchXML Query and get a record count.");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("5. If no errors - click 'Start Workflows', sit back, relax, and enjoy!");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("INFORMATION");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("------------------");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("Batch Size: # of Workflows to Start per Batch (CRM Web Service Call). 200 is recommended.");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("Interval Delay: # of Seconds between Batches being sent to CRM");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("STOP Button will stop processing, but only after it finishes processing the current batch.");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("CONTACT");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("--------------");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("Email: andrewopopkin@gmail.com");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("Twitter: @andypopkin");
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText(Environment.NewLine);
                rtxtFetchXML.AppendText("** Please contact me if you have any issues or ideas for this tool or other XrmToolBox based tools. Thank you for using this tool! If you really enjoy, click the Donate > Bulk Workflow Tool button :) **");
            });

            UIStatusUpdated("Help");
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            //FlushEMR((BackgroundWorker)sender);
            //e.Cancel = true;
            //MessageBox.Show("Please click 'Validate Query' before Executing Workflows or ensure your Query is valid & returning records.");
            //return;
            boolStopProcessing = true;
        }

        #endregion Tool Strip Button Methods

        #region Form Control Methods

        private void radViews_CheckedChanged(object sender, System.EventArgs e)
        {
            //viewsTypeRadioChanged();
            UIStatusUpdated("Query Ready");
            btnFXB.Visible = radFetchXML.Checked;
        }

        private void radFetchXML_CheckedChanged(object sender, System.EventArgs e)
        {
            //viewsTypeRadioChanged();
            UIStatusUpdated("Query Ready");
            btnFXB.Visible = radFetchXML.Checked;
        }

        private void cmbWorkflows_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteMethod(getViews);
        }

        private void lstViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFetchXMLfromView();
            //viewsTypeRadioChanged();
            UIStatusUpdated();
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool intervalIsNumeric = int.TryParse(txtInterval.Text, out n);

            if (!intervalIsNumeric) { MessageBox.Show("Please enter a number value into Interval Delay to represent the length of time desired between execution of batches.", "Bulk Workflow Execution"); }
        }

        private void txtBatchSize_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool batchIsNumeric = int.TryParse(txtBatchSize.Text, out n);

            if (!batchIsNumeric && n <= 1000) { MessageBox.Show("Please enter a number value (0-1000) into Batch Size to represent the amount of workflows in each batch execution.", "Bulk Workflow Execution"); }
        }

        private void rtxtFetchXML_TextChanged(object sender, EventArgs e)
        {
            ExecutionRecordSet.Entities.Clear();
                           
            txtRecordCount.Clear();            

            UIStatusUpdated("Query Ready");
        }

        private void btnFXB_Click(object sender, EventArgs e)
        {
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder")
            {
                TargetArgument = rtxtFetchXML.Text
            };
            try
            {
                OnOutgoingMessage(this, messageBusEventArgs);
            }
            catch (PluginNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Form Control Methods

        #region Bulk WF Tool Methods

        private void getWorkflows()
        {
            WorkAsync("Retrieving Workflows...", (w, e) =>
            {
                #region Reset Variables

                ExecutionRecordSet.Entities.Clear();
                _workflows.Entities.Clear();
                _selectedWorkflow = null;
                _views.Entities.Clear();
                // TODO - Allow Selection of Multiple Views?
                _selectedView = null;

                this.Invoke((MethodInvoker)delegate()
                {
                    cmbWorkflows.Items.Clear();
                    lstViews.Items.Clear();
                    txtRecordCount.Clear();
                    rtxtFetchXML.Clear();
                    tsbtnCount.Enabled = false;
                    radFetchXML.Checked = false;
                    radViews.Checked = true;
                    //progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.Value = 0;
                    txtBatchSize.Text = "200";
                    emrBatchSize = 200;
                    txtInterval.Text = "0";
                });

                #endregion Reset Variables

                #region Get Workflows Query

                QueryExpression query = new QueryExpression("workflow");
                query.ColumnSet.AddColumns("workflowid", "name", "primaryentity");
                query.Distinct = true;
                query.AddOrder("name", OrderType.Ascending);
                query.Criteria = new FilterExpression();
                //query.Criteria.AddCondition("category", ConditionOperator.Equal, 0);

                FilterExpression childFilter = query.Criteria.AddFilter(LogicalOperator.And);
                childFilter.AddCondition("category", ConditionOperator.Equal, 0);
                childFilter.AddCondition("activeworkflowid", ConditionOperator.NotNull);
                childFilter.AddCondition("ondemand", ConditionOperator.Equal, true);
                
                e.Result = Service.RetrieveMultiple(query);

                #endregion Get Workflows Query
            },
                e =>
                {
                    _workflows = (EntityCollection)e.Result;

                    if (_workflows.Entities.Count > 0)
                    {
                        foreach (var item in _workflows.Entities)
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                cmbWorkflows.Items.Add(item["name"]);
                            });
                        }
                    }

                    this.Invoke((MethodInvoker)delegate()
                    {
                        cmbWorkflows.Text = "Select a Workflow to run";
                        lstViews.Text = "Select a Workflow to populate this list";
                        //progressBar1.Style = ProgressBarStyle.Continuous;
                    });
                },
                e =>
                {
                    // If progress has to be notified to user, use the following method:
                    //SetWorkingMessage("Message to display");                    
                },
                null,//"Retrieving your user id...",
                340,
                150);            
        }

        private void getViews()
        {
            WorkAsync("Retrieving Views for Selected Workflow Entity", (w, e) =>
            {
                #region Reset View Stuff
                int selectedWorkflowIndex = -1;
                ExecutionRecordSet.Entities.Clear();
                Guid WorkflowId = Guid.Empty;
                _views.Entities.Clear();
                _selectedView = null;
                this.Invoke((MethodInvoker)delegate()
                {
                    lstViews.Items.Clear();
                    rtxtFetchXML.Clear();
                    tsbtnCount.Enabled = false;
                    radViews.Checked = true;
                    radFetchXML.Checked = false;
                    txtRecordCount.Clear();
                    //progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.Value = 0;
                    selectedWorkflowIndex = cmbWorkflows.SelectedIndex;
                });
                #endregion Reset View Stuff

                if (cmbWorkflows.Text == "Select a Workflow to run")
                {
                    e.Cancel = true;
                    MessageBox.Show("Please select a Workflow before refreshing the Views.", "Bulk Workflow Execution");                    
                    return;
                }

                _selectedWorkflow = _workflows[selectedWorkflowIndex];

                #region System Views Loop

                QueryExpression query = new QueryExpression("savedquery");
                query.ColumnSet.AllColumns = true;
                query.AddOrder("name", OrderType.Ascending);
                query.Criteria = new FilterExpression();
                //query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, workflowEntity);

                FilterExpression childFilter = query.Criteria.AddFilter(LogicalOperator.And);
                childFilter.AddCondition("querytype", ConditionOperator.Equal, 0);
                childFilter.AddCondition("returnedtypecode", ConditionOperator.Equal, _selectedWorkflow["primaryentity"]);
                childFilter.AddCondition("statecode", ConditionOperator.Equal, 0);
                childFilter.AddCondition("fetchxml", ConditionOperator.NotNull);

                EntityCollection _ManagedViews = Service.RetrieveMultiple(query);
                _views.Entities.AddRange(_ManagedViews.Entities);

                foreach (var item in _ManagedViews.Entities)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        lstViews.Items.Add(item["name"]);
                    });
                }
                #endregion System Views Loop

                #region Personal View Divider
                
                this.Invoke((MethodInvoker)delegate()
                {
                    lstViews.Items.Add("------------------ Personal Views -----------------------");
                });
                Entity _dummyView = new Entity("userquery");
                _dummyView.Id = _defaultGuid;
                _dummyView["name"] = "Dummy View";

                _views.Entities.Add(_dummyView);

                #endregion Personal View Divider

                #region Personal Views Loop
                QueryExpression query2 = new QueryExpression("userquery");
                query2.ColumnSet.AllColumns = true;
                query.AddOrder("name", OrderType.Ascending);
                query2.Criteria = new FilterExpression();
                //query.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, true);

                FilterExpression childFilter2 = query2.Criteria.AddFilter(LogicalOperator.And);
                childFilter2.AddCondition("querytype", ConditionOperator.Equal, 0);
                childFilter2.AddCondition("returnedtypecode", ConditionOperator.Equal, _selectedWorkflow["primaryentity"]);
                childFilter2.AddCondition("statecode", ConditionOperator.Equal, 0);
                childFilter2.AddCondition("fetchxml", ConditionOperator.NotNull);

                EntityCollection _UserViews = Service.RetrieveMultiple(query2);
                _views.Entities.AddRange(_UserViews.Entities);

                foreach (var item in _UserViews.Entities)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        lstViews.Items.Add(item["name"]);
                    });                    
                }
                #endregion Personal Views Loop
                
            },
                e =>
                {
                    //MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                },
                e =>
                {
                    // If progress has to be notified to user, use the following method:
                    //SetWorkingMessage("Message to display");
                },
                null,//"Retrieving your user id...",
                340,
                150);
        }

        private void updateFetchXMLfromView()
        {
            int _selectedViewIndex = 0;
            ExecutionRecordSet.Entities.Clear();

            string _fetchXML = "";

            this.Invoke((MethodInvoker)delegate()
            {
                _selectedViewIndex = lstViews.SelectedIndex;
                txtRecordCount.Clear();
            });

            if (_selectedViewIndex == -1) { return; }
            
            _fetchXML = (String)_views[_selectedViewIndex]["fetchxml"];
            
            XDocument XDocument = XDocument.Parse(_fetchXML);            

            this.Invoke((MethodInvoker)delegate()
            {
                rtxtFetchXML.Text = XDocument.ToString();
            });            
        }

        private void getRecordCount()
        {
            WorkAsync("Counting Records in View..", (w, e) => // Work To Do Asynchronously
            {
                UIStatusUpdated("Validating"); 
                progressBar1.Value = 0;                
                ExecutionRecordSet.Entities.Clear();
                boolStopProcessing = false;

                string fetchXml = rtxtFetchXML.Text;

                var conversionRequest = new FetchXmlToQueryExpressionRequest
                {
                    FetchXml = fetchXml
                };

                FetchXmlToQueryExpressionResponse conversionResponse;
                try
                {
                    conversionResponse = (FetchXmlToQueryExpressionResponse)Service.Execute(conversionRequest);
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message.ToString(), "Bulk Workflow Execution");
                    throw;
                }

                QueryExpression query1 = conversionResponse.Query;
                query1.ColumnSet.Columns.Clear();
                query1.PageInfo = new PagingInfo();
                query1.PageInfo.PageNumber = 1;
                query1.PageInfo.PagingCookie = null;
                query1.PageInfo.Count = 5000;

                while (true)
                {
                    if (boolStopProcessing)
                    {
                        e.Cancel = true;
                        //MessageBox.Show("Processing Stopped", "Bulk Workflow Execution");
                        //tsbCancel.Enabled = false;
                        boolStopProcessing = false;
                        //toolStripSplitButton1.Enabled = true;
                        ExecutionRecordSet.Entities.Clear();
                        //UIStatusUpdated("Query Ready");
                        break;
                    }
                    EntityCollection results = Service.RetrieveMultiple(query1);

                    ExecutionRecordSet.Entities.AddRange(results.Entities);
                    
                                        
                    if (results.MoreRecords)
                    {                        
                        query1.PageInfo.PageNumber++;
                        query1.PageInfo.PagingCookie = results.PagingCookie;
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            txtRecordCount.Text = "0";
                        });
                        break;
                    }

                    w.ReportProgress(0, string.Format("Counting Records in View...({0})", ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture)));
                }

                this.Invoke((MethodInvoker)delegate()
                {
                    txtRecordCount.Text = ExecutionRecordSet.Entities.Count == 0 ? "0" : ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture);
                    if (ExecutionRecordSet.Entities.Count == 0)
                    { 
                        UIStatusUpdated("Query Ready"); 
                    }
                    else 
                    { 
                        UIStatusUpdated("Ready"); 
                    }
                });
            },
            e => // Finished Async Call.  Cleanup
            {
                // Handle e.Result
            },
            e => // Logic wants to display an update.  This gets called when ReportProgress Gets Called
            {
                SetWorkingMessage(e.UserState.ToString());
            });
        }

        private void startWorkflows()
        {
            emrCount = 0;
            errorCount = 0;
            boolStopProcessing = false;

            this.Invoke((MethodInvoker)delegate()
            {
                progressBar1.Value = 0;
                tsbtnCount.Enabled = false;
                tsbExecuteWF.Enabled = false;
                tsbCancel.Enabled = true;
                toolStripSplitButton1.Enabled = false;
            });
            
            WorkAsync(string.Format("Starting {0} Workflows...",ExecutionRecordSet.Entities.Count),
                (w, e) => // Work To Do Asynchronously
                {
                    if (ExecutionRecordSet.Entities.Count <= 0 || _selectedWorkflow == null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please click 'Validate Query' before Executing Workflows or ensure your Query is valid, returning records, and a Workflow is selected.", "Bulk Workflow Execution");
                        return;
                    }

                    #region Bulk Data API Stuff
                    // Create an ExecuteMultipleRequest object.
                    requestWithResults = new ExecuteMultipleRequest()
                    {
                        // Assign settings that define execution behavior: continue on error, return responses. 
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = true,
                            ReturnResponses = false
                        },
                        // Create an empty organization request collection.
                        Requests = new OrganizationRequestCollection()
                    };
                    #endregion Bulk Data API Stuff

                    emrBatchSize = txtBatchSize.Text != "" ? Convert.ToInt32(txtBatchSize.Text) : 200;

                    // TODO - single execution or batch execution based on batch size?
                    
                    foreach (var item in ExecutionRecordSet.Entities)
                    {
                        if (!boolStopProcessing)
                        {
                            ExecuteWorkflowRequest _execWF = new ExecuteWorkflowRequest
                            {
                                WorkflowId = _selectedWorkflow.Id,
                                EntityId = item.Id
                            };
                            RunEMR(_execWF, ((BackgroundWorker)w));
                        }
                        else
                        {
                            e.Cancel = true;
                            boolStopProcessing = false;
                            ExecutionRecordSet.Entities.Clear();

                            MessageBox.Show("Processing Stopped" + Environment.NewLine + Environment.NewLine
                                + string.Format("Workflows Started: {0} of {1}", emrCount.ToString("#,#", CultureInfo.InvariantCulture), ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture))
                                + Environment.NewLine + "Errors: " + errorCount
                                , "Bulk Workflow Execution");
                            
                            UIStatusUpdated("Complete");                            
                            return;
                        }                            
                    }
                    FlushEMR((BackgroundWorker)w);
                    // TODO - are these right? also need to make sure after stop button is clicked the buttons reset properly
                    UIStatusUpdated("Complete");

                    //w.ReportProgress(50, "Doing Something Else");
                    //Do something else

                    // Populate whatever the results that need to be returned to the Results Property
                    //e.Result = new object();
                    //w.ReportProgress(99, "Finishing");
                },
                e => // Finished Async Call.  Cleanup
                {
                    // Handle e.Result
                },
                e => // Logic wants to display an update.  This gets called when ReportProgress Gets Called
                {
                    // does this do anything? seems to just set the message
                    SetWorkingMessage(e.UserState.ToString());
                }
            );
        }

        private void RunEMR(OrganizationRequest or, BackgroundWorker w)
        {
            requestWithResults.Requests.Add(or);
            emrCount++;
            if (requestWithResults.Requests.Count >= emrBatchSize)
            {
                w.ReportProgress(0, string.Format("Starting Workflows: {0} of {1}", emrCount.ToString("#,#", CultureInfo.InvariantCulture)
                    , ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture)));
                this.Invoke((MethodInvoker)delegate()
                {
                    progressBar1.Maximum = ExecutionRecordSet.Entities.Count;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = emrCount;
                    progressBar1.Refresh();
                    // TODO - text on the progress bar

                    int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(string.Format(percent.ToString() + "% - {0}/{1}",emrCount,ExecutionRecordSet.Entities.Count),
                            SystemFonts.DefaultFont,
                            Brushes.Black,
                            new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.DefaultFont).Width / 2.0F),
                            progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.DefaultFont).Height / 2.0F)));
                    }
                });

                ExecuteMultipleResponse emrsp = (ExecuteMultipleResponse)Service.Execute(requestWithResults);
                HandleErrors(emrsp);

                requestWithResults.Requests.Clear();

                if (txtInterval.Text != "0" && !string.IsNullOrWhiteSpace(txtInterval.Text))
                {
                    System.Threading.Thread.Sleep(Convert.ToInt16(txtInterval.Text) * 1000);
                }
            }
        }

        private void FlushEMR(BackgroundWorker w)
        {
            if (emrCount > 0)
            {                
                ExecuteMultipleResponse emrsp = (ExecuteMultipleResponse)Service.Execute(requestWithResults);
                HandleErrors(emrsp);
                requestWithResults.Requests.Clear();                

                this.Invoke((MethodInvoker)delegate()
                {
                    progressBar1.Maximum = ExecutionRecordSet.Entities.Count;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = emrCount;
                    progressBar1.Refresh();
                    

                    // TODO - text on the progress bar #2
                    int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(string.Format(percent.ToString() + "% - {0}/{1} - Errors: {2}", emrCount, ExecutionRecordSet.Entities.Count, errorCount),
                            SystemFonts.DefaultFont,
                            Brushes.Black,
                            new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.DefaultFont).Width / 2.0F),
                            progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.DefaultFont).Height / 2.0F)));
                    }
                });

                w.ReportProgress(0, string.Format("Starting Workflows: {0} of {1}", emrCount.ToString("#,#", CultureInfo.InvariantCulture)
                    , ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture)));
                
                // TODO - finished dialog
                tsbCancel.Enabled = false;

                MessageBox.Show("Finished @ " + DateTime.Now.ToShortTimeString() + Environment.NewLine + Environment.NewLine
                    + string.Format("Workflows Started: {0} of {1}", emrCount.ToString("#,#", CultureInfo.InvariantCulture), ExecutionRecordSet.Entities.Count.ToString("#,#", CultureInfo.InvariantCulture))
                    + Environment.NewLine + "Errors: " + errorCount
                    ,"Bulk Workflow Execution");
                //Console.Beep();
                return;
            }
            else
            {
                MessageBox.Show("No records found in this view to process", "Bulk Workflow Execution");
                return;
            }
        }

        private void HandleErrors(ExecuteMultipleResponse emrsp)
        {
            bool beep = true;
            foreach (var response in emrsp.Responses)
            {
                if (response.Fault != null)
                {
                    if (beep)
                    {
                        //Console.Beep();
                        beep = false;
                    }
                    errorCount++;
                    //writeit("(" + (emrCount - emrBatchSize) + response.RequestIndex + ")EMR Error: " + response.RequestIndex + ": " + response.Fault.Message);
                }
            }
        }

        private void UIStatusUpdated(string status = "")
        {
            switch (status)
            {
                case "Initial Load":
                    toolStripSplitButton1.Enabled = true;
                    tsbtnCount.Enabled = false;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbHelp.Enabled = true;

                    cmbWorkflows.Enabled = true;
                    radFetchXML.Enabled = true;
                    radViews.Enabled = true;
                    txtBatchSize.Enabled = true;
                    txtInterval.Enabled = true; 
                    break;
                case "Query Ready":
                    toolStripSplitButton1.Enabled = true;
                    tsbtnCount.Enabled = true;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbHelp.Enabled = true;  
                  
                    cmbWorkflows.Enabled = true;
                    radFetchXML.Enabled = true;
                    radViews.Enabled = true;
                    txtBatchSize.Enabled = true;
                    txtInterval.Enabled = true; 
                    break;
                case "Validating":
                    // TODO: lock everything while counting
                    toolStripSplitButton1.Enabled = false;
                    tsbtnCount.Enabled = false;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = true;
                    tsbHelp.Enabled = false;   

                    cmbWorkflows.Enabled = false;
                    lstViews.Enabled = false;
                    radFetchXML.Enabled = false;
                    radViews.Enabled = false;
                    rtxtFetchXML.Enabled = false;
                    txtBatchSize.Enabled = false;
                    txtInterval.Enabled = false; 
                    break;
                case "Ready":
                    // TODO - check to ensure all is correct before allowing to run workflows
                    toolStripSplitButton1.Enabled = true;
                    tsbtnCount.Enabled = true;
                    if (cmbWorkflows.Text != "Select a Workflow to run")
                    {
                        tsbExecuteWF.Enabled = true;
                    }                    
                    tsbCancel.Enabled = false;
                    tsbHelp.Enabled = true;

                    cmbWorkflows.Enabled = true;
                    radFetchXML.Enabled = true;
                    radViews.Enabled = true;
                    txtBatchSize.Enabled = true;
                    txtInterval.Enabled = true; 
                    break;
                case "Running Workflows":
                    toolStripSplitButton1.Enabled = false;
                    tsbtnCount.Enabled = false;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = true;
                    tsbHelp.Enabled = false;   

                    cmbWorkflows.Enabled = false;
                    lstViews.Enabled = false;
                    radFetchXML.Enabled = false;
                    radViews.Enabled = false;
                    rtxtFetchXML.Enabled = false;
                    txtBatchSize.Enabled = false;
                    txtInterval.Enabled = false;                    
                    break;
                case "Complete":
                    // TODO - what needs to be disabled after completion?
                    toolStripSplitButton1.Enabled = true;
                    tsbtnCount.Enabled = false;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbHelp.Enabled = true;

                    cmbWorkflows.Enabled = true;
                    radFetchXML.Enabled = true;
                    radViews.Enabled = true;
                    txtBatchSize.Enabled = true;
                    txtInterval.Enabled = true;  
                    break;
                case "Help":
                    toolStripSplitButton1.Enabled = true;
                    tsbtnCount.Enabled = false;
                    tsbExecuteWF.Enabled = false;
                    tsbCancel.Enabled = false;
                    tsbHelp.Enabled = true;

                    cmbWorkflows.Enabled = true;
                    lstViews.Enabled = true;
                    lstViews.ClearSelected();
                    radFetchXML.Enabled = true;
                    radViews.Enabled = true;
                    rtxtFetchXML.Enabled = false;
                    txtBatchSize.Enabled = true;
                    txtInterval.Enabled = true;
                    break;
                default:
                    break;
            }

            if (status != "Running Workflows" && status != "Validating" && status != "Help")
            {
                bool boolViewsFetch = radViews.Checked;

                lstViews.Enabled = boolViewsFetch;
                rtxtFetchXML.Enabled = !boolViewsFetch;
            }            
        }

        #endregion Bulk WF Tool Methods

        #region XrmToolBox Methods

        #region Who Am I Sample

        public void ProcessWhoAmI()
        {
            WorkAsync(null, (w, e) =>
            {
                var request = new WhoAmIRequest();
                var response = (WhoAmIResponse)Service.Execute(request);

                e.Result = response.UserId;
            },
                e =>
                {
                    MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                },
                e =>
                {
                    // If progress has to be notified to user, use the following method:
                    //SetWorkingMessage("Message to display");
                },
                "Retrieving your user id...",
                340,
                150);
        }

        private void BtnWhoAmIClick(object sender, EventArgs e)
        {
            ExecuteMethod(ProcessWhoAmI);
        }

        #endregion Who Am I Sample

        #region Github implementation
        // TODO - GitHub
        public string RepositoryName
        {
            get { return "GithubRepositoryName"; }
        }

        public string UserName
        {
            get { return "GithubUserName"; }
        }

        #endregion Github implementation

        #region CodePlex implementation
        // TODO - CodePlex
        public string CodePlexUrlName
        {
            get { return "CodePlex"; }
        }

        #endregion CodePlex implementation

        #region PayPal implementation

        public string DonationDescription
        {
            get { return "Donate to inspire Andy to build more XrmToolBox tools!"; }
        }

        public string EmailAccount
        {
            get { return "fromasta@gmail.com"; }
        }

        #endregion PayPal implementation

        #region Help implementation
        // TODO - Help
        public string HelpUrl
        {
            get { return "http://www.google.com"; }
        }

        #endregion Help implementation

        #region MessageBus implementation

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder" &&
                message.TargetArgument is string)
            {
                rtxtFetchXML.Text = (string)message.TargetArgument;
            }
        }
        
        #endregion MessageBus implementation

        #endregion XrmToolBox Methods
    }


}
