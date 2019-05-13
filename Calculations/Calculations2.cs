using System;
using System.Collections.Generic;
using XXE_DataStructures;
using HCMCalc_Definitions;


namespace XXE_Calculations
{
    public static partial class Calculations
    {       

        public static void UserEquilibrium(int tp, int dInfo, XXE_DataStructures.ProjectData project, NetworkData network, List<LinkData> links, List<ODdata> OD)
        {
            //FileInputOutput FileIO = new FileInputOutput();
            double[,] ShortPath = new double[299, 299];
            double[,] ShortPath1 = new double[299, 299];
            double ObjFcn;  //value of BPR function
            bool SolutionConverged = false;
            double DeltaFlows;
            double D;
            FL.Add(newFL);  //create the '0' index list entry, since loop starts with index '1'
            PathFL.Add(newPathFL); //create the '0' index list entry, since loop starts with index '1'

            //initialize shortest path from each origin to each destination to zero
            for (int i = 1; i <= network.NumZones; i++)
            {
                for (int j = 1; j <= network.NumZones + 1; j++)
                {
                    ShortPath[j, i] = 0;
                    ShortPath1[j, i] = 0;
                }
            }

            AllOrNothing(tp, dInfo, network.NumZones, network.NumNodes, FL, PathFL,network, links, OD, ref ShortPath);
            if (project.PrintDiagnosticResults == true)
                XXE_Calculations.FileInputOutput.WriteDiagnosticsLinkFlows("AllOrNothing--Base", NFL, network.TotalLinks);

            IterNum = 0;
            ObjFcn = 0;
            for (int i = 1; i <= network.TotalLinks; i++)
            {
                if (tp > 1)
                    ObjFcn = ObjFcn + LinkPerformanceCalculations.IntegratedTravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, FL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp], LinkPerformanceCalculations.alphaInt[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
                else
                    ObjFcn = ObjFcn + LinkPerformanceCalculations.IntegratedTravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, FL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp-1], LinkPerformanceCalculations.alphaInt[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
            }

            for (int i = 1; i <= network.NumZones; i++)
            {
                for (int j = 1; j <= network.NumZones; j++)
                {
                    ShortPath1[i, j] = ShortPath[i, j];

                    if (project.PrintDiagnosticResults == true)
                        XXE_Calculations.FileInputOutput.WriteDiagnosticsShortestPaths(i, j, ShortPath1);
                }
            }

            ConvValue = 2 * network.ConvCrit;   //initialize convergence value

            do
            {                
                AllOrNothing(tp, dInfo, network.NumZones, network.NumNodes, NFL, NPathFL,network, links, OD, ref ShortPath);

                if (project.PrintDiagnosticResults == true)
                    XXE_Calculations.FileInputOutput.WriteDiagnosticsLinkFlows("AllOrNothing-Iteration", NFL, network.TotalLinks);

                Bisection(tp, dInfo, 0, 1, network.ConvCrit, network, ref links);

                if (project.PrintDiagnosticResults == true)
                    XXE_Calculations.FileInputOutput.WriteDiagnosticsLinkFlows("Bisection", NFL, network.TotalLinks);

                ConvValue = 0;
                ObjFcn = 0;
                for (int i = 1; i <= network.TotalLinks; i++)
                {
                    if (tp > 1)
                        ObjFcn = ObjFcn + LinkPerformanceCalculations.IntegratedTravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, NFL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp], LinkPerformanceCalculations.alphaInt[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
                    else
                        ObjFcn = ObjFcn + LinkPerformanceCalculations.IntegratedTravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, NFL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp - 1], LinkPerformanceCalculations.alphaInt[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
            
                    DeltaFlows = Math.Abs(NFL[i] - FL[i]);      //difference between previous set of flows and current set of flows
                    if (DeltaFlows != 0)
                    {
                        D = NFL[i];
                        if(D==0)
                            D = FL[i];
                        ConvValue = ConvValue + DeltaFlows/D;
                        FL.Add(newFL);
                        FL[i] = NFL[i];  
                    }
                }

                //path flow
                for(int i = 1; i < NPathFL.Count; i++)
                {
                    DeltaFlows = Math.Abs(NPathFL[i].Volume - PathFL[i].Volume);
                    if (DeltaFlows != 0)
                    {                   
                        PathFL[i] = NPathFL[i];
                    }
                }
               
                ConvValue = ConvValue / network.TotalLinks;
                if (ConvValue <= network.ConvCrit)
                    SolutionConverged = true;
                IterNum++;

            } while ((SolutionConverged == false) && (IterNum < network.MaxIterations));
        }

