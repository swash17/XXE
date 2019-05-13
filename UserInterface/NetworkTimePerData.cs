using System;
using System.Windows.Forms;
using XXE_DataStructures;


namespace XXE_UserInterface
{
    public partial class frmNetworkTimePerData : Form
    {
        /**** Fields ****/
        private NetworkData Network;

        public static bool IsOpen = false;

        public static double CellValue;
        public int _TableRow, _TableColumn;

        /**** Constructors ****/
        public frmNetworkTimePerData(NetworkData NetworkImport)
        {
            InitializeComponent();

            Network = NetworkImport;

            IsOpen = true;
        }

        private void frmNetworkTimePerData_Load(object sender, EventArgs e)
        {
            LoadNetworkTPdata();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //write table values to the network time period data array
            for (int i = 1; i <= dgvNetworkTimePerData.Rows.Count; i++)
            {
                Network.IntensityRatio[i] = Convert.ToDouble(dgvNetworkTimePerData.Rows[i - 1].Cells[1].Value);
                Network.PctUninformed[i] = Convert.ToDouble(dgvNetworkTimePerData.Rows[i - 1].Cells[2].Value);
                Network.PctInformed[i] = 100 - Network.PctUninformed[i];
            }
            CloseForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        
        private void LoadNetworkTPdata()
        {
            // Add a row for each time period.
            dgvNetworkTimePerData.Rows.Add(Network.NumTimePeriods);
            for (int timePer = 0; timePer <= dgvNetworkTimePerData.Rows.Count - 1; timePer++)
            {
                dgvNetworkTimePerData.Rows[timePer].Cells[0].Value = timePer + 1;
                dgvNetworkTimePerData.Rows[timePer].Cells[1].Value = Network.IntensityRatio[timePer + 1].ToString("0.00");
                dgvNetworkTimePerData.Rows[timePer].Cells[2].Value = Network.PctUninformed[timePer + 1].ToString();
            }
        }

        //To handle right mouse button in the cell
        private void dgvNetworkTimePerData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                _TableRow = row;
                _TableColumn = col;

                if (col >= 0)
                {
                    try
                    {
                        if (Convert.ToString(dgvNetworkTimePerData.Rows[row].Cells[col].Value).Length > 0)   //cell value may be null or ""
                        {
                            CellValue = Convert.ToDouble(dgvNetworkTimePerData.Rows[row].Cells[col].Value);
                            if (row >= 0 && col >= 0)
                            {
                                //if (dgvIntData.Rows[row].Cells[col].IsInEditMode)
                                //    dgvIntData.ContextMenuStrip = null;
                                //else
                                dgvNetworkTimePerData.ContextMenuStrip = contextMS;
                            }
                        }
                    }

                    catch { }
                }
                if (row < 0)
                {
                    try { }
                    catch { }
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                try { }
                catch { }
            }
        }

        private void tsFillDown_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = _TableRow; i < (Network.NumTimePeriods); i++)
                {
                    dgvNetworkTimePerData.Rows[i].Cells[_TableColumn].Value = CellValue.ToString();
                }
            }
            catch
            {
                MessageBox.Show("The fill down feature is not available for this variable.", "Fill Down Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNetworkTimePerData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Length must be a numeric value
            if (dgvNetworkTimePerData.Columns[e.ColumnIndex].Name == "IntensRatio")
            {
                if (!ValidateData.IsNumeric(e.FormattedValue.ToString()))
                //value is not numeric
                {
                    dgvNetworkTimePerData.Rows[e.RowIndex].ErrorText =
                        "Length be a numeric value";
                    e.Cancel = true;
                }
            }

            // From Node must be a positive integer
            if (dgvNetworkTimePerData.Columns[e.ColumnIndex].Name == "PctUninfDrivers")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvNetworkTimePerData.Rows[e.RowIndex].ErrorText =
                        "From Node must be a positive integer value";
                    e.Cancel = true;
                }
            }
        }

        private void dgvNetworkTimePerData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgvNetworkTimePerData.Rows[e.RowIndex].ErrorText = String.Empty;
        }


        private void frmNetworkTimePerData_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            MDImain.theMain.networkTimePeriodDataToolStripMenuItem_Click(null, null);
            IsOpen = false;
            this.Dispose();
        }
        
    }
}