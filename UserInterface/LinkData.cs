using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using XXE_DataStructures;
using HCMCalc_Definitions;
using HCMCalc_FreewayFacility;
using HCMCalc_FileInputOutput;


namespace XXE_UserInterface
{
    public partial class frmLinkData : Form
    {
        
        /**** Fields ****/
        private NetworkData Network;
        private List<LinkData> Links;
        private List<FreewayData> FreewayFacilities;
        private XXE_DataStructures.ProjectData Project;

        //XXE_Calculations.FileInputOutput FileIO = new XXE_Calculations.FileInputOutput();

        public static bool DataSaved = false;   //True if data have been successfully saved to the data structure
        public static bool CellDataError = true;
        public static bool DataCurrent = true;  //Used to track whether the user has made a change to a cell since the last data save
        public static bool IsOpen = false;

        string FileName = "";
        string FileListingTitle = "XXE Network File";
        string RegistryDirectory = "Software\\XXE\\ProjectFiles";
        string RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
        string Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
        string InitialDirectory = Application.StartupPath;

        /**** Constructors ****/
        public frmLinkData(XXE_DataStructures.ProjectData ProjectImport,ref NetworkData NetworkImport,ref List<LinkData> LinkArrImport, ref List<FreewayData> FreewayFacilitiesImportFF)
        {
            InitializeComponent();

            Network = NetworkImport;
            Links = LinkArrImport;
            FreewayFacilities = FreewayFacilitiesImportFF;
            Project = ProjectImport;

            IsOpen = true;
            
        }

        private void frmLinkData_Load(object sender, EventArgs e)
        {
            dgvLinkData.Rows.Clear();
            // Attach DataGridView events to the corresponding event handlers.
            this.dgvLinkData.CellValidating += new
                DataGridViewCellValidatingEventHandler(dgvLinkData_CellValidating);
            this.dgvLinkData.CellEndEdit += new
                DataGridViewCellEventHandler(dgvLinkData_CellEndEdit);
            this.dgvLinkData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            if (Network.TimePeriodType == TimePeriod.Single)
            {
                dgvLinkData.Columns["PrintTimePerData"].Visible = false;
                dgvLinkData.Columns["AddTimePerData"].Visible = false;
                dgvLinkData.Columns["EditTimePerData"].Visible = false;
            }
            else
            {
                dgvLinkData.Columns["PrintTimePerData"].Visible = true;
                dgvLinkData.Columns["AddTimePerData"].Visible = true;
                dgvLinkData.Columns["EditTimePerData"].Visible = true;
            }
            
            if(Project.Type == ProjectType.BPRlinks)
            {
                dgvLinkData.Columns["colFreewayFacilities"].Visible = false;
                dgvLinkData.Columns["colPhysicalLink"].Visible = false;
                dgvLinkData.Columns["Capacity"].Visible = true;
                dgvLinkData.Columns["Length"].Visible = true;
                dgvLinkData.Columns["FFS"].Visible = true;
                dgvLinkData.Columns["FFTravTime"].Visible = true;
                dgvLinkData.Columns["Descrip"].Visible = true;
                dgvLinkData.Columns["colCheckBoundaries"].Visible = false;
            }
            else
            {
                dgvLinkData.Columns["colFreewayFacilities"].Visible = true;
                dgvLinkData.Columns["colPhysicalLink"].Visible = true;
                dgvLinkData.Columns["Capacity"].Visible = false;
                dgvLinkData.Columns["Length"].Visible = false;
                dgvLinkData.Columns["FFS"].Visible = false;
                dgvLinkData.Columns["FFTravTime"].Visible = false;
                dgvLinkData.Columns["Descrip"].Visible = false;
                dgvLinkData.Columns["colCheckBoundaries"].Visible = true;
            }
            LoadLinkData();
        }

