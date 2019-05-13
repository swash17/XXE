namespace XXE_UserInterface
{
    partial class frmOrigDest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrigDest));
            this.dgvODdata = new System.Windows.Forms.DataGridView();
            this.OrigZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumTrips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsODdata = new System.Windows.Forms.ToolStrip();
            this.tsbSaveODdata = new System.Windows.Forms.ToolStripButton();
            this.tsbDiscardODdataChanges = new System.Windows.Forms.ToolStripButton();
            this.tsbAddODrecord = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertODrecord = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteODrecord = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadODdata = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvODdata)).BeginInit();
            this.tsODdata.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvODdata
            // 
            this.dgvODdata.AllowUserToAddRows = false;
            this.dgvODdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.dgvODdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvODdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvODdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvODdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvODdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrigZone,
            this.DestZone,
            this.NumTrips});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvODdata.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvODdata.Location = new System.Drawing.Point(12, 34);
            this.dgvODdata.Name = "dgvODdata";
            this.dgvODdata.RowHeadersWidth = 55;
            this.dgvODdata.Size = new System.Drawing.Size(381, 448);
            this.dgvODdata.TabIndex = 0;
            this.dgvODdata.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvODdata_CellValidated);
            this.dgvODdata.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvODdata_CellValidating);
            this.dgvODdata.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvODdata_CellValueChanged);
            this.dgvODdata.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvODdata_RowPostPaint);
            // 
            // OrigZone
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OrigZone.DefaultCellStyle = dataGridViewCellStyle3;
            this.OrigZone.HeaderText = "Origin Zone";
            this.OrigZone.MinimumWidth = 10;
            this.OrigZone.Name = "OrigZone";
            this.OrigZone.ToolTipText = "Origin Zone must be a positive integer value";
            // 
            // DestZone
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DestZone.DefaultCellStyle = dataGridViewCellStyle4;
            this.DestZone.HeaderText = "Destination Zone";
            this.DestZone.MinimumWidth = 10;
            this.DestZone.Name = "DestZone";
            this.DestZone.ToolTipText = "Destination Zone must be a positive integer value";
            // 
            // NumTrips
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NumTrips.DefaultCellStyle = dataGridViewCellStyle5;
            this.NumTrips.HeaderText = "Number of Trips";
            this.NumTrips.MinimumWidth = 10;
            this.NumTrips.Name = "NumTrips";
            this.NumTrips.ToolTipText = "Number of Trips must be a positive integer value";
            // 
            // tsODdata
            // 
            this.tsODdata.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveODdata,
            this.tsbDiscardODdataChanges,
            this.tsbAddODrecord,
            this.tsbInsertODrecord,
            this.tsbDeleteODrecord,
            this.tsbLoadODdata});
            this.tsODdata.Location = new System.Drawing.Point(0, 0);
            this.tsODdata.Name = "tsODdata";
            this.tsODdata.Size = new System.Drawing.Size(404, 25);
            this.tsODdata.TabIndex = 7;
            this.tsODdata.Text = "toolStrip1";
            // 
            // tsbSaveODdata
            // 
            this.tsbSaveODdata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveODdata.Image = global::XXE_UserInterface.Properties.Resources.Save;
            this.tsbSaveODdata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveODdata.Name = "tsbSaveODdata";
            this.tsbSaveODdata.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveODdata.ToolTipText = "Save Data and Close Form";
            this.tsbSaveODdata.Click += new System.EventHandler(this.tsbSaveODdata_Click);
            // 
            // tsbDiscardODdataChanges
            // 
            this.tsbDiscardODdataChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDiscardODdataChanges.Image = global::XXE_UserInterface.Properties.Resources.DeleteTable;
            this.tsbDiscardODdataChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscardODdataChanges.Name = "tsbDiscardODdataChanges";
            this.tsbDiscardODdataChanges.Size = new System.Drawing.Size(23, 22);
            this.tsbDiscardODdataChanges.ToolTipText = "Close Form without Saving Data";
            this.tsbDiscardODdataChanges.Click += new System.EventHandler(this.tsbDiscardODdataChanges_Click);
            // 
            // tsbAddODrecord
            // 
            this.tsbAddODrecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddODrecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddODrecord.Image")));
            this.tsbAddODrecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddODrecord.Name = "tsbAddODrecord";
            this.tsbAddODrecord.Size = new System.Drawing.Size(23, 22);
            this.tsbAddODrecord.Text = "Add New Row at Bottom";
            this.tsbAddODrecord.Click += new System.EventHandler(this.tsbAddODrecord_Click);
            // 
            // tsbInsertODrecord
            // 
            this.tsbInsertODrecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertODrecord.Image = global::XXE_UserInterface.Properties.Resources.RowInsert1;
            this.tsbInsertODrecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertODrecord.Name = "tsbInsertODrecord";
            this.tsbInsertODrecord.Size = new System.Drawing.Size(23, 22);
            this.tsbInsertODrecord.ToolTipText = "Insert Row at Selected Position";
            this.tsbInsertODrecord.Click += new System.EventHandler(this.tsbInsertODrecord_Click);
            // 
            // tsbDeleteODrecord
            // 
            this.tsbDeleteODrecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteODrecord.Image = global::XXE_UserInterface.Properties.Resources.RowDelete;
            this.tsbDeleteODrecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteODrecord.Name = "tsbDeleteODrecord";
            this.tsbDeleteODrecord.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteODrecord.ToolTipText = "Delete Row at Selected Position";
            this.tsbDeleteODrecord.Click += new System.EventHandler(this.tsbDeleteODrecord_Click);
            // 
            // tsbLoadODdata
            // 
            this.tsbLoadODdata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadODdata.Image = global::XXE_UserInterface.Properties.Resources.OpenFolder;
            this.tsbLoadODdata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadODdata.Name = "tsbLoadODdata";
            this.tsbLoadODdata.Size = new System.Drawing.Size(23, 22);
            this.tsbLoadODdata.Text = "toolStripButton1";
            this.tsbLoadODdata.ToolTipText = "Load OD data from CSV formatted file";
            this.tsbLoadODdata.Click += new System.EventHandler(this.tsbLoadODdata_Click);
            // 
            // frmOrigDest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 494);
            this.Controls.Add(this.tsODdata);
            this.Controls.Add(this.dgvODdata);
            this.Name = "frmOrigDest";
            this.Text = "Origin-Destination Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrigDest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrigDest_FormClosed);
            this.Load += new System.EventHandler(this.frmOrigDest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvODdata)).EndInit();
            this.tsODdata.ResumeLayout(false);
            this.tsODdata.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvODdata;
        private System.Windows.Forms.ToolStrip tsODdata;
        private System.Windows.Forms.ToolStripButton tsbSaveODdata;
        private System.Windows.Forms.ToolStripButton tsbDiscardODdataChanges;
        private System.Windows.Forms.ToolStripButton tsbInsertODrecord;
        private System.Windows.Forms.ToolStripButton tsbDeleteODrecord;
        private System.Windows.Forms.ToolStripButton tsbLoadODdata;
        private System.Windows.Forms.ToolStripButton tsbAddODrecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrigZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumTrips;
    }
}