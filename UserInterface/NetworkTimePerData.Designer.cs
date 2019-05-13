namespace XXE_UserInterface
{
    partial class frmNetworkTimePerData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNetworkTimePerData = new System.Windows.Forms.DataGridView();
            this.TimePer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntensRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PctUninfDrivers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsFillDown = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNetworkTimePerData)).BeginInit();
            this.contextMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNetworkTimePerData
            // 
            this.dgvNetworkTimePerData.AllowUserToAddRows = false;
            this.dgvNetworkTimePerData.AllowUserToDeleteRows = false;
            this.dgvNetworkTimePerData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNetworkTimePerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNetworkTimePerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNetworkTimePerData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimePer,
            this.IntensRatio,
            this.PctUninfDrivers});
            this.dgvNetworkTimePerData.Location = new System.Drawing.Point(12, 12);
            this.dgvNetworkTimePerData.Name = "dgvNetworkTimePerData";
            this.dgvNetworkTimePerData.Size = new System.Drawing.Size(315, 424);
            this.dgvNetworkTimePerData.TabIndex = 1;
            this.dgvNetworkTimePerData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNetworkTimePerData_CellMouseDown);
            this.dgvNetworkTimePerData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvNetworkTimePerData_CellValidating);
            this.dgvNetworkTimePerData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNetworkTimePerData_CellEndEdit);
            // 
            // TimePer
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TimePer.DefaultCellStyle = dataGridViewCellStyle2;
            this.TimePer.HeaderText = "Time Period";
            this.TimePer.MaxInputLength = 2;
            this.TimePer.Name = "TimePer";
            this.TimePer.ReadOnly = true;
            this.TimePer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimePer.Width = 70;
            // 
            // IntensRatio
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IntensRatio.DefaultCellStyle = dataGridViewCellStyle3;
            this.IntensRatio.HeaderText = "Traffic Intensity Ratio";
            this.IntensRatio.MaxInputLength = 4;
            this.IntensRatio.Name = "IntensRatio";
            this.IntensRatio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IntensRatio.Width = 90;
            // 
            // PctUninfDrivers
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PctUninfDrivers.DefaultCellStyle = dataGridViewCellStyle4;
            this.PctUninfDrivers.HeaderText = "Percent Uninformed Drivers";
            this.PctUninfDrivers.MaxInputLength = 3;
            this.PctUninfDrivers.Name = "PctUninfDrivers";
            this.PctUninfDrivers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PctUninfDrivers.Width = 90;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(117, 450);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(236, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // contextMS
            // 
            this.contextMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFillDown});
            this.contextMS.Name = "contextMS";
            this.contextMS.Size = new System.Drawing.Size(156, 26);
            this.contextMS.Click += new System.EventHandler(this.tsFillDown_Click);
            // 
            // tsFillDown
            // 
            this.tsFillDown.Name = "tsFillDown";
            this.tsFillDown.Size = new System.Drawing.Size(155, 22);
            this.tsFillDown.Text = "Fill Down Value";
            // 
            // frmNetworkTimePerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 496);
            this.Controls.Add(this.dgvNetworkTimePerData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "frmNetworkTimePerData";
            this.Text = "Network Time Period Data";
            this.Load += new System.EventHandler(this.frmNetworkTimePerData_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNetworkTimePerData_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNetworkTimePerData)).EndInit();
            this.contextMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNetworkTimePerData;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntensRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PctUninfDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsFillDown;
    }
}