        public static List<PathData> GetPathResults()
        {
             
            return PathFL;
        }

        private static void GetAllPaths(List<PathData> Paths,NetworkData network, List<LinkData> links, List<ODdata> OD)
        {
            Graph g = new Graph(network.NumNodes - network.FirstNetworkNode + 1);
            ConstructGraph(g, links, network.FirstNetworkNode);
            for (int od = 1; od < OD.Count; od++) //the first od item has no values
            {
                int PathFromNode = ZoneToNode(OD[od].OrigZone, links);
                int PathToNode = ZoneToNode(OD[od].DestZone, links);
                if (PathFromNode > 0 && PathToNode > 0)
                {
                    g.PathList = new List<List<int>>();
                    GetPathsFromOD(g, PathFromNode, PathToNode, network.FirstNetworkNode);
                    int NumPaths = g.PathList.Count;
                    if (NumPaths > 0)
                    {
                        foreach(List<int> path in g.PathList)
                        {
                            PathData p = new PathData();
                            p.OrigZone = OD[od].OrigZone;
                            p.DestZone = OD[od].DestZone;
                            p.Nodes = path;
                            p.Volume = 0;
                            Paths.Add(p);
                        }
                    }
                }
            }
        }

        private static void ConstructGraph(Graph g, List<LinkData> links,int firstPhysicalNode)
        {
            for(int link =0; link< links.Count; link++)
            {
                if(links[link].PhysLink == true)
                    g.addEdge(links[link].FromNode- firstPhysicalNode, links[link].ToNode- firstPhysicalNode);
            }
        }
        private static void GetPathsFromOD(Graph g,int orig, int dest, int firstPhysicalNode)
        {
            g.getAllPaths(orig- firstPhysicalNode, dest- firstPhysicalNode, firstPhysicalNode);
            //List<List<int>> paths = g.PathList;
        }
      
