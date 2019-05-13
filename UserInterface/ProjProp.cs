using System;
using System.ComponentModel;
using System.Windows.Forms;
using XXE_DataStructures;


namespace XXE_UserInterface
{
    public partial class frmProjProp : Form
    {

        /**** Fields ****/
        private ProjectData Project;
        private NetworkData Network;
        public static bool DataSaved = false;
        public static bool IsOpen = false;

        /**** Constructors ****/
        public frmProjProp(ProjectData ProjImport, NetworkData NetworkImport)
        {
            InitializeComponent();

            Project = ProjImport;
            Network = NetworkImport;

            IsOpen = true;

            //System.EventArgs g = new System.EventArgs();
            //frmProjProp_Load(this, g);
        }

        private void frmProjProp_Load(object sender, EventArgs e)
        {
            LoadProjData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Save data input on form
                Project.Title = txtProjTitle.Text;
                Project.AnalDate = Convert.ToDateTime(dtpAnalDate.Value);
                Project.AnalName = txtAnalName.Text;
                Project.UserNotes = txtUserNotes.Text;
                if (rdoSingleTimePer.Checked == true)
                    Network.TimePeriodType = TimePeriod.Single;
                else
                    Network.TimePeriodType = TimePeriod.Multiple;
                Network.TimePeriodSize = Convert.ToInt16(cboTimePer.Text);
                Network.NumTimePeriods = Convert.ToInt16(txtNumTimePers.Text);
                
                frmProjProp_FormClosed(null, null);
                DataSaved = true;

                if (rdoLinks.Checked == true)
                    Project.Type = ProjectType.BPRlinks;
                else
                    Project.Type = ProjectType.FreewayFacilities;
            }
            catch
            {
                MessageBox.Show("Data cannot be saved. Check data entries.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataSaved = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //do not save data changes
            frmProjProp_FormClosed(null, null);
        }

        private Boolean LoadProjData()
        {
            if (Project == null)
            {
                return false;
            }
            else
            {
                try
                {
                    txtProjTitle.Text = Project.Title;
                    dtpAnalDate.Value = Project.AnalDate;
                    txtAnalName.Text = Project.AnalName;
                    txtUserNotes.Text = Project.UserNotes;
                    txtSysTravTimeRatio.Text = Network.TravTimeAdjRatio.ToString("0.0");
                    Network.TravTimeAdjRatio = Convert.ToDouble(txtSysTravTimeRatio.Text);
                    if (Network.TimePeriodType == TimePeriod.Single)
                        rdoSingleTimePer.Checked = true;
                    else
                        rdoMultiTimePer.Checked = true;
                    cboTimePer.Text = Network.TimePeriodSize.ToString();
                    txtNumTimePers.Text = Network.NumTimePeriods.ToString();
                    DataSaved = true;
                    return true;
                }
                catch
                {
                    MessageBox.Show("Invalid Project Properties Data. Please check your saved data file for invalid entries and try again.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void rdoMultiTimePer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMultiTimePer.Checked == true)
            {
                lblTimePer.Enabled = true;
                cboTimePer.Enabled = true;
                lblNumTimePers.Enabled = true;
                txtNumTimePers.Enabled = true;
                cboTimePer.Text = "5";
                txtNumTimePers.Text = "24";
                Network.TimePeriodType = TimePeriod.Multiple;
                Network.TotalTime = 120;
            }
            else   //single time period
            {
                lblTimePer.Enabled = false;
                cboTimePer.Enabled = false;
                lblNumTimePers.Enabled = false;
                txtNumTimePers.Enabled = false;
                cboTimePer.Text = "60";
                txtNumTimePers.Text = "1";
                Network.TimePeriodType = TimePeriod.Single;
                Network.TotalTime = 60;
            }
        }

        private void cboTimePer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumTimePers.Text = (Network.TotalTime / Convert.ToInt32(cboTimePer.Text)).ToString();
        }

        private void txtSysTravTimeRatio_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateData.IsNumeric(txtSysTravTimeRatio.Text))
            //value is not a number
            {
                MessageBox.Show("Invalid Input Data. System travel time adjustment ratio must be a numeric value.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void frmProjProp_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDImain.theMain.projectPropertiesToolStripMenuItem_Click(null, null);
            IsOpen = false;
            this.Dispose();
        }

        private void rdoLinks_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLinks.Checked == true)
            {
                Project.Type = ProjectType.BPRlinks;
            }
            else
            {
                Project.Type = ProjectType.FreewayFacilities;
            }

        }
    }
}