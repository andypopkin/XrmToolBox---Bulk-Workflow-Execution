﻿namespace XrmToolBox___Bulk_Workflow_Execution
{
    partial class BulkWorkflowExecution
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.workflowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExecuteWF = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.cmbWorkflows = new System.Windows.Forms.ComboBox();
            this.radViews = new System.Windows.Forms.RadioButton();
            this.radFetchXML = new System.Windows.Forms.RadioButton();
            this.rtxtFetchXML = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecordCount = new System.Windows.Forms.TextBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstViews = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnFXB = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.toolStripSplitButton1,
            this.toolStripSeparator2,
            this.tsbtnCount,
            this.toolStripSeparator3,
            this.tsbExecuteWF,
            this.tsbCancel,
            this.toolStripSeparator4,
            this.tsbHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClose.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.Close_Button;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(24, 24);
            this.tsbtnClose.Text = "Close";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workflowsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.refresh16;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(82, 24);
            this.toolStripSplitButton1.Text = "Refresh";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // workflowsToolStripMenuItem
            // 
            this.workflowsToolStripMenuItem.Name = "workflowsToolStripMenuItem";
            this.workflowsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.workflowsToolStripMenuItem.Text = "Workflows";
            this.workflowsToolStripMenuItem.Click += new System.EventHandler(this.workflowsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.viewToolStripMenuItem.Text = "Views";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnCount
            // 
            this.tsbtnCount.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.Count_Button;
            this.tsbtnCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCount.Name = "tsbtnCount";
            this.tsbtnCount.Size = new System.Drawing.Size(107, 24);
            this.tsbtnCount.Text = "Validate Query";
            this.tsbtnCount.Click += new System.EventHandler(this.tsbtnCount_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbExecuteWF
            // 
            this.tsbExecuteWF.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.Start_Workflows_Button;
            this.tsbExecuteWF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecuteWF.Name = "tsbExecuteWF";
            this.tsbExecuteWF.Size = new System.Drawing.Size(114, 24);
            this.tsbExecuteWF.Text = "Start Workflows";
            this.tsbExecuteWF.Click += new System.EventHandler(this.tsbExecuteWF_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.stop;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(24, 24);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbHelp
            // 
            this.tsbHelp.Image = global::XrmToolBox___Bulk_Workflow_Execution.Properties.Resources.Help_Button;
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(56, 24);
            this.tsbHelp.Text = "Help";
            this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
            // 
            // cmbWorkflows
            // 
            this.cmbWorkflows.FormattingEnabled = true;
            this.cmbWorkflows.Location = new System.Drawing.Point(14, 43);
            this.cmbWorkflows.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWorkflows.Name = "cmbWorkflows";
            this.cmbWorkflows.Size = new System.Drawing.Size(247, 21);
            this.cmbWorkflows.TabIndex = 0;
            this.cmbWorkflows.SelectedIndexChanged += new System.EventHandler(this.cmbWorkflows_SelectedIndexChanged);
            // 
            // radViews
            // 
            this.radViews.AutoSize = true;
            this.radViews.Checked = true;
            this.radViews.Location = new System.Drawing.Point(14, 58);
            this.radViews.Margin = new System.Windows.Forms.Padding(2);
            this.radViews.Name = "radViews";
            this.radViews.Size = new System.Drawing.Size(180, 17);
            this.radViews.TabIndex = 1;
            this.radViews.TabStop = true;
            this.radViews.Text = "Use CRM View FetchXML Query";
            this.radViews.UseVisualStyleBackColor = true;
            this.radViews.CheckedChanged += new System.EventHandler(this.radViews_CheckedChanged);
            // 
            // radFetchXML
            // 
            this.radFetchXML.AutoSize = true;
            this.radFetchXML.Location = new System.Drawing.Point(14, 36);
            this.radFetchXML.Margin = new System.Windows.Forms.Padding(2);
            this.radFetchXML.Name = "radFetchXML";
            this.radFetchXML.Size = new System.Drawing.Size(165, 17);
            this.radFetchXML.TabIndex = 2;
            this.radFetchXML.TabStop = true;
            this.radFetchXML.Text = "Use Custom FetchXML Query";
            this.radFetchXML.UseVisualStyleBackColor = true;
            this.radFetchXML.CheckedChanged += new System.EventHandler(this.radFetchXML_CheckedChanged);
            // 
            // rtxtFetchXML
            // 
            this.rtxtFetchXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtFetchXML.Location = new System.Drawing.Point(4, 51);
            this.rtxtFetchXML.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtFetchXML.Name = "rtxtFetchXML";
            this.rtxtFetchXML.Size = new System.Drawing.Size(414, 397);
            this.rtxtFetchXML.TabIndex = 0;
            this.rtxtFetchXML.Text = "";
            this.rtxtFetchXML.TextChanged += new System.EventHandler(this.rtxtFetchXML_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 49);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(152, 19);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Record Count:";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.Location = new System.Drawing.Point(92, 24);
            this.txtRecordCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.ReadOnly = true;
            this.txtRecordCount.Size = new System.Drawing.Size(76, 20);
            this.txtRecordCount.TabIndex = 2;
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Location = new System.Drawing.Point(257, 24);
            this.txtBatchSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(43, 20);
            this.txtBatchSize.TabIndex = 4;
            this.txtBatchSize.TextChanged += new System.EventHandler(this.txtBatchSize_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Batch Size:";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(257, 51);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(43, 20);
            this.txtInterval.TabIndex = 6;
            this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Interval Delay:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select an On-Demand Workflow:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "(0-1000)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select a Source Type:";
            // 
            // lstViews
            // 
            this.lstViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstViews.FormattingEnabled = true;
            this.lstViews.Location = new System.Drawing.Point(24, 80);
            this.lstViews.Margin = new System.Windows.Forms.Padding(2);
            this.lstViews.Name = "lstViews";
            this.lstViews.Size = new System.Drawing.Size(236, 368);
            this.lstViews.TabIndex = 7;
            this.lstViews.SelectedIndexChanged += new System.EventHandler(this.lstViews_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbWorkflows);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(2, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(272, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Workflow";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lstViews);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.radViews);
            this.groupBox2.Controls.Add(this.radFetchXML);
            this.groupBox2.Location = new System.Drawing.Point(2, 110);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(272, 460);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtRecordCount);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.txtInterval);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBatchSize);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(279, 27);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(422, 81);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnFXB);
            this.groupBox4.Controls.Add(this.rtxtFetchXML);
            this.groupBox4.Location = new System.Drawing.Point(279, 110);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(422, 460);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FetchXML Query";
            // 
            // btnFXB
            // 
            this.btnFXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFXB.Location = new System.Drawing.Point(226, 20);
            this.btnFXB.Name = "btnFXB";
            this.btnFXB.Size = new System.Drawing.Size(191, 23);
            this.btnFXB.TabIndex = 1;
            this.btnFXB.Text = "Compose with FetchXML Builder";
            this.btnFXB.UseVisualStyleBackColor = true;
            this.btnFXB.Visible = false;
            this.btnFXB.Click += new System.EventHandler(this.btnFXB_Click);
            // 
            // BulkWorkflowExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BulkWorkflowExecution";
            this.Size = new System.Drawing.Size(716, 590);
            this.Load += new System.EventHandler(this.BulkWorkflowExecution_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem workflowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExecuteWF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.RadioButton radFetchXML;
        private System.Windows.Forms.RadioButton radViews;
        private System.Windows.Forms.ComboBox cmbWorkflows;
        private System.Windows.Forms.RichTextBox rtxtFetchXML;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecordCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstViews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.Button btnFXB;
    }
}
