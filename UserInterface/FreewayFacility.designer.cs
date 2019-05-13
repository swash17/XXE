namespace XXE_UserInterface
{
    partial class FreewayFacility
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
            this.dgvVolumeTravelTime = new System.Windows.Forms.DataGridView();
            this.panelChartControl = new System.Windows.Forms.Panel();
            this.updnMinFlow = new System.Windows.Forms.NumericUpDown();
            this.updnMaxFlow = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.updnIntervalFlow = new System.Windows.Forms.NumericUpDown();
            this.btnCreateChart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.updnTimePeriod = new System.Windows.Forms.NumericUpDown();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgTravelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreewayFacilities = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolumeTravelTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnMinFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnMaxFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnIntervalFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnTimePeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVolumeTravelTime
            // 
            this.dgvVolumeTravelTime.AllowDrop = true;
            this.dgvVolumeTravelTime.AllowUserToAddRows = false;
            this.dgvVolumeTravelTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVolumeTravelTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colVolume,
            this.colAvgTravelTime,
            this.colFreewayFacilities});
            this.dgvVolumeTravelTime.Location = new System.Drawing.Point(13, 52);
            this.dgvVolumeTravelTime.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVolumeTravelTime.Name = "dgvVolumeTravelTime";
            this.dgvVolumeTravelTime.RowTemplate.Height = 24;
            this.dgvVolumeTravelTime.Size = new System.Drawing.Size(363, 561);
            this.dgvVolumeTravelTime.TabIndex = 37;
            this.dgvVolumeTravelTime.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVolumeTravelTime_CellContentClick);
            // 
            // panelChartControl
            // 
            this.panelChartControl.BackColor = System.Drawing.Color.White;
            this.panelChartControl.Location = new System.Drawing.Point(397, 52);
            this.panelChartControl.Name = "panelChartControl";
            this.panelChartControl.Size = new System.Drawing.Size(628, 561);
            this.panelChartControl.TabIndex = 38;
            // 
            // updnMinFlow
            // 
            this.updnMinFlow.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.updnMinFlow.Location = new System.Drawing.Point(190, 14);
            this.updnMinFlow.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updnMinFlow.Name = "updnMinFlow";
            this.updnMinFlow.Size = new System.Drawing.Size(48, 20);
            this.updnMinFlow.TabIndex = 39;
            // 
            // updnMaxFlow
            // 
            this.updnMaxFlow.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.updnMaxFlow.Location = new System.Drawing.Point(425, 14);
            this.updnMaxFlow.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updnMaxFlow.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.updnMaxFlow.Name = "updnMaxFlow";
            this.updnMaxFlow.Size = new System.Drawing.Size(56, 20);
            this.updnMaxFlow.TabIndex = 40;
            this.updnMaxFlow.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Min. Mainline Input Volume (veh/h)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Max. Mainline Input Volume (veh/h)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Volume Increase Unit (veh/h)";
            // 
            // updnIntervalFlow
            // 
            this.updnIntervalFlow.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.updnIntervalFlow.Location = new System.Drawing.Point(651, 14);
            this.updnIntervalFlow.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updnIntervalFlow.Name = "updnIntervalFlow";
            this.updnIntervalFlow.Size = new System.Drawing.Size(48, 20);
            this.updnIntervalFlow.TabIndex = 44;
            this.updnIntervalFlow.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnCreateChart
            // 
            this.btnCreateChart.Location = new System.Drawing.Point(848, 6);
            this.btnCreateChart.Name = "btnCreateChart";
            this.btnCreateChart.Size = new System.Drawing.Size(177, 33);
            this.btnCreateChart.TabIndex = 45;
            this.btnCreateChart.Text = "Mainline Input - Travel Time Chart";
            this.btnCreateChart.UseVisualStyleBackColor = true;
            this.btnCreateChart.Click += new System.EventHandler(this.btnCreateChart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(711, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Time Period";
            // 
            // updnTimePeriod
            // 
            this.updnTimePeriod.Location = new System.Drawing.Point(782, 14);
            this.updnTimePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updnTimePeriod.Name = "updnTimePeriod";
            this.updnTimePeriod.Size = new System.Drawing.Size(48, 20);
            this.updnTimePeriod.TabIndex = 47;
            this.updnTimePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colVolume
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVolume.DefaultCellStyle = dataGridViewCellStyle2;
            this.colVolume.HeaderText = "Mainline Input Volume (veh/h)";
            this.colVolume.Name = "colVolume";
            this.colVolume.ReadOnly = true;
            this.colVolume.Width = 80;
            // 
            // colAvgTravelTime
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAvgTravelTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAvgTravelTime.HeaderText = "Avg. Travel Time (min)";
            this.colAvgTravelTime.Name = "colAvgTravelTime";
            this.colAvgTravelTime.ReadOnly = true;
            this.colAvgTravelTime.Width = 80;
            // 
            // colFreewayFacilities
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Open";
            this.colFreewayFacilities.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFreewayFacilities.HeaderText = "Open in Freeway Facility Program";
            this.colFreewayFacilities.Name = "colFreewayFacilities";
            this.colFreewayFacilities.ReadOnly = true;
            this.colFreewayFacilities.Width = 80;
            // 
            // FreewayFacility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 630);
            this.Controls.Add(this.updnTimePeriod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateChart);
            this.Controls.Add(this.updnIntervalFlow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updnMaxFlow);
            this.Controls.Add(this.updnMinFlow);
            this.Controls.Add(this.panelChartControl);
            this.Controls.Add(this.dgvVolumeTravelTime);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FreewayFacility";
            this.Text = "Freeway Facility";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolumeTravelTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnMinFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnMaxFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnIntervalFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updnTimePeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvVolumeTravelTime;
        private System.Windows.Forms.Panel panelChartControl;
        private System.Windows.Forms.NumericUpDown updnMinFlow;
        private System.Windows.Forms.NumericUpDown updnMaxFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown updnIntervalFlow;
        private System.Windows.Forms.Button btnCreateChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown updnTimePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgTravelTime;
        private System.Windows.Forms.DataGridViewButtonColumn colFreewayFacilities;
    }
}

