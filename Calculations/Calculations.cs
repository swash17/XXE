using System;
using System.Collections.Generic;
using XXE_DataStructures;
using HCMCalc_Definitions;

namespace XXE_Calculations
{
    public static partial class Calculations
    {

        public static int IterNum;                              //number of iterations performed
        public static double ConvValue;                         //current convergence value               
        
        //Number of OD pairs = Number of Zones ^2 - Number of Zones (e.g., 40 zones = 1600 - 40 = 1540)
        public static List<int> ODlink = new List<int>();        
        public static List<int> DestZone = new List<int>();
        public static double[] BEI = new double[2500];  //to-do: convert to list

        public static List<int> FS = new List<int>();
        public static List<double> FL = new List<double>();
        public static List<double> NFL = new List<double>();
        public static List<double> FLX = new List<double>();
        public static List<PathData> PathFL = new List<PathData>();
        public static List<PathData> NPathFL = new List<PathData>();


        //to-do:  check the application of these 'new' variables
        public static int newODlink = new int();
        public static int newFS = new int();
        public static double newFL = new double();        
        public static double newNFL = new double();        
        public static double newFLX = new double();

        //for pathflow
        public static PathData newPathFL = new PathData();
        public static PathData newNPathFL = new PathData();
        //******

        public static int newDestZone = new int();        

        public static int NonZeroFlowLinks;
        public static double TotPhysLinks;
        public static int DriverInfo;     //loop variable for informed and uninformed drivers (uninformed = 1, informed = 2)]


