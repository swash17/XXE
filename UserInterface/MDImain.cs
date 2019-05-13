using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using XXE_DataStructures;
using SwashWare_FileManagement;
using HCMCalc_Definitions;
using HCMCalc_FileInputOutput;


namespace XXE_UserInterface
{
    public partial class MDImain : Form
    {
        //public static bool AnalysisParmsFormDisplayed = false;

        public XXE_DataStructures.ProjectData Project;
        public NetworkData Network;        
        private List<LinkData> Links;
        private List<FreewayData> FreewayFacilities;
        private List<ODdata> OrigDestPairs;

        public static bool CloseFormError = false;
        public static bool FileSaveError = false;
        public static bool FileOpenError = false;

        //XXE_Calculations.FileInputOutput FileIO = new XXE_Calculations.FileInputOutput();

        public static MDImain theMain = null;

        string FileListingTitle = "XXE Network File";
        string RegistryDirectory = "Software\\XXE\\ProjectFiles";
        string RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
        string Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
        string InitialDirectory = Application.StartupPath;

        List<UserEquilibriumTimePeriodResult> myResults = new List<UserEquilibriumTimePeriodResult>();
        List<List<List<double>>> RampProportionList = new List<List<List<double>>>();//By facility, by time period, by segment

        List<FacilityVMT> FacilityVMTs = new List<FacilityVMT>();
        public MDImain(XXE_DataStructures.ProjectData ProjImport, NetworkData networkImport, List<LinkData> linksImport, List<FreewayData> freewayFacilitiesImport, List<ODdata> odPairsImport)
        {
            InitializeComponent();

            this.Text = "XXE (Mannering and Washburn)";

            Project = ProjImport;
            Network = networkImport;
            Links = linksImport;
            FreewayFacilities = freewayFacilitiesImport;
            OrigDestPairs = odPairsImport;

            theMain = this;
        }

        private void MDImain_Load(object sender, EventArgs e)
        {
            tstxtFilename.Text = Project.FileName;
            tsConvCrit.Text = Network.ConvCrit.ToString();
            tsMaxIter.Text = Network.MaxIterations.ToString();
            if (Network.PrintCentroidConnectors == true)
                tsOutputViewOption.Text = "All Links";
            else
                tsOutputViewOption.Text = "Physical Links";
            LoadProjPropFrm();
        }


        public void FileOpen(object sender, EventArgs e)
        {
            string FileName = Main.GetFilename(FileListingTitle, RegistryDirectory, RegistryPathForStoredFilenames, Filter, InitialDirectory);
            if(Project.Type == ProjectType.BPRlinks)
            {
                if (FileName != "")
                {
                    this.CloseAllToolStripMenuItem_Click(this, e);       //close currently active child forms      
                    Project.FileName = FileName;
                    tstxtFilename.Text = Project.FileName;
                    //XXE_Calculations.FileInputOutput FileIO = new XXE_Calculations.FileInputOutput();
                    XXE_Calculations.FileInputOutput.ReadXmlFile(Project.FileName, Project, Network, Links, OrigDestPairs);
                    //string ShortFileName = System.IO.Path.GetFileName(ProjectData.FileName);
                    this.Text = "XXE";
                    OpenAllDataForms();
                }

            }
            else
            {
                if (FileName != "")
                {
                    this.CloseAllToolStripMenuItem_Click(this, e);       //close currently active child forms      
                    Project.FileName = FileName;
                    tstxtFilename.Text = Project.FileName;

                    //read proejct file
                    XXE_Calculations.FileInputOutput.ReadFreewayFacilitiesProjectFile(FileName,Project,Network);
                    //read freeway facilities network file                
                    HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                    FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                    FreewayFacilities.Clear();
                    FileIOFF.ReadFreewaysFile(Project.NetworkFileName, ref ProjectFF, FreewayFacilities);
                    //test
                    for(int fwy =0; fwy<FreewayFacilities.Count; fwy++)
                    {
                        List<List<SegmentData>> tpsegs = FreewayFacilities[fwy].TPsegs;
                        FreewayData Freeway = FreewayFacilities[fwy];
                        HCMCalc_Definitions.ProjectData FFproject = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        HCMCalc_Calculations.CalculationsMain.CalcResults(FFproject, FreewayFacilities[fwy].TPsegs[0][0].NumThruLanes, ref Freeway, ref tpsegs);
                    }

                    //read od data file
                    XXE_Calculations.FileInputOutput.ReadODxmlFile(Project.ODfileName,Network, OrigDestPairs);

                    tsConvCrit.Text = Network.ConvCrit.ToString();
                    tsMaxIter.Text = Network.MaxIterations.ToString();
                    this.Text = "XXE";
                    OpenAllDataForms();
                }                                 
            }                        
        }

