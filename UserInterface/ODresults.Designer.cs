namespace XXE_UserInterface
{
    partial class ODresults
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
            this.dgvODresults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTimePeriod = new System.Windows.Forms.ComboBox();
            this.cboODdataset = new System.Windows.Forms.ComboBox();
            this.lblODset = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathNodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathLinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathTravelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvODresults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvODresults
            // 
            this.dgvODresults.AllowUserToAddRows = false;
            this.dgvODresults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvODresults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPathNodes,
            this.colPathLinks,
            this.colPathTravelTime});
            this.dgvODresults.Location = new System.Drawing.Point(12, 39);
            this.dgvODresults.Name = "dgvODresults";
            this.dgvODresults.Size = new System.Drawing.Size(626, 662);
            this.dgvODresults.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Time Period:";
            // 
            // cboTimePeriod
            // 
            this.cboTimePeriod.FormattingEnabled = true;
            this.cboTimePeriod.Items.AddRange(new object[] {
            "Physical Links Only",
            "All Links"});
            this.cboTimePeriod.Location = new System.Drawing.Point(86, 12);
            this.cboTimePeriod.Name = "cboTimePeriod";
            this.cboTimePeriod.Size = new System.Drawing.Size(33, 21);
            this.cboTimePeriod.TabIndex = 77;
            this.cboTimePeriod.Text = "1";
            this.cboTimePeriod.SelectedIndexChanged += new System.EventHandler(this.cboTimePeriod_SelectedIndexChanged);
            // 
            // cboODdataset
            // 
            this.cboODdataset.FormattingEnabled = true;
            this.cboODdataset.Location = new System.Drawing.Point(168, 12);
            this.cboODdataset.Name = "cboODdataset";
            this.cboODdataset.Size = new System.Drawing.Size(97, 21);
            this.cboODdataset.TabIndex = 80;
            this.cboODdataset.SelectedIndexChanged += new System.EventHandler(this.cboODdataset_SelectedIndexChanged);
            // 
            // lblODset
            // 
            this.lblODset.AutoSize = true;
            this.lblODset.Location = new System.Drawing.Point(135, 15);
            this.lblODset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblODset.Name = "lblODset";
            this.lblODset.Size = new System.Drawing.Size(26, 13);
            this.lblODset.TabIndex = 79;
            this.lblODset.Text = "OD:";
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 65;
            // 
            // colPathNodes
            // 
            this.colPathNodes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPathNodes.HeaderText = "Path (Nodes)";
            this.colPathNodes.Name = "colPathNodes";
            this.colPathNodes.ReadOnly = true;
            this.colPathNodes.Width = 94;
            // 
            // colPathLinks
            // 
            this.colPathLinks.HeaderText = "Path (Links)";
            this.colPathLinks.Name = "colPathLinks";
            this.colPathLinks.ReadOnly = true;
            this.colPathLinks.Width = 150;
            // 
            // colPathTravelTime
            // 
            this.colPathTravelTime.HeaderText = "Travel Time (min)";
            this.colPathTravelTime.Name = "colPathTravelTime";
            this.colPathTravelTime.ReadOnly = true;
            this.colPathTravelTime.Width = 120;
            // 
            // ODresults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 713);
            this.Controls.Add(this.cboODdataset);
            this.Controls.Add(this.lblODset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTimePeriod);
            this.Controls.Add(this.dgvODresults);
            this.Name = "ODresults";
            this.Text = "User Equilibrium OD Results";
            ((System.ComponentModel.ISupportInitialize)(this.dgvODresults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvODresults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTimePeriod;
        private System.Windows.Forms.ComboBox cboODdataset;
        private System.Windows.Forms.Label lblODset;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathNodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathLinks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathTravelTime;
    }
}