        public static void RunControl(XXE_DataStructures.ProjectData Project, NetworkData network, List<LinkData> links,List<FreewayData> freewayfacilities, List<ODdata> ODpairs,List<UserEquilibriumTimePeriodResult> Results,List<List<List<double>>> RampProportionList)
        {
            network.TotTravTime = 0;
            network.TotVMT = 0;
            network.TotVC = 0;
            NonZeroFlowLinks = 0;
            TotPhysLinks = 0;
            FLX.Add(newFLX);  //create the '0' index list entry, since loop starts with index '1'

            //FileInputOutput FileIO = new FileInputOutput();

            if (Project.PrintDiagnosticResults == true)
                XXE_Calculations.FileInputOutput.OpenDiagnosticsOutput(Project.Title);

            if (network.TimePeriodType == TimePeriod.Single)
            {
                DriverInfo = 1;
                XXE_Calculations.FileInputOutput.OpenResultsFile(Project.Title);
            }
            else
            {
                DriverInfo = 2;
                XXE_Calculations.FileInputOutput.OpenTimePeriodResultsFile(Project.Title);
            }

            LinkPerformanceCalculations.InitializeBPRparms();
            if(Project.Type == ProjectType.FreewayFacilities)
            {
                GenerateCorrespondingLinks(freewayfacilities,links);
            }
            GetLinkAssignments(network, links, ODpairs);
            DeterminePhysicalLinks(network, links);

            if (Project.Type == ProjectType.FreewayFacilities)
            {
                for (int j = 1; j <= network.NumODrecords; j++)
                {
                    ODpairs[j].NumAdjTrips = Convert.ToInt64(ODpairs[j].NumTrips);
                }
                for (int n = 1; n <= network.TotalLinks; n++)
                {
                    FLX.Add(newFLX);
                    FLX[n] = 1;
                }
                UserEquilibriumMSA(Project, network, links,freewayfacilities, ODpairs,Results,RampProportionList);
            }
            else
            {
                for (int timePer = 1; timePer <= network.NumTimePeriods; timePer++)
                {
                    for (int drvInfo = 1; drvInfo <= DriverInfo; drvInfo++)
                    {
                        if (Project.PrintDiagnosticResults == true)
                            XXE_Calculations.FileInputOutput.WriteDiagnosticsTimePeriod(timePer, drvInfo);

                        for (int j = 1; j <= network.NumODrecords; j++)
                        {
                            if (drvInfo == 1)
                                ODpairs[j].NumAdjTrips = Convert.ToInt64(ODpairs[j].NumTrips * network.IntensityRatio[timePer]);
                            else
                                ODpairs[j].NumAdjTrips = Convert.ToInt64(ODpairs[j].NumTrips * (1 - (network.PctUninformed[timePer] / 100)) * network.IntensityRatio[timePer]);

                            if (Project.PrintDiagnosticResults == true)
                                XXE_Calculations.FileInputOutput.WriteDiagnosticsODtrips(j, ODpairs[j].NumAdjTrips);
                        }

                        for (int n = 1; n <= network.TotalLinks; n++)
                        {
                            if (drvInfo == 1)
                            {
                                FLX.Add(newFLX);
                                FLX[n] = 1;
                                links[n].Capacity[timePer] = links[n].Capacity[0];    //uninformed drivers do not know about capacity reductions
                            }
                            else
                            {
                                FLX.Add(newFLX);
                                FLX[n] = FL[n];
                                links[n].Capacity[timePer] = links[n].Capacity[0] * links[n].PropCap[timePer];     //XXEXQ Fortran version sets a lower bound to the link capacity ratio of 0.1
                            }

                            LinkPerformanceCalculations.SelectBPRcoeffsIndex(links[n].FreeFlowSpeed, links[n].Capacity[timePer], n, timePer);

                            if (Project.PrintDiagnosticResults == true)
                                XXE_Calculations.FileInputOutput.WriteDiagnosticsLinkCapacities(n, links[n].Capacity[timePer]);
                        }

                        //if 100% of drivers are uninformed, then skip assignment for informed drivers
                        if (!(drvInfo == 2 && network.PctUninformed[timePer] == 100))
                            UserEquilibrium(timePer, drvInfo, Project, network, links, ODpairs);

                        if (network.TimePeriodType == TimePeriod.Multiple)
                            CalcMultiTimePeriodPerformanceMeasures(timePer, drvInfo, network, links);
                    }
                }
                if (network.TimePeriodType == TimePeriod.Single)
                {
                    CalcSingleTimePeriodPerformanceMeasures(network, links);
                    for (int n = 1; n <= network.TotalLinks; n++)
                    {
                        if (network.PrintCentroidConnectors == true)
                            XXE_Calculations.FileInputOutput.WriteLinkResults(n, NFL[n], links[n].Capacity[1], links[n].vcRatio[1], links[n].FromNode, links[n].ToNode, links[n].TravTime[1], links[n].Description);
                        else
                        {
                            if (links[n].PhysLink == true)
                                XXE_Calculations.FileInputOutput.WriteLinkResults(n, NFL[n], links[n].Capacity[1], links[n].vcRatio[1], links[n].FromNode, links[n].ToNode, links[n].TravTime[1], links[n].Description);
                        }
                    }
                }
                else //(NetworkData.TimePeriodType == TimePeriod.Multiple)
                    PrintTimePeriodData(network, ref links);

                XXE_Calculations.FileInputOutput.WriteNetworkResults(network, NonZeroFlowLinks);
            }
            

        }

        public static void GenerateCorrespondingLinks(List<FreewayData> freewayFacilities, List<LinkData> links)
        {
            links.Clear();
            links.Add(new LinkData());
            LinkData link;
            foreach(FreewayData fwy in freewayFacilities)
            {
                link = new LinkData();
                link.PhysLink = fwy.PhysicalLinkXXE;
                link.FromNode = fwy.FromNode;
                link.ToNode = fwy.ToNode;
                links.Add(link);
            }            
        }

