namespace XXE_UserInterface
{
    partial class frmUEresultsFreewayfacilities
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlResultsChart = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colTimePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhysicalLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTravelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreewayFacilities = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboChartTimePeriod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConvergenceValue = new System.Windows.Forms.TextBox();
            this.txtNumIterations = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboObjValues = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLinkIDs = new System.Windows.Forms.ComboBox();
            this.btnODresults = new System.Windows.Forms.Button();
            this.btnFlowConservation = new System.Windows.Forms.Button();
            this.lblConverged = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlResultsChart
            // 
            this.pnlResultsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResultsChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResultsChart.Location = new System.Drawing.Point(563, 54);
            this.pnlResultsChart.Name = "pnlResultsChart";
            this.pnlResultsChart.Size = new System.Drawing.Size(606, 555);
            this.pnlResultsChart.TabIndex = 72;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimePeriod,
            this.colID,
            this.colPhysicalLink,
            this.colFromNode,
            this.colToNode,
            this.colVolume,
            this.colTravelTime,
            this.colFreewayFacilities});
            this.dgvResults.Location = new System.Drawing.Point(12, 54);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(510, 555);
            this.dgvResults.TabIndex = 73;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // colTimePeriod
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTimePeriod.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTimePeriod.HeaderText = "Time Period";
            this.colTimePeriod.Name = "colTimePeriod";
            this.colTimePeriod.ReadOnly = true;
            this.colTimePeriod.Width = 50;
            // 
            // colID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colID.HeaderText = "Link ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 40;
            // 
            // colPhysicalLink
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPhysicalLink.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPhysicalLink.HeaderText = "Physical Link";
            this.colPhysicalLink.Name = "colPhysicalLink";
            this.colPhysicalLink.ReadOnly = true;
            this.colPhysicalLink.Width = 50;
            // 
            // colFromNode
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFromNode.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFromNode.HeaderText = "From Node";
            this.colFromNode.Name = "colFromNode";
            this.colFromNode.ReadOnly = true;
            this.colFromNode.Width = 45;
            // 
            // colToNode
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colToNode.DefaultCellStyle = dataGridViewCellStyle5;
            this.colToNode.HeaderText = "To Node";
            this.colToNode.Name = "colToNode";
            this.colToNode.ReadOnly = true;
            this.colToNode.Width = 45;
            // 
            // colVolume
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVolume.DefaultCellStyle = dataGridViewCellStyle6;
            this.colVolume.HeaderText = "Flow";
            this.colVolume.Name = "colVolume";
            this.colVolume.ReadOnly = true;
            this.colVolume.Width = 65;
            // 
            // colTravelTime
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTravelTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTravelTime.HeaderText = "Travel Time";
            this.colTravelTime.Name = "colTravelTime";
            this.colTravelTime.ReadOnly = true;
            this.colTravelTime.Width = 55;
            // 
            // colFreewayFacilities
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "Show";
            this.colFreewayFacilities.DefaultCellStyle = dataGridViewCellStyle8;
            this.colFreewayFacilities.HeaderText = "Freeway Facilities";
            this.colFreewayFacilities.Name = "colFreewayFacilities";
            this.colFreewayFacilities.ReadOnly = true;
            this.colFreewayFacilities.Width = 50;
            // 
            // cboChartTimePeriod
            // 
            this.cboChartTimePeriod.FormattingEnabled = true;
            this.cboChartTimePeriod.Items.AddRange(new object[] {
            "Physical Links Only",
            "All Links"});
            this.cboChartTimePeriod.Location = new System.Drawing.Point(502, 18);
            this.cboChartTimePeriod.Name = "cboChartTimePeriod";
            this.cboChartTimePeriod.Size = new System.Drawing.Size(33, 21);
            this.cboChartTimePeriod.TabIndex = 75;
            this.cboChartTimePeriod.Text = "1";
            this.cboChartTimePeriod.SelectedIndexChanged += new System.EventHandler(this.cboChartTimePeriod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Time Period:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(790, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Convergence Value:";
            // 
            // txtConvergenceValue
            // 
            this.txtConvergenceValue.Location = new System.Drawing.Point(898, 18);
            this.txtConvergenceValue.Name = "txtConvergenceValue";
            this.txtConvergenceValue.Size = new System.Drawing.Size(69, 20);
            this.txtConvergenceValue.TabIndex = 78;
            // 
            // txtNumIterations
            // 
            this.txtNumIterations.Location = new System.Drawing.Point(742, 18);
            this.txtNumIterations.Name = "txtNumIterations";
            this.txtNumIterations.Size = new System.Drawing.Size(36, 20);
            this.txtNumIterations.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Number of Iterations:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Chart Type:";
            // 
            // cboObjValues
            // 
            this.cboObjValues.FormattingEnabled = true;
            this.cboObjValues.Items.AddRange(new object[] {
            "Convergence Values",
            "Link Volumes"});
            this.cboObjValues.Location = new System.Drawing.Point(299, 17);
            this.cboObjValues.Name = "cboObjValues";
            this.cboObjValues.Size = new System.Drawing.Size(121, 21);
            this.cboObjValues.TabIndex = 82;
            this.cboObjValues.Text = "Convergence Values";
            this.cboObjValues.SelectedIndexChanged += new System.EventHandler(this.cboObjValues_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "Link ID:";
            // 
            // cboLinkIDs
            // 
            this.cboLinkIDs.FormattingEnabled = true;
            this.cboLinkIDs.Location = new System.Drawing.Point(590, 18);
            this.cboLinkIDs.Name = "cboLinkIDs";
            this.cboLinkIDs.Size = new System.Drawing.Size(39, 21);
            this.cboLinkIDs.TabIndex = 84;
            this.cboLinkIDs.SelectedIndexChanged += new System.EventHandler(this.cboLinkIDs_SelectedIndexChanged);
            // 
            // btnODresults
            // 
            this.btnODresults.Location = new System.Drawing.Point(12, 16);
            this.btnODresults.Name = "btnODresults";
            this.btnODresults.Size = new System.Drawing.Size(76, 23);
            this.btnODresults.TabIndex = 85;
            this.btnODresults.Text = "OD Results";
            this.btnODresults.UseVisualStyleBackColor = true;
            this.btnODresults.Click += new System.EventHandler(this.btnODresults_Click);
            // 
            // btnFlowConservation
            // 
            this.btnFlowConservation.Location = new System.Drawing.Point(101, 16);
            this.btnFlowConservation.Name = "btnFlowConservation";
            this.btnFlowConservation.Size = new System.Drawing.Size(120, 23);
            this.btnFlowConservation.TabIndex = 86;
            this.btnFlowConservation.Text = "Conservation of Flow";
            this.btnFlowConservation.UseVisualStyleBackColor = true;
            this.btnFlowConservation.Click += new System.EventHandler(this.btnFlowConservation_Click);
            // 
            // lblConverged
            // 
            this.lblConverged.AutoSize = true;
            this.lblConverged.ForeColor = System.Drawing.Color.Blue;
            this.lblConverged.Location = new System.Drawing.Point(976, 21);
            this.lblConverged.Name = "lblConverged";
            this.lblConverged.Size = new System.Drawing.Size(59, 13);
            this.lblConverged.TabIndex = 87;
            this.lblConverged.Text = "Converged";
            this.lblConverged.Visible = false;
            // 
            // frmUEresultsFreewayfacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 643);
            this.Controls.Add(this.lblConverged);
            this.Controls.Add(this.btnFlowConservation);
            this.Controls.Add(this.btnODresults);
            this.Controls.Add(this.cboLinkIDs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboObjValues);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumIterations);
            this.Controls.Add(this.txtConvergenceValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboChartTimePeriod);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.pnlResultsChart);
            this.Name = "frmUEresultsFreewayfacilities";
            this.Text = "Results";
            this.SizeChanged += new System.EventHandler(this.frmUEresultsFreewayfacilities_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlResultsChart;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.ComboBox cboChartTimePeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConvergenceValue;
        private System.Windows.Forms.TextBox txtNumIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboObjValues;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLinkIDs;
        private System.Windows.Forms.Button btnODresults;
        private System.Windows.Forms.Button btnFlowConservation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhysicalLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTravelTime;
        private System.Windows.Forms.DataGridViewButtonColumn colFreewayFacilities;
        private System.Windows.Forms.Label lblConverged;
    }
}