        private void tsbSaveLinkData_Click(object sender, EventArgs e)
        {
            bool DataSaved = SaveLinkData();
            if (DataSaved == true)
                MessageBox.Show("Data successfully saved.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(Project.Type == ProjectType.FreewayFacilities)
            {
                FileListingTitle = "XXE OD Data File";
                RegistryDirectory = "Software\\XXE\\ProjectFiles";
                RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
                Filter = "Network Files (*.xml)|*.xml|All Files (*.*)|*.*";
                InitialDirectory = Application.StartupPath;
                FileName = SwashWare_FileManagement.Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);
                if (FileName != "")
                {
                    HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                    FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                    FileIOFF.WriteFreewaysFile(FileName,false, true, ProjectFF, FreewayFacilities);
                    Project.NetworkFileName = FileName;
                }
            }

        }

        private Boolean SaveLinkData()
        {

            //write table values to the LinkArr
           
            Network.TotalLinks = 0;
            try
            {
                if (Project.Type == ProjectType.BPRlinks)
                {
                    for (int i = 1; i <= dgvLinkData.Rows.Count; i++)
                    {
                        Links[i].FromNode = Convert.ToInt32(dgvLinkData.Rows[i - 1].Cells[0].Value);   //change to int16?
                        Links[i].ToNode = Convert.ToInt32(dgvLinkData.Rows[i - 1].Cells[1].Value);     //change to int16?
                        Links[i].Capacity[0] = Convert.ToInt32(dgvLinkData.Rows[i - 1].Cells[2].Value);
                        Links[i].Length = Convert.ToDouble(dgvLinkData.Rows[i - 1].Cells[3].Value);
                        Links[i].FreeFlowSpeed = Convert.ToDouble(dgvLinkData.Rows[i - 1].Cells[4].Value);
                        Links[i].Description = dgvLinkData.Rows[i - 1].Cells[6].Value.ToString();
                        if (Network.TimePeriodType == TimePeriod.Multiple)
                        {
                            Links[i].PrintTimePerResults = Convert.ToBoolean(dgvLinkData.Rows[i - 1].Cells[7].Value);
                            Links[i].TimePerData = Convert.ToBoolean(dgvLinkData.Rows[i - 1].Cells[8].Value);
                        }
                        Network.TotalLinks++;
                    }
                    Network.FirstNetworkNode = Convert.ToInt32(tsFirstNode.Text);
                    Network.NumNodes = Convert.ToInt32(tsTotNodes.Text);    // LinkData.TotalLinks - (2 * ProjectData.NumZones) - 1;
                    Network.NumZones = (Network.FirstNetworkNode - 1) / 2;
                    DataSaved = true;
                    DataCurrent = true;
                    return true;
                }
                else
                {
                    for (int i = 0; i < dgvLinkData.Rows.Count; i++)
                    {
                       
                        if(dgvLinkData.Rows[i].Cells[colPhysicalLink.Name].EditedFormattedValue.ToString() == "Yes")
                        {
                            FreewayFacilities[i].PhysicalLinkXXE = true;
                        }
                        else
                        {                                              
                            FreewayFacilities[i] = InitializeFreewayData();
                            FreewayFacilities[i].PhysicalLinkXXE = false;
                        }
                        FreewayFacilities[i].Id = (byte)(i + 1);
                        FreewayFacilities[i].FromNode = Convert.ToInt32(dgvLinkData.Rows[i].Cells[0].Value);
                        FreewayFacilities[i].ToNode = Convert.ToInt32(dgvLinkData.Rows[i].Cells[1].Value);
                        Network.TotalLinks++;
                    }
                    Network.FirstNetworkNode = Convert.ToInt32(tsFirstNode.Text);
                    Network.NumNodes = Convert.ToInt32(tsTotNodes.Text);    // LinkData.TotalLinks - (2 * ProjectData.NumZones) - 1;
                    Network.NumZones = (Network.FirstNetworkNode - 1) / 2;
                    DataSaved = true;
                    DataCurrent = true;
                    return true;
                }
                
                
            }
            catch
            {
                MessageBox.Show("Data cannot be saved. Check data entry cells with a yellow background and/or red font.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataSaved = false;
                DataCurrent = false;
                return false;
            }
        }

        private FreewayData InitializeFreewayData()
        {
            FreewayData fwy = new FreewayData();
            fwy.TPsegs = new List<List<SegmentData>>();
            List<SegmentData> SegData;
            //------------ From HCM-CALC; eventually replace with call to method in HCM-CALC -----------------------//
            //time period zero
            MainlineOutputs newTimePeriodFreewayResults = new MainlineOutputs();
            fwy.Results.Add(newTimePeriodFreewayResults);

            SegData = new List<SegmentData>();
            //add first dummy segment
            SegData.Add(new SegmentData(SegmentType.Basic));
            //add first real segment
            SegData.Add(new SegmentData(SegmentType.Basic));
            SegData[1].isZero = true;
            //add last dummy segment; currently needed for oversaturated analysis
            SegData.Add(new SegmentData(SegmentType.Basic));

            fwy.TPsegs.Add(SegData);  //adding zero time period

            //time period 1
            newTimePeriodFreewayResults = new MainlineOutputs();
            fwy.Results.Add(newTimePeriodFreewayResults);

            SegData = new List<SegmentData>();
            //add first dummy segment
            SegData.Add(new SegmentData(SegmentType.Basic));
            //add first real segment
            SegData.Add(new SegmentData(SegmentType.Basic));
            //add last dummy segment; currently needed for oversaturated analysis
            SegData.Add(new SegmentData(SegmentType.Basic));

            fwy.TPsegs.Add(SegData);  //adding first time period

            fwy.TotalTimePeriods = 1;
            fwy.TotalSegs = 1;
            //------------------------------------------------------------------------------------------//
            return fwy;
        }
        private Boolean LoadLinkData()
        {
            if(Project.Type == ProjectType.BPRlinks)
            {
                if ((Links == null) || (Network.TotalLinks == 0))
                {
                    LinkData NewLink = new LinkData();
                    Links.Add(NewLink);
                    dgvLinkData.Rows.Add(1);
                    //for (int i = 0; i < dgvLinkData.Columns.Count; i++)
                    //    dgvLinkData.Rows[0].Cells[i].Style.BackColor = Color.Yellow;

                    return false;
                }
                else
                {
                    try
                    {
                        dgvLinkData.Rows.Add(Network.TotalLinks);
                        for (int i = 1; i <= Network.TotalLinks; i++)
                        {
                            dgvLinkData.Rows[i - 1].Cells[0].Value = Links[i].FromNode.ToString();
                            dgvLinkData.Rows[i - 1].Cells[1].Value = Links[i].ToNode.ToString();
                            dgvLinkData.Rows[i - 1].Cells[2].Value = Links[i].Capacity[0].ToString();
                            dgvLinkData.Rows[i - 1].Cells[3].Value = Links[i].Length.ToString();
                            if (Links[i].FreeFlowSpeed > 4)
                                dgvLinkData.Rows[i - 1].Cells[4].Value = Links[i].FreeFlowSpeed.ToString();
                            else //pedestrian speeds are being used
                                dgvLinkData.Rows[i - 1].Cells[4].Value = Links[i].FreeFlowSpeed.ToString("0.00");
                            dgvLinkData.Rows[i - 1].Cells[5].Value = (Convert.ToDouble(dgvLinkData.Rows[i - 1].Cells[3].Value) / Convert.ToDouble(dgvLinkData.Rows[i - 1].Cells[4].Value)).ToString("0.0000");
                            dgvLinkData.Rows[i - 1].Cells[6].Value = Links[i].Description;
                            if (Network.TimePeriodType == TimePeriod.Multiple)
                            {
                                dgvLinkData.Rows[i - 1].Cells[7].Value = Links[i].PrintTimePerResults;
                                dgvLinkData.Rows[i - 1].Cells[8].Value = Links[i].TimePerData;
                            }
                        }
                        tsFirstNode.Text = Network.FirstNetworkNode.ToString();
                        tsTotNodes.Text = Network.NumNodes.ToString();
                        //set cell background colors to white for valid data
                        tsFirstNode.BackColor = Color.White;
                        tsTotNodes.BackColor = Color.White;
                        dgvLinkData.DefaultCellStyle.BackColor = Color.White;
                        dgvLinkData.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                        DataSaved = true;
                        DataCurrent = true;
                        return true;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input Data. Check your saved data file for invalid entries and try again.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                if (FreewayFacilities == null || FreewayFacilities.Count == 0)
                {
                    FreewayData NewFreewayFacility = InitializeFreewayData();
                    FreewayFacilities.Add(NewFreewayFacility);
                    dgvLinkData.Rows.Add(1);
                    return false;
                }
                else
                {
                    try
                    {
                        dgvLinkData.Rows.Clear();
                        Network.TotalLinks = FreewayFacilities.Count;
                        dgvLinkData.Rows.Add(Network.TotalLinks);
                        for (int i = 0; i < Network.TotalLinks; i++)
                        {
                            dgvLinkData.Rows[i].Cells[0].Value = FreewayFacilities[i].FromNode.ToString();
                            dgvLinkData.Rows[i].Cells[1].Value = FreewayFacilities[i].ToNode.ToString();
                            if(FreewayFacilities[i].PhysicalLinkXXE == true)
                            {
                                dgvLinkData.Rows[i].Cells[colPhysicalLink.Name].Value = "Yes"; 
                            }
                            else
                            {
                                dgvLinkData.Rows[i].Cells[colPhysicalLink.Name].Value = "No";
                            }
                           
                        }
                        tsFirstNode.Text = Network.FirstNetworkNode.ToString();
                        tsTotNodes.Text = Network.NumNodes.ToString();
                        //set cell background colors to white for valid data
                        tsFirstNode.BackColor = Color.White;
                        tsTotNodes.BackColor = Color.White;
                        dgvLinkData.DefaultCellStyle.BackColor = Color.White;
                        dgvLinkData.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                        DataSaved = true;
                        DataCurrent = true;
                        return true;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input Data. Check your saved data file for invalid entries and try again.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
         
        }

        private void tsbCopyLinkData_Click(object sender, EventArgs e)
        {
            if (this.dgvLinkData.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(this.dgvLinkData.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed. Please try again.", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbPasteLinkData_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Clipboard.GetDataObject();  // Retrieve the contents of the clipboard.
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = dgvLinkData.CurrentCell.RowIndex;
                int col = dgvLinkData.CurrentCell.ColumnIndex;
                foreach (string line in lines)
                {
                    if (row < dgvLinkData.RowCount && line.Length > 0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            if (col + i < this.dgvLinkData.ColumnCount)
                            {
                                dgvLinkData[col + i, row].Value = Convert.ChangeType(cells[i], dgvLinkData[col + i, row].ValueType);
                            }
                            else
                            {
                                break;
                            }
                        }
                        row++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show("The Clipboard could not be accessed. Please try again.", "Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsFirstNode_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateData.IsUInt16(tsFirstNode.Text))
            //value is not a postive integer
            {
                tsFirstNode.ForeColor = Color.Red;
                tsFirstNode.BackColor = Color.Yellow;
                CellDataError = true;
            }
            else
                CellDataError = false;
        }

        private void tsTotNodes_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateData.IsUInt16(tsTotNodes.Text))
            //value is not a postive integer
            {
                tsTotNodes.ForeColor = Color.Red;
                tsTotNodes.BackColor = Color.Yellow;
                CellDataError = true;
            }
            else
                CellDataError = false;
        }

        private void tsFirstNode_Validated(object sender, EventArgs e)
        {
            if (CellDataError == false)
            {
                tsFirstNode.ForeColor = Color.Black;
                tsFirstNode.BackColor = Color.White;
            }
        }

        private void tsTotNodes_Validated(object sender, EventArgs e)
        {
            if (CellDataError == false)
            {
                tsTotNodes.ForeColor = Color.Black;
                tsTotNodes.BackColor = Color.White;
            }
        }

        private void dgvLinkData_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
        {
            // Validate the values input into the fields

            // From Node must be a positive integer
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "FromNode")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }
            // To Node must be a positive integer
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "ToNode")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }
            // Length must be a numeric value
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "Length")
            {
                if (!ValidateData.IsNumeric(e.FormattedValue.ToString()))
                //value is not numeric
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }
            // Capacity must be a positive integer
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "Capacity")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }          
            // Free flow speed must be a positive integer
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "FFS")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }

