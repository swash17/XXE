namespace XXE_UserInterface
{
    partial class frmLinkData
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLinkData = new System.Windows.Forms.DataGridView();
            this.tipLinkData = new System.Windows.Forms.ToolTip(this.components);
            this.tsLinkData = new System.Windows.Forms.ToolStrip();
            this.tsbSaveLinkData = new System.Windows.Forms.ToolStripButton();
            this.tsbDiscardLinkDataChanges = new System.Windows.Forms.ToolStripButton();
            this.tsbAddLink = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertLink = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteLink = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadLinkData = new System.Windows.Forms.ToolStripButton();
            this.tsbCopyLinkData = new System.Windows.Forms.ToolStripButton();
            this.tsbPasteLinkData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsFirstNode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsTotNodes = new System.Windows.Forms.ToolStripTextBox();
            this.FromNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FFS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FFTravTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintTimePerData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddTimePerData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EditTimePerData = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPhysicalLink = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFreewayFacilities = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCheckBoundaries = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkData)).BeginInit();
            this.tsLinkData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLinkData
            // 
            this.dgvLinkData.AllowUserToAddRows = false;
            this.dgvLinkData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.dgvLinkData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLinkData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinkData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLinkData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinkData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FromNode,
            this.ToNode,
            this.Capacity,
            this.Length,
            this.FFS,
            this.FFTravTime,
            this.Descrip,
            this.PrintTimePerData,
            this.AddTimePerData,
            this.EditTimePerData,
            this.colPhysicalLink,
            this.colFreewayFacilities,
            this.colCheckBoundaries});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLinkData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLinkData.Location = new System.Drawing.Point(12, 44);
            this.dgvLinkData.Name = "dgvLinkData";
            this.dgvLinkData.RowHeadersWidth = 55;
            this.dgvLinkData.Size = new System.Drawing.Size(861, 467);
            this.dgvLinkData.TabIndex = 0;
            this.dgvLinkData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinkData_CellContentClick);
            this.dgvLinkData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinkData_CellValidated);
            this.dgvLinkData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLinkData_CellValidating);
            this.dgvLinkData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinkData_CellValueChanged);
            this.dgvLinkData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLinkData_RowPostPaint);
            // 
            // tipLinkData
            // 
            this.tipLinkData.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tsLinkData
            // 
            this.tsLinkData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveLinkData,
            this.tsbDiscardLinkDataChanges,
            this.tsbAddLink,
            this.tsbInsertLink,
            this.tsbDeleteLink,
            this.tsbLoadLinkData,
            this.tsbCopyLinkData,
            this.tsbPasteLinkData,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsFirstNode,
            this.toolStripLabel2,
            this.tsTotNodes});
            this.tsLinkData.Location = new System.Drawing.Point(0, 0);
            this.tsLinkData.Name = "tsLinkData";
            this.tsLinkData.Size = new System.Drawing.Size(885, 25);
            this.tsLinkData.TabIndex = 0;
            this.tsLinkData.Text = "toolStrip1";
            // 
            // tsbSaveLinkData
            // 
            this.tsbSaveLinkData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveLinkData.Image = global::XXE_UserInterface.Properties.Resources.Save;
            this.tsbSaveLinkData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveLinkData.Name = "tsbSaveLinkData";
            this.tsbSaveLinkData.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveLinkData.ToolTipText = "Save Data";
            this.tsbSaveLinkData.Click += new System.EventHandler(this.tsbSaveLinkData_Click);
            // 
            // tsbDiscardLinkDataChanges
            // 
            this.tsbDiscardLinkDataChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDiscardLinkDataChanges.Image = global::XXE_UserInterface.Properties.Resources.DeleteTable;
            this.tsbDiscardLinkDataChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscardLinkDataChanges.Name = "tsbDiscardLinkDataChanges";
            this.tsbDiscardLinkDataChanges.Size = new System.Drawing.Size(23, 22);
            this.tsbDiscardLinkDataChanges.ToolTipText = "Close Form without Saving Data";
            this.tsbDiscardLinkDataChanges.Click += new System.EventHandler(this.tsbDiscardLinkDataChanges_Click);
            // 
            // tsbAddLink
            // 
            this.tsbAddLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddLink.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddLink.Image")));
            this.tsbAddLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddLink.Name = "tsbAddLink";
            this.tsbAddLink.Size = new System.Drawing.Size(23, 22);
            this.tsbAddLink.ToolTipText = "Add New Row at Bottom";
            this.tsbAddLink.Click += new System.EventHandler(this.tsbAddLink_Click);
            // 
            // tsbInsertLink
            // 
            this.tsbInsertLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertLink.Image = global::XXE_UserInterface.Properties.Resources.RowInsert1;
            this.tsbInsertLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertLink.Name = "tsbInsertLink";
            this.tsbInsertLink.Size = new System.Drawing.Size(23, 22);
            this.tsbInsertLink.ToolTipText = "Insert Row at Selected Position";
            this.tsbInsertLink.Click += new System.EventHandler(this.tsbInsertLink_Click);
            // 
            // tsbDeleteLink
            // 
            this.tsbDeleteLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteLink.Image = global::XXE_UserInterface.Properties.Resources.RowDelete;
            this.tsbDeleteLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteLink.Name = "tsbDeleteLink";
            this.tsbDeleteLink.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteLink.ToolTipText = "Delete Selected Row";
            this.tsbDeleteLink.Click += new System.EventHandler(this.tsbDeleteLink_Click);
            // 
            // tsbLoadLinkData
            // 
            this.tsbLoadLinkData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadLinkData.Image = global::XXE_UserInterface.Properties.Resources.OpenFolder;
            this.tsbLoadLinkData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadLinkData.Name = "tsbLoadLinkData";
            this.tsbLoadLinkData.Size = new System.Drawing.Size(23, 22);
            this.tsbLoadLinkData.Text = "toolStripButton1";
            this.tsbLoadLinkData.ToolTipText = "Load link-node data from CSV formatted file";
            this.tsbLoadLinkData.Click += new System.EventHandler(this.tsbLoadLinkData_Click);
            // 
            // tsbCopyLinkData
            // 
            this.tsbCopyLinkData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopyLinkData.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopyLinkData.Image")));
            this.tsbCopyLinkData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopyLinkData.Name = "tsbCopyLinkData";
            this.tsbCopyLinkData.Size = new System.Drawing.Size(23, 22);
            this.tsbCopyLinkData.Text = "Copy selected data to the clipboard";
            this.tsbCopyLinkData.Click += new System.EventHandler(this.tsbCopyLinkData_Click);
            // 
            // tsbPasteLinkData
            // 
            this.tsbPasteLinkData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPasteLinkData.Image = ((System.Drawing.Image)(resources.GetObject("tsbPasteLinkData.Image")));
            this.tsbPasteLinkData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPasteLinkData.Name = "tsbPasteLinkData";
            this.tsbPasteLinkData.Size = new System.Drawing.Size(23, 22);
            this.tsbPasteLinkData.Text = "Paste data from the clipboard to the selected cells";
            this.tsbPasteLinkData.Click += new System.EventHandler(this.tsbPasteLinkData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 22);
            this.toolStripLabel1.Text = "First Physical Node";
            // 
            // tsFirstNode
            // 
            this.tsFirstNode.BackColor = System.Drawing.Color.Yellow;
            this.tsFirstNode.Name = "tsFirstNode";
            this.tsFirstNode.Size = new System.Drawing.Size(30, 25);
            this.tsFirstNode.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsFirstNode.ToolTipText = "Node number must be a postive integer";
            this.tsFirstNode.Validating += new System.ComponentModel.CancelEventHandler(this.tsFirstNode_Validating);
            this.tsFirstNode.Validated += new System.EventHandler(this.tsFirstNode_Validated);
            this.tsFirstNode.TextChanged += new System.EventHandler(this.tsFirstNode_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "Total Nodes";
            // 
            // tsTotNodes
            // 
            this.tsTotNodes.BackColor = System.Drawing.Color.Yellow;
            this.tsTotNodes.Name = "tsTotNodes";
            this.tsTotNodes.Size = new System.Drawing.Size(30, 25);
            this.tsTotNodes.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsTotNodes.ToolTipText = "Total number of nodes must be a postive integer";
            this.tsTotNodes.Validating += new System.ComponentModel.CancelEventHandler(this.tsTotNodes_Validating);
            this.tsTotNodes.Validated += new System.EventHandler(this.tsTotNodes_Validated);
            this.tsTotNodes.TextChanged += new System.EventHandler(this.tsTotNodes_TextChanged);
            // 
            // FromNode
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FromNode.DefaultCellStyle = dataGridViewCellStyle3;
            this.FromNode.HeaderText = "From Node";
            this.FromNode.MaxInputLength = 3;
            this.FromNode.MinimumWidth = 20;
            this.FromNode.Name = "FromNode";
            this.FromNode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FromNode.ToolTipText = "From Node must be a positive integer value";
            this.FromNode.Width = 60;
            // 
            // ToNode
            // 
            this.ToNode.HeaderText = "To Node";
            this.ToNode.MaxInputLength = 3;
            this.ToNode.MinimumWidth = 20;
            this.ToNode.Name = "ToNode";
            this.ToNode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToNode.ToolTipText = "To Node must be a positive integer value";
            this.ToNode.Width = 60;
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "Capacity (veh/h)";
            this.Capacity.MaxInputLength = 5;
            this.Capacity.MinimumWidth = 30;
            this.Capacity.Name = "Capacity";
            this.Capacity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Capacity.ToolTipText = "Capacity must be a positive integer value";
            this.Capacity.Width = 80;
            // 
            // Length
            // 
            this.Length.HeaderText = "Length (mi)";
            this.Length.MaxInputLength = 5;
            this.Length.MinimumWidth = 30;
            this.Length.Name = "Length";
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Length.ToolTipText = "Link Length be a numeric value";
            this.Length.Width = 80;
            // 
            // FFS
            // 
            this.FFS.HeaderText = "Free Flow Speed (mi/h)";
            this.FFS.MaxInputLength = 3;
            this.FFS.MinimumWidth = 30;
            this.FFS.Name = "FFS";
            this.FFS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FFS.ToolTipText = "Free Flow Speed must be a positive integer value";
            // 
            // FFTravTime
            // 
            this.FFTravTime.HeaderText = "Free Flow Travel Time (h)";
            this.FFTravTime.Name = "FFTravTime";
            this.FFTravTime.ReadOnly = true;
            this.FFTravTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descrip
            // 
            this.Descrip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Descrip.DefaultCellStyle = dataGridViewCellStyle4;
            this.Descrip.HeaderText = "Description";
            this.Descrip.MaxInputLength = 70;
            this.Descrip.Name = "Descrip";
            this.Descrip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descrip.ToolTipText = "Description must not be empty";
            this.Descrip.Width = 66;
            // 
            // PrintTimePerData
            // 
            this.PrintTimePerData.HeaderText = "Print Time Period Results";
            this.PrintTimePerData.MinimumWidth = 80;
            this.PrintTimePerData.Name = "PrintTimePerData";
            this.PrintTimePerData.Width = 90;
            // 
            // AddTimePerData
            // 
            this.AddTimePerData.HeaderText = "Include Time Period Data";
            this.AddTimePerData.MinimumWidth = 80;
            this.AddTimePerData.Name = "AddTimePerData";
            this.AddTimePerData.Width = 80;
            // 
            // EditTimePerData
            // 
            this.EditTimePerData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditTimePerData.HeaderText = "Edit Time Period Data";
            this.EditTimePerData.MinimumWidth = 50;
            this.EditTimePerData.Name = "EditTimePerData";
            this.EditTimePerData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditTimePerData.Text = "Edit";
            this.EditTimePerData.UseColumnTextForLinkValue = true;
            this.EditTimePerData.Width = 84;
            // 
            // colPhysicalLink
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Yes";
            this.colPhysicalLink.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPhysicalLink.HeaderText = "Physical Link";
            this.colPhysicalLink.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.colPhysicalLink.Name = "colPhysicalLink";
            // 
            // colFreewayFacilities
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "Open";
            this.colFreewayFacilities.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFreewayFacilities.HeaderText = "Freeway Facilities";
            this.colFreewayFacilities.Name = "colFreewayFacilities";
            this.colFreewayFacilities.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colCheckBoundaries
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "Show";
            this.colCheckBoundaries.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCheckBoundaries.HeaderText = "Travel Time-Flow Relationship";
            this.colCheckBoundaries.Name = "colCheckBoundaries";
            this.colCheckBoundaries.ReadOnly = true;
            this.colCheckBoundaries.Width = 115;
            // 
            // frmLinkData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 523);
            this.Controls.Add(this.tsLinkData);
            this.Controls.Add(this.dgvLinkData);
            this.Name = "frmLinkData";
            this.Text = "Node-Link Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLinkData_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLinkData_FormClosed);
            this.Load += new System.EventHandler(this.frmLinkData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkData)).EndInit();
            this.tsLinkData.ResumeLayout(false);
            this.tsLinkData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLinkData;
        private System.Windows.Forms.ToolTip tipLinkData;
        private System.Windows.Forms.ToolStrip tsLinkData;
        private System.Windows.Forms.ToolStripButton tsbSaveLinkData;
        private System.Windows.Forms.ToolStripButton tsbDiscardLinkDataChanges;
        private System.Windows.Forms.ToolStripButton tsbInsertLink;
        private System.Windows.Forms.ToolStripButton tsbDeleteLink;
        private System.Windows.Forms.ToolStripButton tsbLoadLinkData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsFirstNode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsTotNodes;
        private System.Windows.Forms.ToolStripButton tsbCopyLinkData;
        private System.Windows.Forms.ToolStripButton tsbPasteLinkData;
        private System.Windows.Forms.ToolStripButton tsbAddLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn FFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FFTravTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintTimePerData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AddTimePerData;
        private System.Windows.Forms.DataGridViewLinkColumn EditTimePerData;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPhysicalLink;
        private System.Windows.Forms.DataGridViewButtonColumn colFreewayFacilities;
        private System.Windows.Forms.DataGridViewButtonColumn colCheckBoundaries;
    }
}