        public static void UserEquilibriumMSA(XXE_DataStructures.ProjectData project, NetworkData network, List<LinkData> links, List<FreewayData> freewayfacilities,List<ODdata> OD,List<UserEquilibriumTimePeriodResult> results, List<List<List<double>>> RampProportionList)
        {
            Graph g = new Graph(network.NumNodes - network.FirstNetworkNode + 1);
            ConstructGraph(g, links, network.FirstNetworkNode);            


            int numTPs = 1;
            for (int n =0; n<freewayfacilities.Count; n++)
            {
                if(freewayfacilities[n].PhysicalLinkXXE == true)
                {
                    numTPs = freewayfacilities[n].TotalTimePeriods;
                }
            }
            UserEquilibriumTimePeriodResult timePeriodResult;


            for (int tp = 1; tp<= numTPs; tp++)
            {
                timePeriodResult = new UserEquilibriumTimePeriodResult();
                Iteration iteration;
                double[,] ShortPath = new double[299, 299];
                double[,] ShortPath1 = new double[299, 299];
                double ObjFcn;  //value of BPR function
                bool SolutionConverged = false;
                double DeltaFlows;
                double D;
                FL.Clear();
                FL.Add(newFL);                      //create the '0' index list entry, since loop starts with index '1'
                List<List<ODvolume>> ODvolumeLists = new List<List<ODvolume>>();
                //initialize shortest path from each origin to each destination to zero
                for (int i = 1; i <= network.NumZones; i++)
                {
                    for (int j = 1; j <= network.NumZones + 1; j++)
                    {
                        ShortPath[j, i] = 0;
                        ShortPath1[j, i] = 0;
                    }
                }

                AllOrNothingMSA(tp, network.NumZones, network.NumNodes, FL, network, links, freewayfacilities, OD, RampProportionList, ODvolumeLists, ref ShortPath);
                IterNum = 0;

                ObjFcn = 0;

                for (int i = 1; i <= network.TotalLinks; i++)
                {
                    ObjFcn = ObjFcn + HCM_FF_Method.TravTimeFcnFreewayFacilities(RampProportionList[i - 1], freewayfacilities[i - 1], tp, FL[i]);
                }

                for (int i = 1; i <= network.NumZones; i++)
                {
                    for (int j = 1; j <= network.NumZones; j++)
                    {
                        ShortPath1[i, j] = ShortPath[i, j];
                    }
                }

                ConvValue = 2 * network.ConvCrit;   //initialize convergence value

                do
                {
                    IterNum++;
                    AllOrNothingMSA(tp, network.NumZones, network.NumNodes, NFL, network, links, freewayfacilities, OD,RampProportionList, ODvolumeLists, ref ShortPath);
                    MoveMSA(network, IterNum + 1);
                    ConvValue = 0;
                    ObjFcn = 0;

                    List<double> TravelTimes = new List<double>();
                    
                    for (int i = 1; i <= network.TotalLinks; i++)
                    {
                        double travelTime = HCM_FF_Method.TravTimeFcnFreewayFacilities(RampProportionList[i - 1], freewayfacilities[i - 1], tp, FL[i]);

                        ObjFcn = ObjFcn + travelTime*FL[i];
                        //TravelTimes.Add(travelTime);

                        DeltaFlows = Math.Abs(NFL[i] - FL[i]);      //difference between previous set of flows and current set of flows
                        if (DeltaFlows != 0)
                        {
                            D = NFL[i];
                            if (D == 0)
                                D = FL[i];
                            ConvValue = ConvValue + DeltaFlows / D;
                            FL.Add(newFL);
                            FL[i] = NFL[i];
                        }

                        TravelTimes.Add(HCM_FF_Method.TravTimeFcnFreewayFacilities(RampProportionList[i - 1], freewayfacilities[i - 1], tp, FL[i]));
                    }

                    ConvValue = ConvValue / network.TotalLinks;
                    iteration = new Iteration();
                    iteration.ObjFunction = ObjFcn;
                    iteration.IternationNum = IterNum;
                    iteration.ConvergeValue = ConvValue;
                    IterationLinkVolume linkVolume;
                    for (int n = 1; n <= network.TotalLinks; n++)
                    {
                        if (links[n].PhysLink == true)
                        {
                            linkVolume = new IterationLinkVolume();
                            linkVolume.ID = n;
                            linkVolume.FromNode = links[n].FromNode;
                            linkVolume.ToNode = links[n].ToNode;
                            linkVolume.Volume = FL[n];
                            linkVolume.PhysLink = links[n].PhysLink;                          
                            iteration.LinkVolumes.Add(linkVolume);
                        }                       
                    }
                    timePeriodResult.TimePeriod = tp;
                    timePeriodResult.Iterations.Add(iteration);
                    timePeriodResult.IsConverged = false;

                    if (ConvValue <= network.ConvCrit || IterNum == network.MaxIterations)
                    {
                        if (ConvValue <= network.ConvCrit)
                        {
                            SolutionConverged = true;
                            timePeriodResult.IsConverged = true;
                        }
                        
                        timePeriodResult.NumIterations = IterNum;
                        timePeriodResult.ConvergenceValue = ConvValue;
                        timePeriodResult.ObjFunctionValue = ObjFcn;
                        timePeriodResult.LinkResults.Clear();
                        LinkResult result;
                        for (int n = 1; n <= network.TotalLinks; n++)
                        {
                            if (links[n].PhysLink == true)
                            {
                                result = new LinkResult();
                                result.ID = n;
                                result.FromNode = links[n].FromNode;
                                result.ToNode = links[n].ToNode;
                                result.Volume = FL[n];
                                result.PhysLink = links[n].PhysLink;
                                result.TravelTime = TravelTimes[n - 1];
                                result.VehMilesTravVolume = freewayfacilities[n - 1].Results[tp].VehMilesTravVolume;
                                result.VehMilesTravDemand = freewayfacilities[n - 1].Results[tp].VehMilesTravDemand;
                                result.VehHoursTrav = freewayfacilities[n - 1].Results[tp].VehHoursTrav;
                                result.VehHoursDelay = freewayfacilities[n - 1].Results[tp].VehHoursDelay;
                                result.DensityVeh = freewayfacilities[n - 1].Results[tp].DensityVeh;
                                result.AvgSpeed = freewayfacilities[n - 1].Results[tp].AvgSpeed;
                                result.DensityPC = freewayfacilities[n - 1].Results[tp].DensityPC;
                                result.SegmentTravelTimes = GetSegmentTravelTimes(freewayfacilities[n-1].TPsegs[tp]); 
                                if (freewayfacilities[n - 1].PhysicalLinkXXE == true)
                                {
                                    result.FreeFlowTravelTime = freewayfacilities[n - 1].Results[tp].TravTimeFreeFlow;
                                    timePeriodResult.LinkResults.Add(result);
                                }
                            }                                                           
                        }
                    }

                } while ((SolutionConverged == false) && (IterNum < network.MaxIterations));

                for(int od = 1; od < OD.Count; od++) //the first od item has no values
                {
                    int PathFromNode = ZoneToNode(OD[od].OrigZone,links);
                    int PathToNode = ZoneToNode(OD[od].DestZone, links);
                    if(PathFromNode >0 && PathToNode > 0)
                    {
                        g.PathList = new List<List<int>>();
                        GetPathsFromOD(g, PathFromNode, PathToNode, network.FirstNetworkNode);
                        ODResult result = new ODResult();
                        result.Orig = OD[od].OrigZone;
                        result.Dest = OD[od].DestZone;
                        result.PathLists = g.PathList;
                        result.TravelTimeList = GetPathTravelTimes(result.PathLists,timePeriodResult);
                        result.FreeFlowTravelTimeList = GetPathFreeFlowTravelTimes(result.PathLists, timePeriodResult) ; 
                        double minimalPathTravelTime = result.TravelTimeList[0];
                        
                        for (int n =0; n< result.TravelTimeList.Count; n++)
                        {
                            if (result.TravelTimeList[n] < minimalPathTravelTime)
                            {
                                minimalPathTravelTime = result.TravelTimeList[n];
                            }
                        }
                        result.MinimalPathTravelTime = minimalPathTravelTime;
                        double minimalPathFreeFlowTravelTime = result.FreeFlowTravelTimeList[0];
                        for (int n = 0; n < result.FreeFlowTravelTimeList.Count; n++)
                        {
                            if (result.FreeFlowTravelTimeList[n] < minimalPathFreeFlowTravelTime)
                            {
                                minimalPathFreeFlowTravelTime = result.FreeFlowTravelTimeList[n];
                            }
                        }
                        result.MinimalPathFreeFlowTravelTime = minimalPathFreeFlowTravelTime;
                        for (int n = 0; n < result.TravelTimeList.Count; n++)
                        {
                            double diff = result.TravelTimeList[n] - minimalPathTravelTime;
                            if (diff < 1)
                            {
                                result.UtilizedPathLists.Add(result.PathLists[n]);
                                result.UtilizedList.Add(1);
                            }
                            else
                            {
                                result.UtilizedList.Add(0);
                            }
                        }
                        timePeriodResult.ODResults.Add(result);
                    }
   
                }
                               
                results.Add(timePeriodResult);

            }
           
        }

