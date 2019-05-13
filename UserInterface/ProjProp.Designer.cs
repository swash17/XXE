namespace XXE_UserInterface
{
    partial class frmProjProp
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
            this.lblProjTitle = new System.Windows.Forms.Label();
            this.txtProjTitle = new System.Windows.Forms.TextBox();
            this.lblAnalDate = new System.Windows.Forms.Label();
            this.dtpAnalDate = new System.Windows.Forms.DateTimePicker();
            this.lblAnalName = new System.Windows.Forms.Label();
            this.txtAnalName = new System.Windows.Forms.TextBox();
            this.lblUserNotes = new System.Windows.Forms.Label();
            this.txtUserNotes = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumTimePers = new System.Windows.Forms.TextBox();
            this.lblNumTimePers = new System.Windows.Forms.Label();
            this.cboTimePer = new System.Windows.Forms.ComboBox();
            this.lblTimePer = new System.Windows.Forms.Label();
            this.rdoMultiTimePer = new System.Windows.Forms.RadioButton();
            this.rdoSingleTimePer = new System.Windows.Forms.RadioButton();
            this.txtSysTravTimeRatio = new System.Windows.Forms.TextBox();
            this.rdoFreewayFacilities = new System.Windows.Forms.RadioButton();
            this.rdoLinks = new System.Windows.Forms.RadioButton();
            this.grpProjectType = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpProjectType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjTitle
            // 
            this.lblProjTitle.AutoSize = true;
            this.lblProjTitle.Location = new System.Drawing.Point(18, 22);
            this.lblProjTitle.Name = "lblProjTitle";
            this.lblProjTitle.Size = new System.Drawing.Size(63, 13);
            this.lblProjTitle.TabIndex = 0;
            this.lblProjTitle.Text = "Project Title";
            // 
            // txtProjTitle
            // 
            this.txtProjTitle.Location = new System.Drawing.Point(100, 19);
            this.txtProjTitle.Name = "txtProjTitle";
            this.txtProjTitle.Size = new System.Drawing.Size(194, 20);
            this.txtProjTitle.TabIndex = 1;
            // 
            // lblAnalDate
            // 
            this.lblAnalDate.AutoSize = true;
            this.lblAnalDate.Location = new System.Drawing.Point(10, 49);
            this.lblAnalDate.Name = "lblAnalDate";
            this.lblAnalDate.Size = new System.Drawing.Size(71, 13);
            this.lblAnalDate.TabIndex = 2;
            this.lblAnalDate.Text = "Analysis Date";
            // 
            // dtpAnalDate
            // 
            this.dtpAnalDate.Location = new System.Drawing.Point(100, 45);
            this.dtpAnalDate.Name = "dtpAnalDate";
            this.dtpAnalDate.Size = new System.Drawing.Size(194, 20);
            this.dtpAnalDate.TabIndex = 3;
            // 
            // lblAnalName
            // 
            this.lblAnalName.AutoSize = true;
            this.lblAnalName.Location = new System.Drawing.Point(9, 74);
            this.lblAnalName.Name = "lblAnalName";
            this.lblAnalName.Size = new System.Drawing.Size(72, 13);
            this.lblAnalName.TabIndex = 4;
            this.lblAnalName.Text = "Analyst Name";
            // 
            // txtAnalName
            // 
            this.txtAnalName.Location = new System.Drawing.Point(100, 71);
            this.txtAnalName.Name = "txtAnalName";
            this.txtAnalName.Size = new System.Drawing.Size(194, 20);
            this.txtAnalName.TabIndex = 5;
            // 
            // lblUserNotes
            // 
            this.lblUserNotes.AutoSize = true;
            this.lblUserNotes.Location = new System.Drawing.Point(21, 100);
            this.lblUserNotes.Name = "lblUserNotes";
            this.lblUserNotes.Size = new System.Drawing.Size(60, 13);
            this.lblUserNotes.TabIndex = 6;
            this.lblUserNotes.Text = "User Notes";
            // 
            // txtUserNotes
            // 
            this.txtUserNotes.Location = new System.Drawing.Point(100, 97);
            this.txtUserNotes.Multiline = true;
            this.txtUserNotes.Name = "txtUserNotes";
            this.txtUserNotes.Size = new System.Drawing.Size(194, 84);
            this.txtUserNotes.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(380, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 30);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(476, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "System Travel Time Adjustment Ratio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumTimePers);
            this.groupBox1.Controls.Add(this.lblNumTimePers);
            this.groupBox1.Controls.Add(this.cboTimePer);
            this.groupBox1.Controls.Add(this.lblTimePer);
            this.groupBox1.Controls.Add(this.rdoMultiTimePer);
            this.groupBox1.Controls.Add(this.rdoSingleTimePer);
            this.groupBox1.Location = new System.Drawing.Point(327, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 129);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Periods";
            // 
            // txtNumTimePers
            // 
            this.txtNumTimePers.Enabled = false;
            this.txtNumTimePers.Location = new System.Drawing.Point(165, 99);
            this.txtNumTimePers.Name = "txtNumTimePers";
            this.txtNumTimePers.ReadOnly = true;
            this.txtNumTimePers.Size = new System.Drawing.Size(50, 20);
            this.txtNumTimePers.TabIndex = 13;
            // 
            // lblNumTimePers
            // 
            this.lblNumTimePers.AutoSize = true;
            this.lblNumTimePers.Enabled = false;
            this.lblNumTimePers.Location = new System.Drawing.Point(39, 103);
            this.lblNumTimePers.Name = "lblNumTimePers";
            this.lblNumTimePers.Size = new System.Drawing.Size(120, 13);
            this.lblNumTimePers.TabIndex = 12;
            this.lblNumTimePers.Text = "Number of Time Periods";
            // 
            // cboTimePer
            // 
            this.cboTimePer.Enabled = false;
            this.cboTimePer.FormattingEnabled = true;
            this.cboTimePer.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "30",
            "60"});
            this.cboTimePer.Location = new System.Drawing.Point(165, 71);
            this.cboTimePer.Name = "cboTimePer";
            this.cboTimePer.Size = new System.Drawing.Size(50, 21);
            this.cboTimePer.TabIndex = 11;
            this.cboTimePer.Text = "5";
            this.cboTimePer.SelectedIndexChanged += new System.EventHandler(this.cboTimePer_SelectedIndexChanged);
            // 
            // lblTimePer
            // 
            this.lblTimePer.AutoSize = true;
            this.lblTimePer.Enabled = false;
            this.lblTimePer.Location = new System.Drawing.Point(38, 74);
            this.lblTimePer.Name = "lblTimePer";
            this.lblTimePer.Size = new System.Drawing.Size(121, 13);
            this.lblTimePer.TabIndex = 10;
            this.lblTimePer.Text = "Minutes per Time Period";
            // 
            // rdoMultiTimePer
            // 
            this.rdoMultiTimePer.AutoSize = true;
            this.rdoMultiTimePer.Location = new System.Drawing.Point(18, 43);
            this.rdoMultiTimePer.Name = "rdoMultiTimePer";
            this.rdoMultiTimePer.Size = new System.Drawing.Size(179, 17);
            this.rdoMultiTimePer.TabIndex = 1;
            this.rdoMultiTimePer.Text = "Multiple Periods (2-hour duration)";
            this.rdoMultiTimePer.UseVisualStyleBackColor = true;
            this.rdoMultiTimePer.CheckedChanged += new System.EventHandler(this.rdoMultiTimePer_CheckedChanged);
            // 
            // rdoSingleTimePer
            // 
            this.rdoSingleTimePer.AutoSize = true;
            this.rdoSingleTimePer.Checked = true;
            this.rdoSingleTimePer.Location = new System.Drawing.Point(18, 20);
            this.rdoSingleTimePer.Name = "rdoSingleTimePer";
            this.rdoSingleTimePer.Size = new System.Drawing.Size(167, 17);
            this.rdoSingleTimePer.TabIndex = 0;
            this.rdoSingleTimePer.TabStop = true;
            this.rdoSingleTimePer.Text = "Single Period (1-hour duration)";
            this.rdoSingleTimePer.UseVisualStyleBackColor = true;
            // 
            // txtSysTravTimeRatio
            // 
            this.txtSysTravTimeRatio.Location = new System.Drawing.Point(518, 20);
            this.txtSysTravTimeRatio.MaxLength = 3;
            this.txtSysTravTimeRatio.Name = "txtSysTravTimeRatio";
            this.txtSysTravTimeRatio.Size = new System.Drawing.Size(50, 20);
            this.txtSysTravTimeRatio.TabIndex = 17;
            this.txtSysTravTimeRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSysTravTimeRatio.Validating += new System.ComponentModel.CancelEventHandler(this.txtSysTravTimeRatio_Validating);
            // 
            // rdoFreewayFacilities
            // 
            this.rdoFreewayFacilities.AutoSize = true;
            this.rdoFreewayFacilities.Checked = true;
            this.rdoFreewayFacilities.Location = new System.Drawing.Point(107, 22);
            this.rdoFreewayFacilities.Name = "rdoFreewayFacilities";
            this.rdoFreewayFacilities.Size = new System.Drawing.Size(108, 17);
            this.rdoFreewayFacilities.TabIndex = 19;
            this.rdoFreewayFacilities.TabStop = true;
            this.rdoFreewayFacilities.Text = "Freeway Facilities";
            this.rdoFreewayFacilities.UseVisualStyleBackColor = true;
            // 
            // rdoLinks
            // 
            this.rdoLinks.AutoSize = true;
            this.rdoLinks.Location = new System.Drawing.Point(18, 22);
            this.rdoLinks.Name = "rdoLinks";
            this.rdoLinks.Size = new System.Drawing.Size(75, 17);
            this.rdoLinks.TabIndex = 18;
            this.rdoLinks.Text = "BPR Links";
            this.rdoLinks.UseVisualStyleBackColor = true;
            this.rdoLinks.CheckedChanged += new System.EventHandler(this.rdoLinks_CheckedChanged);
            // 
            // grpProjectType
            // 
            this.grpProjectType.Controls.Add(this.rdoLinks);
            this.grpProjectType.Controls.Add(this.rdoFreewayFacilities);
            this.grpProjectType.Location = new System.Drawing.Point(24, 187);
            this.grpProjectType.Name = "grpProjectType";
            this.grpProjectType.Size = new System.Drawing.Size(219, 47);
            this.grpProjectType.TabIndex = 20;
            this.grpProjectType.TabStop = false;
            this.grpProjectType.Text = "Project Type";
            // 
            // frmProjProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 246);
            this.Controls.Add(this.grpProjectType);
            this.Controls.Add(this.txtSysTravTimeRatio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUserNotes);
            this.Controls.Add(this.lblUserNotes);
            this.Controls.Add(this.txtAnalName);
            this.Controls.Add(this.lblAnalName);
            this.Controls.Add(this.dtpAnalDate);
            this.Controls.Add(this.lblAnalDate);
            this.Controls.Add(this.txtProjTitle);
            this.Controls.Add(this.lblProjTitle);
            this.Name = "frmProjProp";
            this.Text = "XXE Project and Network Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProjProp_FormClosed);
            this.Load += new System.EventHandler(this.frmProjProp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpProjectType.ResumeLayout(false);
            this.grpProjectType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjTitle;
        private System.Windows.Forms.TextBox txtProjTitle;
        private System.Windows.Forms.Label lblAnalDate;
        private System.Windows.Forms.DateTimePicker dtpAnalDate;
        private System.Windows.Forms.Label lblAnalName;
        private System.Windows.Forms.TextBox txtAnalName;
        private System.Windows.Forms.Label lblUserNotes;
        private System.Windows.Forms.TextBox txtUserNotes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTimePer;
        private System.Windows.Forms.Label lblTimePer;
        private System.Windows.Forms.RadioButton rdoMultiTimePer;
        private System.Windows.Forms.RadioButton rdoSingleTimePer;
        private System.Windows.Forms.TextBox txtNumTimePers;
        private System.Windows.Forms.Label lblNumTimePers;
        private System.Windows.Forms.TextBox txtSysTravTimeRatio;
        private System.Windows.Forms.RadioButton rdoFreewayFacilities;
        private System.Windows.Forms.RadioButton rdoLinks;
        private System.Windows.Forms.GroupBox grpProjectType;
    }
}