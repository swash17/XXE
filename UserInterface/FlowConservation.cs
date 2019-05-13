using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XXE_DataStructures;
using HCMCalc_Definitions;

namespace XXE_UserInterface
{
    public partial class FlowConservation : Form
    {
        List<FreewayData> FreewayFacilities;
        List<ODdata> ODs;
        List<int> PhysicalNodes = new List<int>();
        int FirstPhysicalNode = 0;
        int NumOfNodes = 0;
        List<NodeFlowConservation> NodeFlowConservations = new List<NodeFlowConservation>();
        List<UserEquilibriumTimePeriodResult> UEresults = new List<UserEquilibriumTimePeriodResult>();
        int TimePeriodIndex = 0;
        public FlowConservation(List<UserEquilibriumTimePeriodResult> myResultsImport, List<FreewayData> freewayFacilitiesImport, List<ODdata> ODimport, int firstPhysicalNode, int numOfNodes)
        {
            InitializeComponent();
            UEresults = myResultsImport;
            FreewayFacilities = freewayFacilitiesImport;
            ODs = ODimport;
            FirstPhysicalNode = firstPhysicalNode;
            NumOfNodes = numOfNodes;
            UpdateTimePeriodList();
            GetFlowConservationList();
            DisplayDataGridView();
        }

        private void GetFlowConservationList()
        {
            NodeFlowConservations.Clear();
            GetPhysicalNodes();
            foreach(int n in PhysicalNodes)
            {
                NodeFlowConservation nodeConservation = new NodeFlowConservation();
                GetNodeConservation(n,nodeConservation);
                NodeFlowConservations.Add(nodeConservation);
            }
        }

        private void GetNodeConservation(int node, NodeFlowConservation nodeConservation)
        {
            nodeConservation.Node = node;
            List<int> ConnectedLinks = new List<int>();
            double LinkFlow = 0;
            double ODFlow =0;
            foreach (LinkResult result in UEresults[TimePeriodIndex].LinkResults)
            {
                if(result.PhysLink == true)
                {
                    if (result.FromNode == node)
                    {
                        nodeConservation.ConnectedLinks.Add(result.ID);
                        LinkFlow -= result.Volume;
                    }
                    else if (result.ToNode == node)
                    {
                        nodeConservation.ConnectedLinks.Add(result.ID);
                        LinkFlow += result.Volume;
                    }
                }
                
            }
            nodeConservation.FlowLink = LinkFlow;
            int numZones = (FirstPhysicalNode - 1) / 2;
            int connectedZone = 0;
            foreach (FreewayData link in FreewayFacilities)
            {               
                if (link.FromNode == node || link.ToNode == node)
                {
                    if(link.FromNode <= numZones ||link.ToNode <= numZones)
                    {                      
                        if(link.FromNode <= numZones)
                        {
                            nodeConservation.Type = 1; //1: OD node
                            connectedZone = link.FromNode;
                            break;
                        }
                        else if (link.ToNode <= numZones)
                        {
                            nodeConservation.Type = 1; //1: OD node
                            connectedZone = link.ToNode;
                            break;
                        }                        
                    }
                }
                
            }
            if(nodeConservation.Type == 1)
            {
                foreach(ODdata od in ODs)
                {
                    if(od.OrigZone == connectedZone || od.DestZone == connectedZone)
                    {
                        int[] zonePair = new int[2];
                        zonePair[0] = od.OrigZone;
                        zonePair[1] = od.DestZone;
                        nodeConservation.ConnectedZones.Add(zonePair);
                        if(od.OrigZone == connectedZone)
                        {
                            ODFlow -= od.NumTrips;
                        }
                        else
                        {
                            ODFlow += od.NumTrips;
                        }
                    }                 
                }
                
            }
            nodeConservation.FlowOD = ODFlow;

        }

        
        private void GetPhysicalNodes()
        {
            PhysicalNodes.Clear();
            for (int n = FirstPhysicalNode; n<= NumOfNodes; n++)
            {
                PhysicalNodes.Add(n);
            }
        }


        private void UpdateTimePeriodList()
        {
            cboChartTimePeriod.Items.Clear();
            for (int n = 0; n < UEresults.Count; n++)
            {
                cboChartTimePeriod.Items.Add(n + 1);
            }
        }

        private void DisplayDataGridView()
        {
            dgvConservationFlow.Rows.Clear();
            if (NodeFlowConservations.Count>0)
            {
                int Rows = NodeFlowConservations.Count;
                dgvConservationFlow.Rows.Add(Rows);
                for(int row =0; row < Rows; row++)
                {
                    dgvConservationFlow.Rows[row].Cells[colNode.Name].Value = NodeFlowConservations[row].Node;
                    string type = "Transition Node";
                    if(NodeFlowConservations[row].Type == 1)
                    {
                        type = "OD Node";
                    }                 
                    dgvConservationFlow.Rows[row].Cells[colType.Name].Value = type;
                    dgvConservationFlow.Rows[row].Cells[colODflow.Name].Value = NodeFlowConservations[row].FlowOD.ToString("0");
                    dgvConservationFlow.Rows[row].Cells[colLinkFlow.Name].Value = NodeFlowConservations[row].FlowLink.ToString("0");
                    string ODlist = "";
                    for(int n = 0; n<NodeFlowConservations[row].ConnectedZones.Count; n++)
                    {
                        if (n == 0)
                        {
                            ODlist = NodeFlowConservations[row].ConnectedZones[n][0].ToString() + "-" + NodeFlowConservations[row].ConnectedZones[n][1].ToString();
                        }
                        else
                        {
                            ODlist += " , " + NodeFlowConservations[row].ConnectedZones[n][0].ToString() + "-" + NodeFlowConservations[row].ConnectedZones[n][1].ToString();
                        }                   
                    }
                    dgvConservationFlow.Rows[row].Cells[colODs.Name].Value = ODlist;

                    string Linklist = "";
                    for(int n =0; n < NodeFlowConservations[row].ConnectedLinks.Count; n++)
                    {
                        if (n == 0)
                        {
                            Linklist = NodeFlowConservations[row].ConnectedLinks[n].ToString();
                        }
                        else
                        {
                            Linklist += " , " + NodeFlowConservations[row].ConnectedLinks[n].ToString();
                        }
                    }
                    dgvConservationFlow.Rows[row].Cells[colLinks.Name].Value = Linklist;
                }
            }
        }

        private void cboChartTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimePeriodIndex = cboChartTimePeriod.SelectedIndex;
            GetFlowConservationList();
            DisplayDataGridView();
        }
    }
}