        private static List<SegmentTravelTime> GetSegmentTravelTimes(List<SegmentData> segments)
        {
            List<SegmentTravelTime> segmentTravelTimes = new List<SegmentTravelTime>();
            int numSegments = segments.Count - 2;
            SegmentTravelTime segTravelTime = new SegmentTravelTime();
            for(int seg = 1; seg<=numSegments; seg++)
            {
                segTravelTime.ID = seg;
                segTravelTime.TravelTime = segments[seg].Results.TravTimeAvg;
                segmentTravelTimes.Add(segTravelTime);
            }

            return segmentTravelTimes;
        }

        private static List<double> GetPathTravelTimes(List<List<int>>pathList,UserEquilibriumTimePeriodResult timePeriodResult)
        {
            List<double> PathTravelTimes = new List<double>();
            for(int path =0; path < pathList.Count; path++)
            {
                double PathTravelTime = 0;
                for(int node =0; node< pathList[path].Count-1; node++)
                {
                    int LinkFromNode = pathList[path][node];
                    int LinkToNode = pathList[path][node + 1];
                    for(int link = 0; link < timePeriodResult.LinkResults.Count; link++)
                    {
                        if(timePeriodResult.LinkResults[link].FromNode  == LinkFromNode && timePeriodResult.LinkResults[link].ToNode == LinkToNode)
                        {
                            PathTravelTime += timePeriodResult.LinkResults[link].TravelTime;
                            break;
                        }
                    }                   
                }
                PathTravelTimes.Add(PathTravelTime);
            }

            return PathTravelTimes;
        }

