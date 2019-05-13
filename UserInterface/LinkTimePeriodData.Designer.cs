namespace XXE_UserInterface
{
    partial class frmLinkTimePerData
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
            this.dgvTimePerData = new System.Windows.Forms.DataGridView();
            this.TimePer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PctCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimePerData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimePerData
            // 
            this.dgvTimePerData.AllowUserToAddRows = false;
            this.dgvTimePerData.AllowUserToDeleteRows = false;
            this.dgvTimePerData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimePerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimePerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimePerData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimePer,
            this.PctCap});
            this.dgvTimePerData.Location = new System.Drawing.Point(29, 12);
            this.dgvTimePerData.Name = "dgvTimePerData";
            this.dgvTimePerData.Size = new System.Drawing.Size(267, 361);
            this.dgvTimePerData.TabIndex = 0;
            // 
            // TimePer
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TimePer.DefaultCellStyle = dataGridViewCellStyle2;
            this.TimePer.HeaderText = "Time Period";
            this.TimePer.MaxInputLength = 2;
            this.TimePer.MinimumWidth = 100;
            this.TimePer.Name = "TimePer";
            this.TimePer.ReadOnly = true;
            this.TimePer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PctCap
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PctCap.DefaultCellStyle = dataGridViewCellStyle3;
            this.PctCap.HeaderText = "Proportion of Full Capacity";
            this.PctCap.MaxInputLength = 4;
            this.PctCap.MinimumWidth = 100;
            this.PctCap.Name = "PctCap";
            this.PctCap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(29, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(198, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLinkTimePerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 433);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvTimePerData);
            this.MaximizeBox = false;
            this.Name = "frmLinkTimePerData";
            this.Text = "Link Capacity Restriction Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLinkTimePerData_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimePerData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimePerData;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PctCap;
    }
}