        public static void GetLinkAssignments(NetworkData network, List<LinkData> links, List<ODdata> ODpairs)
        {
            List<int> LinkFromNodes = new List<int>();  //list of ‘from’ node numbers
            int newFromNode = new int();
            LinkFromNodes.Add(newFromNode);     //create the '0' index list entry, since loop starts with index '1'
            DestZone.Add(newDestZone);          //create the '0' index list entry, since loop starts with index '1'
            FS.Add(newFS);                      //create the '0' index list entry, since loop starts with index '1'
            ODlink.Add(newODlink);              //create the '0' index list entry, since loop starts with index '1'
            int TotalLinks = links.Count - 1;
            int KX, KA, KS, KZ;


            /*  //the 'NumTransLinks' and 'irt' variables are not used for anything
            for (int i = 1; i <= NetworkData.TotalLinks; i++)
            {
                if ((Link[i].FromNode >= firstNetworkNode) || (Link[i].ToNode >= firstNetworkNode))
                {
                    NumTransLinks++;
                    irt[NumTransLinks] = i;     
                }
            }
            */

            KX = 1;
            KA = links[1].FromNode;
            for (int i = 1; i <= TotalLinks; i++)
            {
                if (links[i].FromNode != KA)    //if FromNode for link i <> FromNode for link i
                {
                    KX++;
                    KA = links[i].FromNode;
                }
                LinkFromNodes.Add(newFromNode);
                LinkFromNodes[i] = KX;
            }

            for (int i = 1; i <= TotalLinks; i++)
            {
                //LinkToNodes[i] = Link[i].ToNode;                      //this is only place this variable is used--does not appear to be needed
                for (int j = 1; j < TotalLinks; j++)
                {
                    if (links[j].FromNode == links[i].ToNode)
                        links[i].ToNode = LinkFromNodes[j];
                }
            }

            KS = 1;
            FS.Add(newFS);
            FS[1] = 1;
            for (int i = 1; i <= TotalLinks; i++)
            {
                if (LinkFromNodes[i] != KS)
                {
                    KS = LinkFromNodes[i];
                    FS.Add(newFS);
                    FS[KS] = i;
                }
            }

            KZ = LinkFromNodes[TotalLinks] + 1;
            FS.Add(newFS);
            FS[KZ] = TotalLinks + 1;

            for (int i = 1; i <= network.NumODrecords; i++)
            {
                DestZone.Add(newDestZone);
                DestZone[i] = ODpairs[i].DestZone + network.NumZones;
            }

            KS = 1;
            ODlink.Add(newODlink);
            ODlink[1] = 1;
            for (int i = 1; i <= network.NumODrecords; i++)
            {
                if (ODpairs[i].OrigZone != KS)
                {
                    KS = ODpairs[i].OrigZone;
                    ODlink.Add(newODlink);
                    ODlink[KS] = i;
                }
            }
            ODlink.Add(newODlink);
            ODlink[ODpairs[network.NumODrecords].OrigZone + 1] = network.NumODrecords + 1;
        }


        public static void DeterminePhysicalLinks(NetworkData network, List<LinkData> links)
        {
            int J1, J2;
            int FirstNodetoPrint;

            if (network.PrintCentroidConnectors == true)
                FirstNodetoPrint = 1;
            else
                FirstNodetoPrint = 2 * network.NumZones + 1;   //start with first non-centroid node

            for (int i = FirstNodetoPrint; i <= network.NumNodes; i++)
            {
                J1 = FS[i];
                J2 = FS[i + 1] - 1;
                if (J1 <= J2)
                {
                    for (int j = J1; j <= J2; j++)
                    {
                        if (links[j].ToNode >= FirstNodetoPrint)
                        {
                            TotPhysLinks++;
                            links[j].PhysLink = true;
                        }
                    }
                }
            }
        }


        public static void CalcSingleTimePeriodPerformanceMeasures(NetworkData network, List<LinkData> links)
        {
            //FileInputOutput FileIO = new FileInputOutput();

            for (int n = 1; n <= network.TotalLinks; n++)
            {
                if (links[n].PhysLink == true)
                {
                    if (FL[n] > 0)
                        NonZeroFlowLinks++;

                    links[n].vcRatio[1] = (double)(FL[n]) / (double)(links[n].Capacity[1]);
                    network.TotTravTime = network.TotTravTime + links[n].TravTime[1] * FL[n];          //units of veh-h
                    network.TotVMT = network.TotVMT + links[n].Length * FL[n];                         //units of veh-mi
                    network.TotVC = network.TotVC + links[n].vcRatio[1];
                }
            }
            network.AvgVCnonZeroFlowLinks = network.TotVC / NonZeroFlowLinks;
            network.AvgVCallPhysLinks = network.TotVC / TotPhysLinks;
        }