        private static List<double> GetPathFreeFlowTravelTimes(List<List<int>> pathList, UserEquilibriumTimePeriodResult timePeriodResult)
        {
            List<double> PathFreeFlowTravelTimes = new List<double>();
            for (int path = 0; path < pathList.Count; path++)
            {
                double PathFreeFlowTravelTime = 0;
                for (int node = 0; node < pathList[path].Count - 1; node++)
                {
                    int LinkFromNode = pathList[path][node];
                    int LinkToNode = pathList[path][node + 1];
                    for (int link = 0; link < timePeriodResult.LinkResults.Count; link++)
                    {
                        if (timePeriodResult.LinkResults[link].FromNode == LinkFromNode && timePeriodResult.LinkResults[link].ToNode == LinkToNode)
                        {
                            PathFreeFlowTravelTime += timePeriodResult.LinkResults[link].FreeFlowTravelTime;
                            break;
                        }
                    }
                }
                PathFreeFlowTravelTimes.Add(PathFreeFlowTravelTime);
            }

            return PathFreeFlowTravelTimes;
        }
        private static int ZoneToNode(int zone,List<LinkData> links)
        {
            int node = -1;
            for(int link = 0; link< links.Count; link++)
            {
                if(links[link].PhysLink == false)
                {
                    if(links[link].FromNode == zone)
                    {
                        node = links[link].ToNode;
                    }
                }
            }
            return node;
        }

        public static void AllOrNothingMSA(int tp, int numZones, int numNodes, List<double> NFL, NetworkData network, List<LinkData> links, List<FreewayData> freewayfacilities, List<ODdata> OD, List<List<List<double>>> RampProportionList, List<List<ODvolume>> ODvolumeLists, ref double[,] SP1)
        {
            int I1, I2;
            int J, J1, J73;
            int N1, N2;
            ODvolumeLists.Clear();
            List<double> SP = new List<double>();   //shortest path
            double newSP = new double();
            SP.Add(newSP);                          //create the '0' index list entry, since loop starts with index '1'
            List<int> PrevNode = new List<int>();   //preceding node
            int newPrevNode = new int();
            PrevNode.Add(newPrevNode);  //create the '0' index list entry, since loop starts with index '1'
            NFL.Clear();
            NFL.Add(newNFL);            //create the '0' index list entry, since loop starts with index '1'
            
            for (int i = 1; i <= network.TotalLinks; i++)
            {             
                NFL.Add(newNFL);
                NFL[i] = 0;
                if(links[i].PhysLink == true)
                {
                    links[i].TravTime[tp] = HCM_FF_Method.TravTimeFcnFreewayFacilities(RampProportionList[i-1], freewayfacilities[i - 1], tp, FL[i]);
                }
                ODvolumeLists.Add(new List<ODvolume>());
            }

            for (int i = 1; i <= numZones; i++)
            {
                I1 = ODlink[i];
                I2 = ODlink[i + 1] - 1;
                if (I1 > I2)
                    continue;

                ShortestPathMSA(i, tp, ref PrevNode, ref SP, ref links, numNodes);

                for (int k = I1; k <= I2; k++)
                {
                    J = DestZone[k];        //J = OD[k].DestZone;
                    J73 = J - numZones;
                    SP.Add(newSP);
                    SP1[i, J73] = SP[J];   //SP1[i, OD[k].DestZone] = SP[J];

                    Line60: PrevNode.Add(newPrevNode);
                    J1 = PrevNode[J];
                    if (J1 == 0)
                        continue;

                    N1 = FS[J1];
                    N2 = FS[J1 + 1] - 1;
                    for (int n = N1; n <= N2; n++)
                    {
                        if (links[n].ToNode == J)
                        {
                            NFL[n] = NFL[n] + OD[k].NumAdjTrips;
                            ODvolume volume = new ODvolume();
                            volume.OrigZone = OD[k].OrigZone;
                            volume.DestZone = OD[k].DestZone;
                            volume.Volume = OD[k].NumAdjTrips;
                            ODvolumeLists[n - 1].Add(volume);
                            J = J1;
                            goto Line60;  //to-do: eventually remove
                        }
                    }
                }
            }
        }
        public static void ShortestPathMSA(int RefNode, int tp, ref List<int> prevNode, ref List<double> SP, ref List<LinkData> Link, int numNodes)
        {
            List<int> CL = new List<int>();
            int newCL = new int();
            CL.Add(newCL);  //create the '0' index list entry, since loop starts with index '1'
            int newPrevNode = new int();
            prevNode.Add(newPrevNode);
            double newSP = new double();
            SP.Add(newSP);
            int I, K, NT;
            int IA, IA1;
            double SD, S;
            int ICL;
            //int TempCounter;

            for (int i = 1; i <= numNodes; i++)
            {
                SP.Add(newSP);
                SP[i] = 1 * Math.Pow(10, 20);   //set intial node-to-node travel time to a very large number
                prevNode.Add(newPrevNode);
                prevNode[i] = 0;
                CL.Add(newCL);
                CL[i] = 0;
            }
            SP[RefNode] = 0;
            CL[RefNode] = numNodes + 1;
            I = RefNode;
            NT = RefNode;

            do
            {
                IA = FS[I + 1] - 1;
                IA1 = FS[I];
                S = SP[I];

                if (IA1 <= IA)
                {
                    //TempCounter = 0;
                    for (int IR = IA1; IR <= IA; IR++)
                    {
                        K = Link[IR].ToNode;
                        SD = (S + Link[IR].TravTime[tp]);

                        if (SD < SP[K])
                        {
                            prevNode[K] = I;
                            SP[K] = SD;

                            if (CL[K] < 0)
                            {
                                CL[K] = CL[I];
                                CL[I] = K;
                            }
                            else if (CL[K] == 0)
                            {
                                CL[NT] = K;
                                NT = K;
                                CL[K] = numNodes + 1;
                            }
                        }
                    }
                }
                ICL = CL[I];
                CL[I] = -1;
                I = ICL;
            } while (I <= numNodes);
        }