            // Do not allow description entry to be empty
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "Descrip")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }
        }

        private void dgvLinkData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //calculate free flow travel time
            if (dgvLinkData.Columns[e.ColumnIndex].Name == "FFS")
            {
                try
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[5].Value = (Convert.ToDouble(dgvLinkData.Rows[e.RowIndex].Cells[3].Value) / Convert.ToDouble(dgvLinkData.Rows[e.RowIndex].Cells[4].Value)).ToString("0.0000");
                }
                catch
                {
                    dgvLinkData.Rows[e.RowIndex].Cells[5].Value = "NaN";
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                }
            }
            if (CellDataError == false)
            {
                dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvLinkData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataCurrent = false;
        }
        private void tsFirstNode_TextChanged(object sender, EventArgs e)
        {
            DataCurrent = false;
        }
        private void tsTotNodes_TextChanged(object sender, EventArgs e)
        {
            DataCurrent = false;
        }
        private void dgvIntData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //dgvLinkData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
        }

        private void dgvLinkData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgvLinkData.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void tsbDiscardLinkDataChanges_Click(object sender, EventArgs e)
        {
            //discard changes to table and unload form
            DialogResult DiagRes = MessageBox.Show("Close form without saving data?", "XXE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DiagRes == DialogResult.Yes)
            {
                CloseForm();
            }
        }

        private void GetTimePeriodData(TimePeriodData[] tpdArrCopy, int rowIndex)
        {
            for (int timePer = 1; timePer <= Network.NumTimePeriods; timePer++)
            {
                //LinkArr2[i].tpdArr[i].LinkNum = tpdArrCopy[i].LinkNum;
                Links[rowIndex].PropCap[timePer] = tpdArrCopy[timePer].PropCap;
            }
        }

        private void dgvLinkData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Paint the row number on the row header.
            // The using statement automatically disposes the brush.
            using (SolidBrush b = new SolidBrush(dgvLinkData.RowHeadersDefaultCellStyle.ForeColor))
            {
                int RowNum = e.RowIndex + 1;   //RowIndex starts at zero
                e.Graphics.DrawString(RowNum.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void tsbAddLink_Click(object sender, EventArgs e)
        {
            /*
            int NumLinks = dgvLinkData.Rows.Count;  //get number of entered links
            if (NumLinks == 1000) //maximum, based on 500 nodes (roughly nodes * 2)
            {
                MessageBox.Show("The number of entered links is limited to a maximum of 1000.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            dgvLinkData.Rows.Add(1);
            for (int i = 0; i < dgvLinkData.Columns.Count; i++)
                dgvLinkData.Rows[dgvLinkData.Rows.Count-1].Cells[i].Style.BackColor = Color.Yellow;
            if (dgvLinkData.Rows.Count > 1)
                tsbDeleteLink.Enabled = true;

            if(Project.Type == ProjectType.BPRlinks)
            {
                LinkData NewLink = new LinkData();
                Links.Add(NewLink);
            }
            else
            {
                FreewayData NewFreewayFacility = new FreewayData();
                FreewayFacilities.Add(NewFreewayFacility);
            }
        

        }
        private void tsbInsertLink_Click(object sender, EventArgs e)
        {
            /*
            int NumLinks = dgvLinkData.Rows.Count;  //get number of entered links
            if (NumLinks == 1000) //maximum, based on 500 nodes (roughly nodes * 2)
            {
                MessageBox.Show("The number of entered links is limited to a maximum of 1000.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            try
            {
                //insert a new link between two current links
                int SelectedRow = dgvLinkData.SelectedRows[0].Index;
                dgvLinkData.Rows.Insert(SelectedRow, 1);
                if (dgvLinkData.Rows.Count > 1)
                    tsbDeleteLink.Enabled = true;
                for (int i = 0; i < dgvLinkData.Columns.Count; i++)
                    dgvLinkData.Rows[SelectedRow].Cells[i].Style.BackColor = Color.Yellow;
                if(Project.Type == ProjectType.BPRlinks)
                {
                    LinkData NewLink = new LinkData();
                    Links.Insert(SelectedRow, NewLink);
                }
                else
                {
                    FreewayData NewFreewayFacility = new FreewayData();
                    FreewayFacilities.Insert(SelectedRow, NewFreewayFacility);
                }
             

            }
            catch
            {
                MessageBox.Show("To insert a row, you must select a row by clicking on the row number on the left-hand side of the grid.  The new row will be inserted above this row selection.",
                    "Row Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDeleteLink_Click(object sender, EventArgs e)
        {
            try
            {
                //delete the link at the selected position
                int SelectedRow = dgvLinkData.SelectedRows[0].Index;
                if (SelectedRow != dgvLinkData.Rows.Count)
                {
                    dgvLinkData.Rows.RemoveAt(SelectedRow);
                    if(Project.Type == ProjectType.BPRlinks)
                        Links.RemoveAt(SelectedRow + 1);
                    else
                        FreewayFacilities.RemoveAt(SelectedRow + 1);
                }
                    
                if (dgvLinkData.Rows.Count < 2)
                    tsbDeleteLink.Enabled = false;
            }
            catch
            {
                MessageBox.Show("To delete a row, you must select the link by clicking on the row number on the left-hand side of the grid.", "Row Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbLoadLinkData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "DAT Files (*.dat)|*.dat|XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                if(Project.Type == ProjectType.BPRlinks)
                {
                    XXE_Calculations.FileInputOutput.ReadNWDatFile(FileName, Network, Links);
                    Project.NetworkFileName = FileName;
                    for (int i = 1; i <= Network.TotalLinks; i++)
                    {
                        object[] NewRow = new object[] { Links[i].FromNode, Links[i].ToNode, Links[i].Capacity[0], Links[i].Length, Links[i].FreeFlowSpeed, (Links[i].Length / Links[i].FreeFlowSpeed).ToString("0.0000"), Links[i].Description };
                        dgvLinkData.Rows.Add(NewRow);
                    }
                }
                else
                {
                    if (FileName != "")
                    {
                        HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                        FreewayFacilities.Clear();
                        FileIOFF.ReadFreewaysFile(FileName,ref ProjectFF, FreewayFacilities);
                        Project.NetworkFileName = FileName;
                        LoadLinkData();
                    }
                }
            }
        }

        private void dgvLinkData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && dgvLinkData.Columns["PrintTimePerData"].Visible == true) //Print Time Period Results check box column
                                                                                               //check for visible column corrects bug where program crashes if user selects the 'Description' column on the right edge
            {
                // Force the update of the value for the checkbox column.
                // Without this, the value doens't get updated until you move off from the cell.
                dgvLinkData.Rows[e.RowIndex].Cells[6].Value = (bool)dgvLinkData.Rows[e.RowIndex].Cells[6].EditedFormattedValue;

                bool CheckValue = (bool)dgvLinkData.Rows[e.RowIndex].Cells[6].Value;
                if (CheckValue == true)
                    Links[e.RowIndex + 1].PrintTimePerResults = true;
                else
                    Links[e.RowIndex + 1].PrintTimePerResults = false;
            }

            if (e.ColumnIndex == 7) //Add Time Period Data check box column
            {
                dgvLinkData.Rows[e.RowIndex].Cells[7].Value = (bool)dgvLinkData.Rows[e.RowIndex].Cells[7].EditedFormattedValue;

                bool CheckValue = (bool)dgvLinkData.Rows[e.RowIndex].Cells[7].Value;
                if (CheckValue == true)
                {
                    Links[e.RowIndex + 1].TimePerData = true;   //set time period data flag to true
                    Network.NumRestrictedLinks++;
                }
                else
                {
                    Links[e.RowIndex + 1].TimePerData = false;
                    Network.NumRestrictedLinks--;
                }

                //** have check box interact with enabling of edit link in next column
            }

            if (e.ColumnIndex == 8) //Edit Time Period Data Link      
            {
                // Create a new instance of the modal form.
                frmLinkTimePerData frmTPdata = new frmLinkTimePerData(Network, Links);
                int RowIndex = e.RowIndex + 1;
                int FromNode = Convert.ToInt32(dgvLinkData.Rows[e.RowIndex].Cells[0].Value);
                int ToNode = Convert.ToInt32(dgvLinkData.Rows[e.RowIndex].Cells[1].Value);

                GetTimePeriodData(frmTPdata.ShowDialog(RowIndex, FromNode, ToNode, this), RowIndex);
            }

            if(Project.Type == ProjectType.FreewayFacilities)
            {
                if (e.ColumnIndex == 11) //Open FreewayFacilities module
                {
                    if (dgvLinkData.Rows[e.RowIndex].Cells[colPhysicalLink.Name].EditedFormattedValue.ToString() == "Yes")
                    {
                        if(FreewayFacilities[e.RowIndex].TPsegs == null)
                        {                           
                            FreewayFacilities[e.RowIndex] = InitializeFreewayData();                   
                        }

                        HCMCalc_Definitions.ProjectData project = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        mdiMain MDIform = new mdiMain(project, FreewayFacilities[e.RowIndex], FreewayFacilities[e.RowIndex].TPsegs);
                        MDIform.ShowDialog();
                    }

                }
                else if (e.ColumnIndex == 12) //Check freeway facility boundary
                {
                    if(FreewayFacilities[e.RowIndex].PhysicalLinkXXE == true)
                    {
                        //!!!!
                        //save freeway facilities first
                        FileListingTitle = "XXE OD Data File";
                        RegistryDirectory = "Software\\XXE\\ProjectFiles";
                        RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
                        Filter = "Network Files (*.xml)|*.xml|All Files (*.*)|*.*";
                        InitialDirectory = Application.StartupPath;
                        HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                        FileIOFF.WriteFreewaysFile(Project.NetworkFileName, false, true, ProjectFF, FreewayFacilities);

                        //load into boundary form

                        FreewayFacility myFreewayFacilityForm = new FreewayFacility(FreewayFacilities[e.RowIndex]);
                        myFreewayFacilityForm.ShowDialog();

                        //!!!
                        //reload freeway facilities, cause TPsegs change in the volume assignment process
                        FreewayFacilities.Clear();
                        FileIOFF.ReadFreewaysFile(Project.NetworkFileName, ref ProjectFF, FreewayFacilities);
                        LoadLinkData();
                        //!!!
                    }

                }
            }
           
        }


        private void frmLinkData_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ask user if they want to save the current data before closing form, if any data items have not been changed since last data save
            if (DataCurrent == false)
            {
                DialogResult DiagRes = MessageBox.Show("Save link-node data before closing? ", "XXE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DiagRes == DialogResult.Yes)
                {
                    bool DataSaved = SaveLinkData();
                    if (DataSaved == false)
                        e.Cancel = true;
                }
                else if (DiagRes == DialogResult.No)
                { }
                else if (DiagRes == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmLinkData_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            //MDImain.theMain.linkDataToolStripMenuItem.Checked = false;
            MDImain.theMain.linkDataToolStripMenuItem_Click(null, null);
            IsOpen = false;
            this.Dispose();
            //this.Hide();
        }

                
                         
    }
}