        public static void CalcMultiTimePeriodPerformanceMeasures(int tp, int drvInfo, NetworkData network, List<LinkData> links)
        {
            double TravTime;
            double UninformedTrafficVol, LinkVol;
            double CITY;

            if (drvInfo == 1)
            {
                //can 'NFL[i]' be substituted for 'BEI[i]' in line 381?  
                for (int i = 1; i <= network.TotalLinks; i++)
                    BEI[i] = NFL[i];
            }

            if (drvInfo == 1 && network.PctInformed[tp] > 0)
                return;

            for (int i = 1; i <= network.TotalLinks; i++)      //Do 9012 loop in Fortran code
            {
                UninformedTrafficVol = BEI[i] * (1 - network.PctInformed[tp] / 100);
                LinkVol = NFL[i];
                if (network.PctUninformed[tp] == 100)
                    LinkVol = 0;
                links[i].Flow[tp] = UninformedTrafficVol + LinkVol;

                //Link[i].Capacity[tp] = Convert.ToInt64(Link[i].Capacity[tp]) * Link[i].PropCap[tp];
                links[i].Que[tp] = 0;
                CITY = network.TravTimeAdjRatio * links[i].Capacity[tp];
                if (tp == 1)
                    TravTime = LinkPerformanceCalculations.TravTimeFcn(2, links[i].Length, CITY, links[i].FreeFlowSpeed, links[i].Flow[tp], 0, 0, links[i].Que[tp], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
                else
                    TravTime = LinkPerformanceCalculations.TravTimeFcn(2, links[i].Length, CITY, links[i].FreeFlowSpeed, links[i].Flow[tp], 0, 0, links[i].Que[tp - 1], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);

                if (tp > 1)
                {
                    if (links[i].Flow[tp] > links[i].Capacity[tp] || links[i].Que[tp - 1] != 0)
                    {
                        links[i].Que[tp] = Math.Max(links[i].Que[tp - 1] + (links[i].Flow[tp] - links[i].Capacity[tp]) / (Convert.ToDouble(network.NumTimePeriods) / 2.0), 0);
                        if (links[i].Que[tp - 1] < 0)
                            links[i].Que[tp - 1] = 0;
                    }
                }
                //**line 9013 in the course notes appears as the line just after line 8313 in the Fortran code received from Fred
                else
                {
                    if (links[i].Flow[tp] > links[i].Capacity[tp])
                        links[i].Que[tp] = Math.Max((links[i].Flow[tp] - links[i].Capacity[tp]) / (Convert.ToDouble(network.NumTimePeriods) / 2.0), 0);
                }

                if (tp == 1)
                    links[i].vcRatio[tp] = links[i].Flow[tp] / links[i].Capacity[tp];
                else
                    links[i].vcRatio[tp] = (links[i].Flow[tp] + links[i].Que[tp - 1]) / links[i].Capacity[tp];

                if (drvInfo == 2 && links[i].PhysLink == true)   //compute network statistics
                {
                    network.TotTravTime = network.TotTravTime + TravTime * links[i].Flow[tp] / (Convert.ToDouble(network.NumTimePeriods) / 2.0);
                    network.TotVMT = network.TotVMT + links[i].Length * links[i].Flow[tp] / (Convert.ToDouble(network.NumTimePeriods) / 2.0);

                    if (links[i].vcRatio[tp] < 5)
                        network.TotVC = network.TotVC + links[i].vcRatio[tp];
                    else
                        network.TotVC = network.TotVC + 5;

                    if (tp == network.NumTimePeriods)
                    {
                        network.AvgVCallPhysLinks = network.TotVC / network.NumTimePeriods / TotPhysLinks;
                        //Network.AvgVCnonZeroFlowLinks = Network.TotVC / NonZeroFlowLinks;
                    }

                }
            }
        }


        public static void PrintTimePeriodData(NetworkData network, ref List<LinkData> links)
        {
            //FileInputOutput FileIO = new FileInputOutput();

            for (int k = 1; k <= network.TotalLinks; k++)
            {
                for (int tp = 1; tp <= network.NumTimePeriods; tp++)
                {
                    if (links[k].PrintTimePerResults == true && tp == 1)
                        XXE_Calculations.FileInputOutput.WriteLinkTimePeriodHeader(k, links[k].FromNode, links[k].ToNode, links[k].Description);
                    if (links[k].PrintTimePerResults == true)
                    {
                        int TPminutes = tp * network.TotalTime / network.NumTimePeriods;
                        XXE_Calculations.FileInputOutput.WriteLinkTimePeriodResults(TPminutes, links[k].Flow[tp], links[k].Capacity[tp], links[k].vcRatio[tp], links[k].Que[tp]);
                    }
                }
            }
        }


    }
}