        private static void AssignVolumeToShortestPath(List<PathData> NPathFL, int origZone, int destZone, int numZones, List<int> PrevNode, double volume)
        {
            List<int> inverseNodes = new List<int>();
            int node = destZone + numZones;
            while (node != origZone)
            {
                node = PrevNode[node];
                if (node != origZone)
                {
                    inverseNodes.Add(node);
                }
            }

            bool assigned = false;
            int iteration = 0;
            while(assigned == false && iteration < NPathFL.Count)
            {
                iteration++;
                if (NPathFL[iteration-1].OrigZone == origZone && NPathFL[iteration -1].DestZone == destZone)
                {
                    int numPathNodes = NPathFL[iteration - 1].Nodes.Count;
                    if (numPathNodes == inverseNodes.Count)
                    {
                        assigned = true;
                        for (int n = 0; n < numPathNodes; n++)
                        {
                            if (NPathFL[iteration - 1].Nodes[n] != inverseNodes[numPathNodes - n - 1])
                            {
                                assigned = false;
                                break;
                            }                        
                        }
                        if(assigned == true)
                        {
                            NPathFL[iteration - 1].Volume = volume;
                            break;
                        }                      
                    }
                }
            }            
        }

        public static void AllOrNothing(int tp, int dInfo, int numZones, int numNodes, List<double> NFL,List<PathData> NPathFL, NetworkData network, List<LinkData> links, List<ODdata> OD, ref double[,] SP1)
        {
            int I1, I2;
            int J, J1, J73;
            int N1, N2;
            //double[] SP = new double[600];      //shortest path
            //int[] PrevNode = new int[600];      //preceding node

            List<double> SP = new List<double>();   //shortest path
            double newSP = new double();
            SP.Add(newSP);                          //create the '0' index list entry, since loop starts with index '1'
            List<int> PrevNode = new List<int>();   //preceding node
            int newPrevNode = new int();
            PrevNode.Add(newPrevNode);  //create the '0' index list entry, since loop starts with index '1'
            NFL.Clear();
            NFL.Add(newNFL);            //create the '0' index list entry, since loop starts with index '1'
            NPathFL.Clear();
            NPathFL.Add(newNPathFL);
            GetAllPaths(NPathFL,network,links,OD);

            for (int i = 1; i <= network.TotalLinks; i++)
            {
                NFL.Add(newNFL);
                NFL[i] = 0;
                if (tp > 1)
                    links[i].TravTime[tp] = LinkPerformanceCalculations.TravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, FL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp - 1], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
                else
                    links[i].TravTime[tp] = LinkPerformanceCalculations.TravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, FL[i], FLX[i], (network.PctUninformed[tp]/100), links[i].Que[tp], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);

