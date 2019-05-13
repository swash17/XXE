using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XXE_DataStructures;
using SwashWare_FileManagement;
using HCMCalc_Definitions;

namespace XXE_UserInterface
{
    public partial class frmSplashScreen : Form
    {
        /**** Fields ****/
        
        XXE_DataStructures.ProjectData Project = new XXE_DataStructures.ProjectData();
        NetworkData Network = new NetworkData();

        //XXE_Calculations.FileInputOutput FileIO = new XXE_Calculations.FileInputOutput();

        List<LinkData> Links = new List<LinkData>();
        List<FreewayData> FreewayFacilities = new List<FreewayData>();
        List<ODdata> OrigDestPairs = new List<ODdata>();
        LinkData NewLink = new LinkData();
        FreewayData NewFreewayFacility = new FreewayData();
        ODdata NewODpair = new ODdata();
        string FileListingTitle = "TTR UE Project Files";
        string RegistryDirectory = "Software\\TTR_UE\\ProjectFiles";
        string RegistryPathForStoredFilenames = "Software\\TTR_UE\\ProjectFiles\\MostRecentlyUsedFiles";
        string Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
        string InitialDirectory = Application.StartupPath;

        public frmSplashScreen()   //(ProjectData ProjImport, NetworkData NetworkImport, List<LinkData> LinkArrImport, List<ODdata> ODArrImport)
        {
            InitializeComponent();

            Links.Add(NewLink);
            //FreewayFacilities.Add(NewFreewayFacility); //just to be consistent with the links
            //NewFreewayFacility.TPsegs = new List<List<SegmentData>>();
            //NewFreewayFacility.TPsegs.Add(new List<SegmentData>());
            //NewFreewayFacility.TPsegs[0].Add(new SegmentData(SegmentType.Basic));
            OrigDestPairs.Add(NewODpair);

            //Project = ProjImport;
            //Network = NetworkImport;
            //Links = LinkArrImport;
            //ODArr = ODArrImport;
        }

        private void btnStartNewProj_Click(object sender, EventArgs e)
        {
            //unload splash screen
            this.Hide();
            // load MDI form
            MDImain frmMDI = new MDImain(Project, Network, Links,FreewayFacilities, OrigDestPairs);            
            frmMDI.Show();
        }

        private void btnOpenExistProj_Click(object sender, EventArgs e)
        {
            string FileName = Main.GetFilename(FileListingTitle, RegistryDirectory, RegistryPathForStoredFilenames, Filter, InitialDirectory);
            if (FileName != "")
            {
                Project.FileName = FileName;
                XXE_Calculations.FileInputOutput.ReadXmlFile(FileName, Project, Network, Links, OrigDestPairs);
                //unload splash screen
                this.Hide();
                // Load MDI form
                MDImain frmMDI = new MDImain(Project, Network, Links,FreewayFacilities, OrigDestPairs);
                frmMDI.Show();
                MDImain.theMain.OpenAllDataForms();
            }
        }

        
    }
}