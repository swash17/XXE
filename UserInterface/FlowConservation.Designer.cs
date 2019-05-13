namespace XXE_UserInterface
{
    partial class FlowConservation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvConservationFlow = new System.Windows.Forms.DataGridView();
            this.colNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colODflow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinkFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colODs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChartTimePeriod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConservationFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConservationFlow
            // 
            this.dgvConservationFlow.AllowUserToAddRows = false;
            this.dgvConservationFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConservationFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConservationFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNode,
            this.colType,
            this.colODflow,
            this.colLinkFlow,
            this.colODs,
            this.colLinks});
            this.dgvConservationFlow.Location = new System.Drawing.Point(12, 33);
            this.dgvConservationFlow.Name = "dgvConservationFlow";
            this.dgvConservationFlow.Size = new System.Drawing.Size(732, 592);
            this.dgvConservationFlow.TabIndex = 74;
            // 
            // colNode
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNode.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNode.HeaderText = "Node";
            this.colNode.Name = "colNode";
            this.colNode.ReadOnly = true;
            this.colNode.Width = 50;
            // 
            // colType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 90;
            // 
            // colODflow
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colODflow.DefaultCellStyle = dataGridViewCellStyle3;
            this.colODflow.HeaderText = "OD Flow";
            this.colODflow.Name = "colODflow";
            this.colODflow.ReadOnly = true;
            this.colODflow.Width = 80;
            // 
            // colLinkFlow
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLinkFlow.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLinkFlow.HeaderText = "Link Flow";
            this.colLinkFlow.Name = "colLinkFlow";
            this.colLinkFlow.ReadOnly = true;
            this.colLinkFlow.Width = 80;
            // 
            // colODs
            // 
            this.colODs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colODs.DefaultCellStyle = dataGridViewCellStyle5;
            this.colODs.HeaderText = "Connected Zones";
            this.colODs.Name = "colODs";
            this.colODs.ReadOnly = true;
            this.colODs.Width = 107;
            // 
            // colLinks
            // 
            this.colLinks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colLinks.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLinks.HeaderText = "Connected Links";
            this.colLinks.Name = "colLinks";
            this.colLinks.ReadOnly = true;
            this.colLinks.Width = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Time Period:";
            // 
            // cboChartTimePeriod
            // 
            this.cboChartTimePeriod.FormattingEnabled = true;
            this.cboChartTimePeriod.Items.AddRange(new object[] {
            "Physical Links Only",
            "All Links"});
            this.cboChartTimePeriod.Location = new System.Drawing.Point(84, 6);
            this.cboChartTimePeriod.Name = "cboChartTimePeriod";
            this.cboChartTimePeriod.Size = new System.Drawing.Size(33, 21);
            this.cboChartTimePeriod.TabIndex = 77;
            this.cboChartTimePeriod.Text = "1";
            this.cboChartTimePeriod.SelectedIndexChanged += new System.EventHandler(this.cboChartTimePeriod_SelectedIndexChanged);
            // 
            // FlowConservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboChartTimePeriod);
            this.Controls.Add(this.dgvConservationFlow);
            this.Name = "FlowConservation";
            this.Text = "Conservation of Flow";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConservationFlow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConservationFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboChartTimePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colODflow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colODs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinks;
    }
}