                /*
                if (tp > 1)
                {
                    string message = Convert.ToString(tp) + "," + Convert.ToString(dInfo) + "," + Convert.ToString(i) + "," + Convert.ToString(Link[i].Capacity[tp]) + "," + Convert.ToString(FL[i]) + "," + Convert.ToString(FLX[i]) + "," + Convert.ToString(Network.PctUninformed[tp] / 100) + "," + Convert.ToString(Link[i].Que[tp - 1]) + "," + Convert.ToString(Link[i].TravTime[tp]);
                    //string message = Convert.ToString(tp) + "," + Convert.ToString(i) + "," + Convert.ToString(Link[i].Capacity[tp]) + "," + Convert.ToString(FL[i]) + "," + Convert.ToString(FLX[i]) + "," + Convert.ToString(Network.PctUninformed[tp] / 100) + "," + Convert.ToString(Link[i].Que[tp - 1]) + "," + Convert.ToString(Link[i].TravTime[tp]);
                    Debug.WriteLine(message);
                }
                else
                {
                    string message = Convert.ToString(tp) + "," + Convert.ToString(dInfo) + "," + Convert.ToString(i) + "," + Convert.ToString(Link[i].Capacity[tp]) + "," + Convert.ToString(FL[i]) + "," + Convert.ToString(FLX[i]) + "," + Convert.ToString(Network.PctUninformed[tp] / 100) + "," + Convert.ToString(Link[i].Que[tp]) + "," + Convert.ToString(Link[i].TravTime[tp]);
                    Debug.WriteLine(message);
                }*/
            }

