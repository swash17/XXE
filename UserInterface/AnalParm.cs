using System;
using System.Windows.Forms;
using XXE_DataStructures;

namespace XXE_UserInterface
{
    public partial class frmAnalParm : Form
    {

        /**** Fields ****/
        private NetworkData Network;

        public frmAnalParm(NetworkData NetworkImport)
        {
            InitializeComponent();

            Network = NetworkImport;
        }

        private void frmAnalParm_Load(object sender, EventArgs e)
        {
            LoadParameters();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Network.ConvCrit = Convert.ToDouble(txtConvCrit.Text);
            Network.MaxIterations = Convert.ToInt32(txtMaxIter.Text);
            Network.FirstNetworkNode = Convert.ToInt32(txtFirstNetworkNode.Text);
            Network.NumZones = (Network.FirstNetworkNode - 1) / 2;
            Network.NumNodes = Convert.ToInt32(txtNumNodes.Text);  // LinkData.TotalLinks - (2 * ProjectData.NumZones) - 1;
            this.Hide();
        }       

        private void LoadParameters()
        {
            txtConvCrit.Text = Network.ConvCrit.ToString();
            txtMaxIter.Text = Network.MaxIterations.ToString();
            txtFirstNetworkNode.Text = Network.FirstNetworkNode.ToString();
            txtNumNodes.Text = Network.NumNodes.ToString();
            chkPrintCentroids.Checked = Network.PrintCentroidConnectors;
        }

        private void chkPrintCentroids_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintCentroids.Checked == true)
                Network.PrintCentroidConnectors = true;
            else
                Network.PrintCentroidConnectors = false;
        }

        private void chkPrintTimePeriods_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkPrintCentroids.Checked == true)
            //    Network.PrintTimePeriodData = true;
            //else
            //    Network.PrintTimePeriodData = false;
        }

        private void frmAnalParm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            //IsOpen = false;
            this.Dispose();
        }

        
    }
}