        private void ReadVMTfromFreewayFacilities()
        {
            FacilityVMT vmtFacility;
            for (int facility = 0; facility < FreewayFacilities.Count; facility++)
            {
                vmtFacility = new FacilityVMT();
                vmtFacility.FacilityID = FreewayFacilities[facility].Id;
                vmtFacility.FromNode = FreewayFacilities[facility].FromNode;
                vmtFacility.ToNode = FreewayFacilities[facility].ToNode;
                if (FreewayFacilities[facility].PhysicalLinkXXE == true)
                {
                    for (int timePeriod = 0; timePeriod < FreewayFacilities[facility].TPsegs.Count; timePeriod++)
                    {
                        vmtFacility.TimePeriodVMT.Add(FreewayFacilities[facility].Results[timePeriod].VehMilesTravVolume);
                    }
                    vmtFacility.TotalVMT = vmtFacility.TimePeriodVMT[0];
                    for (int segment = 1; segment < FreewayFacilities[facility].TPsegs[0].Count - 1; segment++)
                    {
                        double TotalVMTperSegment = 0;
                        for (int tp = 1; tp < FreewayFacilities[facility].TPsegs.Count; tp++)
                        {
                            TotalVMTperSegment += FreewayFacilities[facility].TPsegs[tp][segment].Results.VehMilesTravVolume;
                        }
                        vmtFacility.SegmentVMT.Add(TotalVMTperSegment);
                    }
                    FacilityVMTs.Add(vmtFacility);
                }
                else
                {
                    FacilityVMTs.Add(vmtFacility);
                }
            }
        }
      
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (Project.FileName == "untitled.xml")  //invoke SaveAs dialog
                FileSaveAs();
            else
                FileSave();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project.FileName == "untitled.xml")  //invoke SaveAs dialog
                FileSaveAs();
            else
                FileSave();

        }

        private DialogResult SaveDataQuery()
        {
            //ask user if they want to save any current data before starting a new file, opening a file, or exiting app
            DialogResult DiagRes = MessageBox.Show("Save current project before closing? ", "XXE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (DiagRes == DialogResult.Yes)
            {
                FileSaveAs();
            }
            return DiagRes;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveAs();
        }

        private void FileSave()  //do a direct save to currently named file
        {
            try
            {
                if(Project.Type == ProjectType.BPRlinks)
                {
                    XXE_Calculations.FileInputOutput.WriteXmlFile(Project.FileName, Project, Network, Links, OrigDestPairs);
                    FileSaveError = false;
                    frmFileSaveSummary FileSaveSummary = new frmFileSaveSummary();
                    FileSaveSummary.ShowDialog();
                }
                else
                {
                    //save freeway facilities file
                    HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                    FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                    FileIOFF.WriteFreewaysFile(Project.NetworkFileName, false, true, ProjectFF, FreewayFacilities);

                    //save OD data file
                    XXE_Calculations.FileInputOutput.WriteODdataFile(Project.ODfileName, OrigDestPairs);

                    //save project file
                    XXE_Calculations.FileInputOutput.WriteFreewayFacilitiesProjectFile(Project.FileName, Project,Network);
                }
             

            }
            catch
            {
                MessageBox.Show("One or more data input cells do not contain a valid entry.  File cannot be saved at this time.", "Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileSaveError = true;
            }
        }

        private void FileSaveAs()
        {
            try
            {
                if(Project.Type == ProjectType.BPRlinks)
                {
                    string FileName = Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);

                    if (FileName != "")
                    {
                        Project.FileName = FileName;
                        XXE_Calculations.FileInputOutput.WriteXmlFile(Project.FileName, Project, Network, Links, OrigDestPairs);
                        tstxtFilename.Text = Project.FileName;
                        FileSaveError = false;
                        frmFileSaveSummary FileSaveSummary = new frmFileSaveSummary();
                        FileSaveSummary.ShowDialog();

                    }
                }
                else
                {
                    FileListingTitle = "XXE Network File";
                    RegistryDirectory = "Software\\XXE\\ProjectFiles";
                    RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
                    Filter = "Network Files (*.net)|*.xml|All Files (*.*)|*.*";
                    InitialDirectory = Application.StartupPath;
                    string FileName = "";
                    if (Project.NetworkFileName == "untitled.xml")
                    {
                        //save freeway facilities file                      
                        FileName = Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);
                        if (FileName != "")
                        {
                            HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                            FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                            Project.NetworkFileName = FileName;
                            FileIOFF.WriteFreewaysFile(FileName, false, true, ProjectFF, FreewayFacilities);

                        }
                    }
                    else
                    {
                        HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
                        FileIOFF.WriteFreewaysFile(Project.NetworkFileName, false, true, ProjectFF, FreewayFacilities);
                    }
                    
                    if(Project.ODfileName == "untitled.xml")
                    {
                        //save OD data file
                        FileListingTitle = "XXE OD Data File";
                        RegistryDirectory = "Software\\XXE\\ProjectFiles";
                        RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
                        Filter = "OD Files (*.od)|*.xml|All Files (*.*)|*.*";
                        InitialDirectory = Application.StartupPath;
                        FileName = Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);
                        if (FileName != "")
                        {
                            Project.ODfileName = FileName;
                            XXE_Calculations.FileInputOutput.WriteODdataFile(FileName, OrigDestPairs);

                        }
                    }
                    else
                    {
                        XXE_Calculations.FileInputOutput.WriteODdataFile(Project.ODfileName, OrigDestPairs);
                    }
                    
                    //save project file
                    FileListingTitle = "XXE Network File";
                    RegistryDirectory = "Software\\XXE\\ProjectFiles";
                    RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
                    Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                    InitialDirectory = Application.StartupPath;
                    FileName = Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);
                    if(FileName != "")
                    {
                        XXE_Calculations.FileInputOutput.WriteFreewayFacilitiesProjectFile(FileName, Project,Network);
                       
                    }
                }


            }
            catch
            {
                MessageBox.Show("One or more data input cells do not contain a valid entry.  File cannot be saved at this time.", "Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileSaveError = true;
            }

        }

        public void OpenAllDataForms()
        {
            System.EventArgs g = new System.EventArgs();
            if (frmProjProp.IsOpen == false)
                this.LoadProjPropFrm();
            this.linkDataToolStripMenuItem_Click(this, g);
            this.originDestinationDataToolStripMenuItem_Click(this, g);
            if (Network.TimePeriodType == TimePeriod.Multiple)
                this.networkTimePeriodDataToolStripMenuItem_Click(this, g);

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        public void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                //childForm.Close();
                childForm.Dispose();
            }
        }

        private void FileNew(object sender, EventArgs e)
        {
            DialogResult UserResponse = SaveDataQuery();    //ask user if they want to save any current data
            if (UserResponse == DialogResult.Cancel || FileSaveError == true)
            {
                FileSaveError = false;  //reset
                return;
            }

            CloseActiveForm();
            if (CloseFormError == true)
                return;

            InitializeValues();     //reset data structure
            LoadProjPropFrm();
        }

        public void projectPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProjPropFrm();
        }

        private void LoadProjPropFrm()
        {
            if (frmProjProp.IsOpen == false)    //skip if form is already open
            {
                projectPropertiesToolStripMenuItem.Checked = true;
                projectPropertiesToolStripMenuItem.Enabled = false;
                // load the project properties child form
                frmProjProp frmProp = new frmProjProp(Project, Network);
                // Make it a child of this MDI form before showing it.
                frmProp.MdiParent = this;
                frmProp.Text = "Project Properties";
                frmProp.Show();
            }
            else
            {
                projectPropertiesToolStripMenuItem.Checked = false;
                projectPropertiesToolStripMenuItem.Enabled = true;
            }
        }

        public void linkDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLinkData.IsOpen == false)
            {
                linkDataToolStripMenuItem.Checked = true;
                linkDataToolStripMenuItem.Enabled = false;
                // Create a new instance of the Link Data child form.
                frmLinkData frmLnkDat = new frmLinkData(Project,ref Network, ref Links,ref FreewayFacilities);
                // Make it a child of this MDI form before showing it.
                frmLnkDat.MdiParent = this;
                frmLnkDat.Text = "Node-Link Data";
                frmLnkDat.Show();
            }
            else
            {
                linkDataToolStripMenuItem.Checked = false;
                linkDataToolStripMenuItem.Enabled = true;
            }
        }

        public void originDestinationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmOrigDest.IsOpen == false)
            {
                originDestinationDataToolStripMenuItem.Checked = true;
                originDestinationDataToolStripMenuItem.Enabled = false;
                // Create a new instance of the OD Data child form.
                frmOrigDest frmODdat = new frmOrigDest(ref Network, ref OrigDestPairs,Project);
                // Make it a child of this MDI form before showing it.
                frmODdat.MdiParent = this;
                frmODdat.Text = "Origin-Destination Data";
                frmODdat.Show();
            }
            else
            {
                originDestinationDataToolStripMenuItem.Checked = false;
                originDestinationDataToolStripMenuItem.Enabled = true;
            }
        }

        public void networkTimePeriodDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmNetworkTimePerData.IsOpen == false)
            {
                networkTimePeriodDataToolStripMenuItem.Checked = true;
                networkTimePeriodDataToolStripMenuItem.Enabled = false;
                // Create a new instance of the child form.
                frmNetworkTimePerData frmNetworkTPdata = new frmNetworkTimePerData(Network);
                // Make it a child of this MDI form before showing it.
                frmNetworkTPdata.MdiParent = this;
                frmNetworkTPdata.Text = "Network Time Period Data";
                frmNetworkTPdata.Show();
            }
            else
            {
                networkTimePeriodDataToolStripMenuItem.Checked = false;
                networkTimePeriodDataToolStripMenuItem.Enabled = true;
            }
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (AnalysisParmsFormDisplayed == false)
            {
                AnalysisParmsFormDisplayed = true;
                // Create a new instance of the child form.
                frmAnalParm frmParm = new frmAnalParm(Network);
                // Make it a child of this MDI form before showing it.
                frmParm.MdiParent = this;
                frmParm.Text = "Analysis Parameters";
                frmParm.Show();
            }
            */ 
        }

        private void viewInputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            frmBrowser frmBrowse = new frmBrowser();
            // Make it a child of this MDI form before showing it.
            frmBrowse.MdiParent = this;
            frmBrowse.Text = "Input Data File";
            frmBrowse.Show();
            //frmBrowse.DisplayFileInBrowswer("G:\\test.xml");
            frmBrowse.DisplayFileInBrowswer(Project.FileName);
            
        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            frmResults frmRes = new frmResults(Network.TimePeriodType);
            // Make it a child of this MDI form before showing it.
            frmRes.MdiParent = this;
            frmRes.Text = "Results";
            frmRes.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            frmAboutBox frmAbout = new frmAboutBox();
            // Make it a child of this MDI form before showing it.
            frmAbout.MdiParent = this;
            frmAbout.Text = "About XXE";
            frmAbout.Show();
        }

        private void tsbRunAnalysis_Click(object sender, EventArgs e)
        {
            if (Network.NumODrecords != 0 && Network.TotalLinks != 0)
            {
                Network.ConvCrit = Convert.ToDouble(tsConvCrit.Text);
                Network.MaxIterations = Convert.ToInt32(tsMaxIter.Text);
                if(tsOutputViewOption.Text == "All Links")
                    Network.PrintCentroidConnectors = true;
                else
                    Network.PrintCentroidConnectors = false;

                tsbRunStatus.Text = "Running...";
                SaveFreewayFacilitiesList();
                List<FreewayData> UEfreewayFacilities = new List<FreewayData>();
                if(Project.Type == ProjectType.FreewayFacilities)
                {
                    ReadFreewayFacilitiesList(UEfreewayFacilities);
                    RampProportionList = GenerateInitialRampProportionTimePeriodList();
                }
                
                myResults = new List<UserEquilibriumTimePeriodResult>();
                //List<PathData> PathFlowResults = new List<PathData>();
                XXE_Calculations.Calculations.RunControl(Project, Network, Links, UEfreewayFacilities, OrigDestPairs,myResults, RampProportionList);
                tsbRunStatus.Text = "Analysis Complete";
                if(Project.Type == ProjectType.BPRlinks)
                {
                    viewResultsToolStripMenuItem_Click(null, null);
                }
                else if (Project.Type == ProjectType.FreewayFacilities)
                {
                    int firstPhysicalNode = Network.FirstNetworkNode;
                    int numOfNodes = Network.NumNodes;
                    frmUEresultsFreewayfacilities myResultsForm = new frmUEresultsFreewayfacilities(myResults, UEfreewayFacilities,OrigDestPairs,firstPhysicalNode,numOfNodes,Network.WithFreewayFacilityFiles);
                    myResultsForm.MdiParent = this;
                    myResultsForm.Show();
                }
                
            }
            else
                MessageBox.Show("Invalid Input Data. Link-Node and/or O-D Data are Missing.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void SaveFreewayFacilitiesList()
        {
            HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
            FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
            FileIOFF.WriteFreewaysFile(Project.NetworkFileName, false, true, ProjectFF, FreewayFacilities);
        }

        private void ReadFreewayFacilitiesList(List<FreewayData> FreewayFacilities)
        {
            HCMCalc_Definitions.ProjectData ProjectFF = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
            FreewayFacilityIO FileIOFF = new FreewayFacilityIO();
            FreewayFacilities.Clear();
            FileIOFF.ReadFreewaysFile(Project.NetworkFileName, ref ProjectFF, FreewayFacilities);
        }

        private List<List<List<double>>> GenerateInitialRampProportionTimePeriodList()
        {
            List<List<List<double>>> RampProportionList = new List<List<List<double>>>(); //By facility, by time period, by segment
            List<List<double>> TimePeriodProportionList;
            List<double> SegmentProportionList;
            for (int i = 1; i <= Network.TotalLinks; i++)
            {
                List<List<SegmentData>> TPSegs = FreewayFacilities[i - 1].TPsegs;
                TimePeriodProportionList = new List<List<double>>();
                for (int tp = 1; tp < TPSegs.Count; tp++)
                {
                    SegmentProportionList = new List<double>();
                    for (int seg = 1; seg < TPSegs[tp].Count; seg++)
                    {
                        double proportion = 0;
                        if (TPSegs[tp][seg].SegTypeInput == SegmentType.OnRamp)
                        {
                            proportion = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                            SegmentProportionList.Add(proportion);
                        }
                        else if (TPSegs[tp][seg].SegTypeInput == SegmentType.OffRamp)
                        {
                            proportion = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                            SegmentProportionList.Add(proportion);
                        }
                        else if (TPSegs[tp][seg].SegTypeInput == SegmentType.Weaving)
                        {
                            proportion = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                            SegmentProportionList.Add(proportion);
                            proportion = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                            SegmentProportionList.Add(proportion);
                            proportion = TPSegs[tp][seg].Weave.Inputs.RampToRampDemandVeh / TPSegs[tp][1].DemandVeh;
                            SegmentProportionList.Add(proportion);
                        }
                    }
                    TimePeriodProportionList.Add(SegmentProportionList);
                }
                RampProportionList.Add(TimePeriodProportionList);
            }
           
            return RampProportionList;
        }

        private void tsConvCrit_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateData.IsNumeric(tsConvCrit.Text))
            //value is not a number
            {
                MessageBox.Show("Invalid Input Data. Convergence Criterion must be a numeric value.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void tsMaxIter_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateData.IsUInt16(tsMaxIter.Text))
            //value is not a postive integer
            {
                MessageBox.Show("Invalid Input Data. Maximum number of iterations must be a postive integer.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string UserGuideFullPath = Application.StartupPath + "\\XXE Users Guide.pdf";
            //System.Diagnostics.Process.Start("AcroRd32.exe", UserGuideFullPath);
            Process AdobeReader = new Process();

            try
            {
                //AdobeReader.StartInfo.FileName = "AcroRd32.exe";
                AdobeReader.StartInfo.FileName = "iexplore.exe";
                AdobeReader.StartInfo.Arguments = UserGuideFullPath;
                AdobeReader.Start();
                AdobeReader.Close();
            }
            catch
            {
                MessageBox.Show("Internet Explorer must be installed on the local machine.", "Acrobat Reader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseActiveForm()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDImain_FormClosing(null, null);
        }

        private void MDImain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult UserResponse = SaveDataQuery();    //ask user if they want to save any current data
            if (UserResponse == DialogResult.Cancel || FileSaveError == true)
            {
                FileSaveError = false;  //reset
                e.Cancel = true;
            }
        }

        private void MDImain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //call the form closing event first to tidy up any loose ends, like saving data
            this.Dispose();
            Application.Exit();
        }


        private void InitializeValues()
        {
            Project = new XXE_DataStructures.ProjectData();
            Network = new NetworkData();            

        }

                                                         
        
     }
}