            for (int i = 1; i <= numZones; i++)
            {
                I1 = ODlink[i];
                I2 = ODlink[i + 1] - 1;
                if (I1 > I2)
                    continue;

                ShortestPath(i, tp, dInfo, ref PrevNode, ref SP, ref links, numNodes);

                for (int k = I1; k <= I2; k++)
                {
                    J = DestZone[k];        //J = OD[k].DestZone;
                    J73 = J - numZones;
                    SP.Add(newSP);
                    SP1[i, J73] = SP[J];   //SP1[i, OD[k].DestZone] = SP[J];
                    AssignVolumeToShortestPath(NPathFL,i,J73,numZones, PrevNode, OD[k].NumAdjTrips);
                    /*
                    if (tp == 7 && dInfo == 2)
                    {
                        string message = "SP: " + Convert.ToString(i) + "," + Convert.ToString(J73) + "," + Convert.ToString(SP[J]);
                        Debug.WriteLine(message);
                        for (int z = 1; z <= 17; z++)
                        {
                            if (TempLink[z] != 0)
                            {
                                Debug.WriteLine(Convert.ToString(TempLink[z]) + "," + Convert.ToString(TempTravTime[z]));
                            }
                        }
                    }*/

                    Line60: PrevNode.Add(newPrevNode); 
                    J1 = PrevNode[J];
                    if (J1 == 0)
                        continue;

                    N1 = FS[J1];
                    N2 = FS[J1 + 1] - 1;
                    for (int n = N1; n <= N2; n++)
                    {
                        if (links[n].ToNode == J)
                        {
                            NFL[n] = NFL[n] + OD[k].NumAdjTrips;
                            J = J1;
                            goto Line60;  //to-do: eventually remove
                        }
                    }
                }
            }
        }
        
        public static void ShortestPath(int RefNode, int tp, int dInfo, ref List<int> prevNode, ref List<double> SP, ref List<LinkData> Link, int numNodes)
        {
            //int[] CL = new int[599];
            List<int> CL = new List<int>();
            int newCL = new int();
            CL.Add(newCL);  //create the '0' index list entry, since loop starts with index '1'
            int newPrevNode = new int();
            prevNode.Add(newPrevNode);
            double newSP = new double();
            SP.Add(newSP);
            int I, K, NT;
            int IA, IA1;
            double SD, S;
            int ICL;
            //int TempCounter;

            for (int i = 1; i <= numNodes; i++)
            {
                SP.Add(newSP);
                SP[i] = 1 * Math.Pow(10, 20);   //set intial node-to-node travel time to a very large number
                prevNode.Add(newPrevNode);
                prevNode[i] = 0;
                CL.Add(newCL);
                CL[i] = 0;
            }
            SP[RefNode] = 0;
            CL[RefNode] = numNodes + 1;
            I = RefNode;
            NT = RefNode;

            do
            {
                IA = FS[I + 1] - 1;
                IA1 = FS[I];
                S = SP[I];
                
                if (IA1 <= IA)
                {
                    //TempCounter = 0;
                    for (int IR = IA1; IR <= IA; IR++)
                    {
                        K = Link[IR].ToNode;
                        SD = (S + Link[IR].TravTime[tp]);
                        
                        if (SD < SP[K])
                        {
                            prevNode[K] = I;
                            SP[K] = SD;

                            /*
                            if (tp == 7 && dInfo == 2)
                            {
                                TempCounter++;
                                TempLink[TempCounter] = IR;
                                TempTravTime[TempCounter] = S; // Link[IR].TravTime[tp];
                                //string message = Convert.ToString(IR) + "," + Convert.ToString(Link[IR].TravTime[tp]);
                                //Debug.WriteLine(message);
                            }
                            /*
                            if (tp == 7 && dInfo == 2)
                            {
                                string message = "SP: " + Convert.ToString(RefNode) + "," + Convert.ToString(K) + "," + Convert.ToString(SD);
                                Debug.WriteLine(message);
                            }
                            */

                            if (CL[K] < 0)
                            {
                                CL[K] = CL[I];
                                CL[I] = K;
                            }
                            else if (CL[K] == 0)
                            {
                                CL[NT] = K;
                                NT = K;
                                CL[K] = numNodes + 1;
                            }
                        }
                    }
                }
                ICL = CL[I];
                CL[I] = -1;
                I = ICL;
            } while (I <= numNodes);
        }

        
        public static void Bisection(int tp, int dInfo, double min, double max, double convCrit, NetworkData network, ref List<LinkData> links)
        {
            double mid = (min + max) / 2;     //root of equation, alpha value
            double D;
            double TempFlow;
            double ObjFcn;
            NFL.Add(newNFL);    //create the '0' index list entry, since loop starts with index '1'

            //mid = (min + max) / 2;
            while (max - min > convCrit)
            {
                D = 0;
                for (int i = 1; i <= network.TotalLinks; i++)
                {
                    TempFlow = FL[i] + mid * (NFL[i] - FL[i]);

                    if (tp > 1)
                        ObjFcn = LinkPerformanceCalculations.TravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, TempFlow, FLX[i], (network.PctUninformed[tp] / 100), links[i].Que[tp - 1], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);
                    else
                        ObjFcn = LinkPerformanceCalculations.TravTimeFcn(dInfo, links[i].Length, links[i].Capacity[tp], links[i].FreeFlowSpeed, TempFlow, FLX[i], (network.PctUninformed[tp] / 100), links[i].Que[tp], LinkPerformanceCalculations.alpha[LinkPerformanceCalculations.CoeffIndex[i, tp]], LinkPerformanceCalculations.beta[LinkPerformanceCalculations.CoeffIndex[i, tp]]);

                    D = D + ObjFcn * (NFL[i] - FL[i]);
                }

                if (D > 0)
                    max = mid;
                else
                    min = mid;

                mid = (min + max) / 2;

            }
            for (int i = 1; i <= network.TotalLinks; i++)
            {
                NFL.Add(newNFL);
                NFL[i] = FL[i] + mid * (NFL[i] - FL[i]);
            }

            //update the path flows as well to get one set of path flow solutions
            for (int i = 1; i < NPathFL.Count; i++)
            {
                
                NPathFL[i].Volume = PathFL[i].Volume + mid * (NPathFL[i].Volume - PathFL[i].Volume);
            }

        }

        public static void MoveMSA(NetworkData network, int iteration)
        {
            for (int i = 1; i <= network.TotalLinks; i++)
            {
                NFL[i] = FL[i] + 1.0/iteration*(NFL[i] - FL[i]);
            }

        }
    }
}
