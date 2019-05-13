using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using XXE_DataStructures;
using HCMCalc_Definitions;

namespace XXE_Calculations
{
    public static class FileInputOutput
    {
        public static void ReadFreewayFacilitiesProjectFile(string filename, XXE_DataStructures.ProjectData Project,NetworkData network)
        {
            XmlTextReader xtr;
            xtr = new XmlTextReader(filename);

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element)
                {
                    switch (xtr.Name)
                    {
                        //Project Data Elements
                        case "Title":
                            Project.Title = xtr.ReadElementContentAsString();
                            break;
                        //case "FileName":
                        //    Project.FileName = xtr.ReadElementContentAsString();
                        //    break;
                        case "NetworkFileName":
                            Project.NetworkFileName = xtr.ReadElementContentAsString();
                            break;
                        case "ODfileName":
                            Project.ODfileName = xtr.ReadElementContentAsString();
                            break;
                        case "AnalystName":
                            Project.AnalName = xtr.ReadElementContentAsString();
                            break;
                        case "AnalysisDate":
                            //project.Date = xtr.ReadElementContentAsDateTime();
                            Project.AnalDate = Convert.ToDateTime(xtr.ReadElementContentAsString());
                            break;
                        case "Notes":
                            Project.UserNotes = xtr.ReadElementContentAsString();
                            break;
                        case "ProjectType":
                            if (xtr.ReadElementContentAsString() == "BPRlinks")
                            {
                                Project.Type = ProjectType.BPRlinks;
                            }
                            else
                            {
                                Project.Type = ProjectType.FreewayFacilities;
                            }
                            break;
                        //Network data
                        case "ConvCrit":
                            network.ConvCrit = xtr.ReadElementContentAsDouble();
                            break;
                        case "MaxIter":
                            network.MaxIterations = xtr.ReadElementContentAsInt();
                            break;
                        case "FirstNetworkNode":
                            network.FirstNetworkNode = xtr.ReadElementContentAsInt();
                            network.NumZones = (network.FirstNetworkNode - 1) / 2;
                            break;
                        case "NumberOfNodes":
                            network.NumNodes = xtr.ReadElementContentAsInt();
                            break;
                        case "NumberOfODrecords":
                            network.NumODrecords = xtr.ReadElementContentAsInt();
                            break;
                        case "TotalLinks":
                            network.TotalLinks = xtr.ReadElementContentAsInt();
                            break;

                    }
                }
            }
            Project.FileName = filename;
            xtr.Close();
        }
        public static void WriteFreewayFacilitiesProjectFile(string filename,XXE_DataStructures.ProjectData Project, NetworkData network)
        {
            XmlTextWriter xtw = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            //indent tags by 2 characters
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 2;
            //enclose attributes' values in double quotes
            xtw.QuoteChar = '"';
            xtw.WriteStartDocument(true);

            //write <TMML> information
            xtw.WriteStartElement("TMML");
            xtw.WriteAttributeString("Facility", "TTR_ATDM_Freeway");

            //write <PROJECT> information
            xtw.WriteStartElement("ProjectInfo");
            xtw.WriteElementString("Title", Project.Title);
            xtw.WriteElementString("AnalystName", Project.AnalName);
            xtw.WriteElementString("AnalysisDate", Project.AnalDate.ToString());
            xtw.WriteElementString("Notes", Project.UserNotes);
            xtw.WriteElementString("FileName", filename);
            xtw.WriteElementString("NetworkFileName", Project.NetworkFileName);
            xtw.WriteElementString("ODfileName", Project.ODfileName);
            xtw.WriteElementString("ProjectType", Project.Type.ToString());
            //close the <PROJECT> tag
            xtw.WriteFullEndElement();

            xtw.WriteStartElement("NetworkData");
            xtw.WriteElementString("ConvCrit", network.ConvCrit.ToString());
            xtw.WriteElementString("MaxIter", network.MaxIterations.ToString());
            xtw.WriteElementString("FirstNetworkNode", network.FirstNetworkNode.ToString());
            xtw.WriteElementString("NumberOfNodes", network.NumNodes.ToString());
            xtw.WriteElementString("NumberOfODrecords", network.NumODrecords.ToString());
            xtw.WriteElementString("TotalLinks", network.TotalLinks.ToString());
            xtw.WriteEndElement();


            //close <TMML> tag
            xtw.WriteFullEndElement();

            xtw.Close();
        }

        //public static void FileInputOutput()
        //{
        //    /*
        //    for (int i = 0; i < 99; i++)
        //        FileLinkArr[i] = new LinkData(1, 2, 100, 2400, false, 35, "First");
        //    for (int i = 0; i < 50; i++)
        //        FileODarr[i] = new ODdata(1, 2, 100);
        //    */
        //}

        public static void ReadFile(string filename)
        {/*
            if (filename.EndsWith("xml"))
                ReadXmlFile(filename);
            else
                ReadDatFile(filename); */
        }

        public static void ReadNWDatFile(string filename, NetworkData network, List<LinkData> links)
        {
            string LinkRecord;
            string[] LinkFieldsArr;
            LinkFieldsArr = new string[6];
            int LinkNum = 0;  //index for link number

            // create reader & open file
            StreamReader sr = new StreamReader(filename);

            while ((LinkRecord = sr.ReadLine()) != null)  // read a line of text
            {
                LinkData NewLink = new LinkData();
                links.Add(NewLink);
                LinkNum++;
                
                //Console.WriteLine(sr.ReadLine());
                //string LinkRecord = sr.ReadLine();

                LinkFieldsArr = LinkRecord.Split(',');  //parse the record into fields, based on comma delimitation

                //string[] LinkFieldsArr = LinkRecord.Split(',');

                links[LinkNum].FromNode = Convert.ToInt32(LinkFieldsArr[0]);   //change to int16?
                links[LinkNum].ToNode = Convert.ToInt32(LinkFieldsArr[1]);     //change to int16?
                links[LinkNum].Capacity[0] = Convert.ToInt64(LinkFieldsArr[2]);
                links[LinkNum].Length = Convert.ToDouble(LinkFieldsArr[3]);
                links[LinkNum].FreeFlowSpeed = Convert.ToDouble(LinkFieldsArr[4]);  // Convert.ToInt32(LinkFieldsArr[4]);
                if (LinkFieldsArr.Length == 6)  //description field may be left blank
                    links[LinkNum].Description = LinkFieldsArr[5].ToString();
            }
            network.TotalLinks = LinkNum;

            sr.Close(); // close the stream            
        }
        
        public static void ReadODxmlFile(string filename, NetworkData network, List<ODdata> origDestPairs)
        {
            XmlTextReader xtr;
            xtr = new XmlTextReader(filename);
            int ODnum = 0;      //index for centroid number

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element)
                {
                    switch (xtr.Name)
                    {
                        //Origin-Destination Data Elements
                        case "OrigZone":
                            ODdata NewODpair = new ODdata();
                            origDestPairs.Add(NewODpair);
                            origDestPairs[ODnum+1].OrigZone = xtr.ReadElementContentAsInt();
                            break;
                        case "DestZone":
                            origDestPairs[ODnum+1].DestZone = xtr.ReadElementContentAsInt();
                            break;
                        case "NumTrips":
                            origDestPairs[ODnum+1].NumTrips = xtr.ReadElementContentAsInt();
                            ODnum++;    //increment centroid number
                            
                            break;
                    }
                }
            }
            network.NumODrecords = ODnum;        //assign local variable to static variable

            xtr.Close();
        }
        public static void ReadODDatFile(string filename, NetworkData network, List<ODdata> ODpairs)
        {
            string ODRecord;
            string[] ODFieldsArr;
            ODFieldsArr = new string[2];
            int odNum = 0;  //index for link number

            // create reader & open file
            StreamReader sr = new StreamReader(filename);
            //skip the first line
            int NumOfLines = 1;
            for (var i = 0; i < NumOfLines; i++)
            {
                sr.ReadLine();
            }

            while ((ODRecord = sr.ReadLine()) != null)  // read a line of text
            {
                ODdata NewODpair = new ODdata();
                ODpairs.Add(NewODpair);
                odNum++;
                
                ODFieldsArr = ODRecord.Split(',');  //parse the record into fields, based on comma delimitation

                ODpairs[odNum].OrigZone = Convert.ToInt32(ODFieldsArr[0]);     //change to int16?
                ODpairs[odNum].DestZone = Convert.ToInt32(ODFieldsArr[1]);     //change to int16?
                ODpairs[odNum].NumTrips = Convert.ToInt32(ODFieldsArr[2]);
            }
            network.NumODrecords = odNum;
            sr.Close(); // close the stream
            
        }
        
        public static void ReadXmlFile(string filename, XXE_DataStructures.ProjectData project, NetworkData network, List<LinkData> links, List<ODdata> origDestPairs)
        {
            XmlTextReader xtr = new XmlTextReader(filename);
            int LinkNum = 0;    //index for link number
            int ODnum = 0;      //index for centroid number
            int LinkTP = 0;      //index for link time period data
            int NetworkTP = 0;   //index for network time period data

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element)
                {
                    switch (xtr.Name)
                    {
                        //Project Data Elements
                        case "Title":
                            project.Title = xtr.ReadElementContentAsString();
                            break;
                        case "AnalystName":
                            project.AnalName = xtr.ReadElementContentAsString();
                            break;
                        case "AnalysisDate":
                            //project.Date = xtr.ReadElementContentAsDateTime();
                            project.AnalDate = Convert.ToDateTime(xtr.ReadElementContentAsString());
                            break;
                        case "Notes":
                            project.UserNotes = xtr.ReadElementContentAsString();
                            break;
                        case "ProjectType":
                            if(xtr.ReadElementContentAsString() == "BPRlinks")
                            {
                                project.Type = ProjectType.BPRlinks;
                            }
                            else
                            {
                                project.Type = ProjectType.FreewayFacilities;
                            }                       
                            break;
                        //Network Data Elements
                        case "TimePeriodType":
                            string TimePeriodType = xtr.ReadElementContentAsString();
                            if (TimePeriodType == "Single")
                                network.TimePeriodType = TimePeriod.Single;
                            else
                                network.TimePeriodType = TimePeriod.Multiple;
                            break;
                        case "NumTimePeriods":
                            network.NumTimePeriods = xtr.ReadElementContentAsInt();
                            break;
                        case "TimePeriodSize":
                            network.TimePeriodSize = xtr.ReadElementContentAsInt();
                            break;
                        case "ConvCrit":
                            network.ConvCrit = xtr.ReadElementContentAsDouble();
                            break;
                        case "MaxIter":
                            network.MaxIterations = xtr.ReadElementContentAsInt();
                            break;
                        case "TravTimeAdjRatio":
                            network.TravTimeAdjRatio = xtr.ReadElementContentAsDouble();
                            break;
                        case "FirstNetworkNode":
                            network.FirstNetworkNode = xtr.ReadElementContentAsInt();
                            network.NumZones = (network.FirstNetworkNode - 1) / 2;
                            break;
                        case "NumberOfNodes":
                            network.NumNodes = xtr.ReadElementContentAsInt();
                            break;
                        case "PrintCentroidConnectors":
                            string PrintCentroids = xtr.ReadElementContentAsString();
                            if (PrintCentroids == "False")
                                network.PrintCentroidConnectors = false;
                            else
                                network.PrintCentroidConnectors = true;
                            break;
                        //Link Data Elements
                        case "FromNode":
                            LinkData NewLink = new LinkData();
                            links.Add(NewLink);
                            LinkNum++;  //increment link number
                            //FileLinkArr[LinkNum].FromNode = Convert.ToInt32(xtr.Value);
                            links[LinkNum].FromNode = xtr.ReadElementContentAsInt();
                            break;
                        case "ToNode":
                            links[LinkNum].ToNode = xtr.ReadElementContentAsInt();
                            break;
                        case "Length":
                            links[LinkNum].Length = xtr.ReadElementContentAsDouble();
                            break;
                        case "Capacity":
                            links[LinkNum].Capacity[0] = xtr.ReadElementContentAsLong();
                            break;
                        case "FreeFlowSpeed":
                            links[LinkNum].FreeFlowSpeed = xtr.ReadElementContentAsDouble();
                            break;
                        case "Description":
                            links[LinkNum].Description = xtr.ReadElementContentAsString();
                            break;
                            //Link Time Period Data
                        case "PrintTimePeriodResults":
                            string PrintTimePeriodResults = xtr.ReadElementContentAsString();
                            if (PrintTimePeriodResults == "Yes")
                                links[LinkNum].PrintTimePerResults = true;
                            else
                                links[LinkNum].PrintTimePerResults = false;
                            break;
                        case "TimePeriodData":  
                            string TimePeriodData = xtr.ReadElementContentAsString();
                            if (TimePeriodData == "Yes")
                                links[LinkNum].TimePerData = true;
                            else
                                links[LinkNum].TimePerData = false;
                            break;
                        case "ProportionCapacity":
                            LinkTP++;
                            links[LinkNum].PropCap[LinkTP] = xtr.ReadElementContentAsDouble();
                            break;
                        //Origin-Destination Data Elements
                        case "OrigZone":
                            ODdata NewODpair = new ODdata();
                            origDestPairs.Add(NewODpair);
                            ODnum++;    //increment centroid number,
                            origDestPairs[ODnum].OrigZone = xtr.ReadElementContentAsInt();
                            break;
                        case "DestZone":
                            origDestPairs[ODnum].DestZone = xtr.ReadElementContentAsInt();
                            break;
                        case "NumTrips":
                            origDestPairs[ODnum].NumTrips = xtr.ReadElementContentAsInt();
                            break;
                        //Network Time Period Data
                        case "TrafficIntensityRatio":
                            NetworkTP++;
                            network.IntensityRatio[NetworkTP] = xtr.ReadElementContentAsDouble();
                            break;
                        case "PctUninformedDrivers":
                            network.PctUninformed[NetworkTP] = xtr.ReadElementContentAsDouble();
                            break;
                    }
                }
            }
            
            network.TotalLinks = LinkNum;      //assign local variable to static variable
            network.NumODrecords = ODnum;        //assign local variable to static variable

            xtr.Close();
        }

        
     
        public static void WriteXmlFile(string filename, XXE_DataStructures.ProjectData project, NetworkData network, List<LinkData> links, List<ODdata> origDestPairs)
        {
            XmlTextWriter xtw = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            //indent tags by 2 characters
            xtw.Formatting = Formatting.Indented;    
            xtw.Indentation = 2;
            //enclose attributes' values in double quotes
            xtw.QuoteChar = '"';
            xtw.WriteStartDocument(true);
            xtw.WriteStartElement("XXE_XML");
            //write <ProjectInfo> information
            xtw.WriteStartElement("ProjectInfo");
            xtw.WriteElementString("Title", project.Title);
            xtw.WriteElementString("AnalystName", project.AnalName);
            xtw.WriteElementString("AnalysisDate", project.AnalDate.ToString());
            xtw.WriteElementString("Notes", project.UserNotes);
            xtw.WriteElementString("FileName", filename);          
            xtw.WriteElementString("ProjectType", project.Type.ToString());
            xtw.WriteEndElement();
            //write <AnalysisParamters> information
            xtw.WriteStartElement("NetworkData");
            if (network.TimePeriodType == TimePeriod.Single)
                xtw.WriteElementString("TimePeriodType", "Single");
            else
                xtw.WriteElementString("TimePeriodType", "Multiple");
            xtw.WriteElementString("NumTimePeriods", network.NumTimePeriods.ToString());
            xtw.WriteElementString("TimePeriodSize", network.TimePeriodSize.ToString());
            xtw.WriteElementString("ConvCrit", network.ConvCrit.ToString());
            xtw.WriteElementString("MaxIter", network.MaxIterations.ToString());
            xtw.WriteElementString("TravTimeAdjRatio", network.TravTimeAdjRatio.ToString());
            xtw.WriteElementString("PrintCentroidConnectors", network.PrintCentroidConnectors.ToString());
            xtw.WriteElementString("FirstNetworkNode", network.FirstNetworkNode.ToString());
            xtw.WriteElementString("NumberOfNodes", network.NumNodes.ToString());
            xtw.WriteEndElement();
            //write <LinkData> information
            xtw.WriteStartElement("LinkData");
            for (int id = 1; id <= network.TotalLinks; id++)
            {
                //write a new <Link id="nnn"> element
                xtw.WriteStartElement("Link");
                xtw.WriteAttributeString("id", id.ToString());
                //write the fields of each link
                xtw.WriteElementString("FromNode", links[id].FromNode.ToString());
                xtw.WriteElementString("ToNode", links[id].ToNode.ToString());
                xtw.WriteElementString("Length", links[id].Length.ToString());
                xtw.WriteElementString("Capacity", links[id].Capacity[0].ToString());
                xtw.WriteElementString("FreeFlowSpeed", links[id].FreeFlowSpeed.ToString());
                xtw.WriteElementString("Description", links[id].Description);
                if (network.TimePeriodType == TimePeriod.Multiple)
                {
                    if (links[id].PrintTimePerResults == true)
                        xtw.WriteElementString("PrintTimePeriodResults", "Yes");
                    else
                        xtw.WriteElementString("PrintTimePeriodResults", "No");
                    if (links[id].TimePerData == true)
                        xtw.WriteElementString("TimePeriodData", "Yes");
                    else
                        xtw.WriteElementString("TimePeriodData", "No");
                }
                //write <LinkTimePeriodData>
                if (links[id].TimePerData == true)
                {
                    xtw.WriteStartElement("LinkTimePeriodData");
                    for (int timePer = 1; timePer <= network.NumTimePeriods; timePer++)
                    {
                        xtw.WriteStartElement("LinkTimePeriod");
                        xtw.WriteAttributeString("id", timePer.ToString());
                        xtw.WriteElementString("ProportionCapacity", links[id].PropCap[timePer].ToString());
                        xtw.WriteEndElement();  //close the <LinkTimePeriod> tag
                    }
                    xtw.WriteEndElement();  //close the <LinkTimePeriodData> tag
                }
                xtw.WriteEndElement();  //close the <Link> tag
            }
            xtw.WriteEndElement();  //close the <LinkData> tag

            //write <ODdata> information
            xtw.WriteStartElement("ODdata");
            for (int id = 1; id <= network.NumODrecords; id++)
            {
                //write a new <Link id="nnn"> element
                xtw.WriteStartElement("O-D");
                xtw.WriteAttributeString("id", id.ToString());
                //write the fields of each link
                xtw.WriteElementString("OrigZone", origDestPairs[id].OrigZone.ToString());
                xtw.WriteElementString("DestZone", origDestPairs[id].DestZone.ToString());
                xtw.WriteElementString("NumTrips", origDestPairs[id].NumTrips.ToString());
                xtw.WriteEndElement();  //close the <O-D> tag
            }
            xtw.WriteEndElement();  //close the <ODdata> tag
            //write <NetworkTimePeriodData>
            if (network.TimePeriodType == TimePeriod.Multiple)
            {
                xtw.WriteStartElement("NetworkTimePeriodData");
                for (int timePer = 1; timePer <= network.NumTimePeriods; timePer++)
                {
                    xtw.WriteStartElement("NetworkTimePeriod");
                    xtw.WriteAttributeString("id", timePer.ToString());
                    xtw.WriteElementString("TrafficIntensityRatio", network.IntensityRatio[timePer].ToString());
                    xtw.WriteElementString("PctUninformedDrivers", network.PctUninformed[timePer].ToString());
                    xtw.WriteEndElement();  //close the <NetworkTimePeriod> tag
                }
                xtw.WriteEndElement();  //close the <NetworkTimePeriodData> tag
            }
            xtw.WriteEndElement();  //close the <XXE_XML> tag
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public static void WriteODdataFile(string filename, List<ODdata> origDestPairs)
        {
            XmlTextWriter xtw = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            //indent tags by 2 characters
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 2;
            //enclose attributes' values in double quotes
            xtw.QuoteChar = '"';
            xtw.WriteStartDocument(true);
            xtw.WriteStartElement("XXE_OD");

            //write <ODdata> information
            xtw.WriteStartElement("ODdata");
            for (int id = 1; id < origDestPairs.Count; id++)
            {
                //write a new <Link id="nnn"> element
                xtw.WriteStartElement("O-D");
                xtw.WriteAttributeString("id", id.ToString());
                //write the fields of each link
                xtw.WriteElementString("OrigZone", origDestPairs[id].OrigZone.ToString());
                xtw.WriteElementString("DestZone", origDestPairs[id].DestZone.ToString());
                xtw.WriteElementString("NumTrips", origDestPairs[id].NumTrips.ToString());
                xtw.WriteEndElement();  //close the <O-D> tag
            }
            xtw.WriteEndElement();  //close the <ODdata> tag

            xtw.WriteEndElement();  //close the <XXE_XML> tag
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public static void OpenResultsFile(string projTitle)
        {
            
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", false);

            sw.WriteLine("User Equilibrium Assignment");
            sw.WriteLine();
            sw.WriteLine("Project: " + projTitle);
            sw.WriteLine();
            sw.WriteLine("Link Statistics");
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.WriteLine("                                     v/c      Orig  Dest    Travel");
            sw.WriteLine("Link #      Flow     Capacity       Ratio     Node  Node     Time       Name");
            sw.WriteLine("------      ----     --------       -----     ----  ----    ------      -------------");
            sw.Close();
        }

        public static void WriteLinkResults(int linkNum, double flow, double capacity, double vcRatio, int origNode, int destNode, double travTime, string description)
        {
            string ResultsRow;
            ResultsRow = "   " + linkNum.ToString() + "\t\t" + flow.ToString("0") + "\t\t" + capacity.ToString("0") + "\t\t" + vcRatio.ToString("0.000") + "\t\t" + origNode.ToString() + "\t" + destNode.ToString() + "\t" + travTime.ToString("0.0000") + "\t" + description;

            //object[] ResultsRow = new object[] { linkNum.ToString(), (Link[linkNum].Flow).ToString(), (Link[linkNum].Capacity).ToString(), (Link[linkNum].vcRatio).ToString(), (origNode[linkNum]).ToString(), (destNode[linkNum]).ToString() };
            
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", true);
            sw.WriteLine(ResultsRow);
            sw.Close();
        }

        public static void WriteNetworkResults(NetworkData Network, int NonZeroFlowLinks)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", true);
            sw.WriteLine();
            sw.WriteLine("Network Statistics");
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.WriteLine("Number of OD Pairs: " + Network.NumODrecords.ToString());
            sw.WriteLine("Number of Physical Links with Non-Zero Flows: " + NonZeroFlowLinks.ToString());
            sw.WriteLine("Total Travel Time (veh-hrs): " + Network.TotTravTime.ToString("0.0"));
            sw.WriteLine("Total Vehicle-Miles Traveled (veh-mi): " + Network.TotVMT.ToString("0.0"));
            sw.WriteLine("Average Congestion (all physical links): " + Network.AvgVCallPhysLinks.ToString("0.0000"));
            sw.WriteLine("Average Congestion (non-zero flow links): " + Network.AvgVCnonZeroFlowLinks.ToString("0.0000"));
            sw.WriteLine();
            sw.WriteLine("Program Statistics");
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.WriteLine("Number of Iterations: " + Calculations.IterNum.ToString());
            //sw.WriteLine("Convergence Criterion: " + ProjectData.ConvCrit.ToString());
            sw.WriteLine("Calculated Convergence Value: " + Calculations.ConvValue.ToString("0.00000"));
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.Close();
        }

        
        //Routines for printing multiperiod analysis results
        public static void OpenTimePeriodResultsFile(string projTitle)
        {
            //Just create a new output file that will overwrite any existing one
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", false);

            sw.WriteLine("User Equilibrium Assignment");
            sw.WriteLine();
            sw.WriteLine("Project: " + projTitle);
            sw.WriteLine();
            sw.WriteLine();
            sw.Close();
        }

        public static void WriteLinkTimePeriodHeader(int linkNum, int origNode, int destNode, string description)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", true);

            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine("Link Number: " + linkNum.ToString());
            sw.WriteLine("From node " + origNode.ToString() + " to node " + destNode.ToString());
            sw.WriteLine("Link Label: " + description);
            sw.WriteLine();
            sw.WriteLine("                                          v/c      Veh in");
            sw.WriteLine("Period           Flow     Capacity       Ratio     Queue");
            sw.WriteLine("------           ----     --------       -----     -----");
            sw.Close();
        }

        public static void WriteLinkTimePeriodResults(int tp, double flow, double capacity, double vcRatio, double que)
        {
            string ResultsRow;
            ResultsRow = "    " + tp.ToString() + "\t\t" + flow.ToString("0") + "\t\t" + capacity.ToString("0") + "\t\t" + vcRatio.ToString("0.000") + "\t\t" + que.ToString("0");

            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\results.txt", true);
            sw.WriteLine(ResultsRow);
            sw.Close();
        }

        
        public static void OpenDiagnosticsOutput(string projTitle)
        {
            //Just create a new output file that will overwrite any existing one
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", false);

            sw.WriteLine("Diagnostic Output");
            sw.WriteLine();
            sw.WriteLine("Project: " + projTitle);
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.WriteLine();
            sw.Close();
        }

        public static void WriteDiagnosticsTimePeriod(int timePeriod, int driverInfo)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);

            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.WriteLine("Time Period: " + timePeriod.ToString());
            sw.WriteLine("Driver Status: " + driverInfo.ToString());
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.Close();
        }

        public static void WriteDiagnosticsODtrips(int ODpair, double numODtrips)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);
            sw.WriteLine("OD trips (" + ODpair + "): " + numODtrips.ToString());
            sw.Close();
        }

        public static void WriteDiagnosticsLinkCapacities(int linkNum, double LinkCap)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);
            sw.WriteLine("Link Capacity (" + linkNum + "): " + LinkCap.ToString());
            sw.Close();
        }
        
        public static void WriteDiagnosticsLinkFlows(string Algorithm, List<double> Flows, int totalLinks)
        {
        StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);
        sw.WriteLine(Algorithm);

        for (int i = 1; i <= totalLinks; i++)
            {
            sw.WriteLine("Link (" + i + "): " + Flows[i].ToString());
            }

            sw.Close();
        }

        public static void WriteDiagnosticsShortestPaths(int origZone, int destZone, double[,] ShortPath)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);
            sw.WriteLine("Shortest Path (" + origZone + "-" + destZone + "): " + ShortPath[origZone, destZone].ToString());
            sw.Close();
        }
        
        public static void CloseDiagnosticsOutput()
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Diagnostics.txt", true);
            sw.WriteLine();
            sw.WriteLine("-------------------------------------------------------------------------------------");
            sw.Close();
        }

        public static void ReadSegmentVMTFromFile2(string filename, List<List<SegmentData>> tpSegs, int freewayId)
        {
            XmlTextReader xtr = new XmlTextReader(filename);

            int TimePeriod = 0;
            int FwyId = 0;
            int SegId = 0;

            while (xtr.Read())
            {
                if (xtr.IsStartElement("OVERALL"))
                {
                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Whitespace)
                        {
                            continue;
                        }
                        if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "OVERALL")
                        {
                            break;
                        }
                    }
                }
                if (xtr.IsStartElement("FREEWAY"))
                {
                    FwyId = Convert.ToInt32(xtr.GetAttribute(0));

                    if (FwyId == freewayId)
                    {
                        while (xtr.Read())
                        {
                            if (xtr.NodeType == XmlNodeType.Whitespace)
                            {
                                continue;
                            }
                            if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "FREEWAY")
                            {
                                xtr.Close();
                                return;
                            }

                            if (xtr.IsStartElement("TIMEPERIODS"))
                            {
                                while (xtr.Read())
                                {
                                    if (xtr.NodeType == XmlNodeType.Whitespace)
                                    {
                                        continue;
                                    }
                                    if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TIMEPERIODS")
                                    {
                                        break;
                                    }
                                    else if (xtr.IsStartElement("TimePeriod"))
                                    {
                                        TimePeriod = Convert.ToInt32(xtr.GetAttribute(0));
                                    }
                                    else if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TimePeriod")
                                    {
                                        //break;
                                    }
                                    else if (xtr.IsStartElement("SEGMENT"))
                                    {
                                        SegId = Convert.ToInt32(xtr.GetAttribute(0));

                                        while (xtr.Read())
                                        {

                                            if (xtr.NodeType == XmlNodeType.EndElement)
                                                if (xtr.Name == "SEGMENT")
                                                {
                                                    break;
                                                }

                                            switch (xtr.Name)
                                            {
                                                case "VMTdemand":
                                                    string vmtd = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                    vmtd = vmtd.Replace(",", "");
                                                    tpSegs[TimePeriod][SegId].Results.VehMilesTravDemand = Convert.ToDouble(vmtd);
                                                    break;
                                                case "VMTvolume":
                                                    string vmtv = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                    vmtv = vmtv.Replace(",", "");
                                                    tpSegs[TimePeriod][SegId].Results.VehMilesTravVolume = Convert.ToDouble(vmtv);
                                                    break;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            xtr.Close();
        }



        public static void ReadSegmentVMTFromFileNetwork(string filename, List<List<SegmentData>> tpSegs, int freewayId)
        {
            XmlTextReader xtr = new XmlTextReader(filename);

            int TimePeriod = 0;
            int FwyId = 0;
            int SegId = 0;

            while (xtr.Read())
            {
                if (xtr.IsStartElement("OVERALL"))
                {
                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Whitespace)
                        {
                            continue;
                        }
                        if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "OVERALL")
                        {
                            break;
                        }
                    }
                }
                if (xtr.IsStartElement("FREEWAY"))
                {
                    FwyId = Convert.ToInt32(xtr.GetAttribute(0));

                    if (FwyId == freewayId)
                    {
                        while (xtr.Read())
                        {
                            if (xtr.NodeType == XmlNodeType.Whitespace)
                            {
                                continue;
                            }
                            if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "FREEWAY")
                            {
                                xtr.Close();
                                return;
                            }

                            if (xtr.IsStartElement("TIMEPERIODS"))
                            {
                                while (xtr.Read())
                                {
                                    if (xtr.NodeType == XmlNodeType.Whitespace)
                                    {
                                        continue;
                                    }
                                    if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TIMEPERIODS")
                                    {
                                        break;
                                    }
                                    else if (xtr.IsStartElement("TimePeriod"))
                                    {
                                        TimePeriod = Convert.ToInt32(xtr.GetAttribute(0));
                                    }
                                    else if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TimePeriod")
                                    {
                                        //break;
                                    }
                                    else if (xtr.IsStartElement("SEGMENT"))
                                    {
                                        SegId = Convert.ToInt32(xtr.GetAttribute(0));

                                        while (xtr.Read())
                                        {

                                            if (xtr.NodeType == XmlNodeType.EndElement)
                                                if (xtr.Name == "SEGMENT")
                                                {
                                                    break;
                                                }

                                            switch (xtr.Name)
                                            {
                                                case "VMTdemand":
                                                    string vmtd = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                    vmtd = vmtd.Replace(",", "");
                                                    tpSegs[TimePeriod][SegId].Results.VehMilesTravDemand = Convert.ToDouble(vmtd);
                                                    break;
                                                case "VMTvolume":
                                                    string vmtv = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                    vmtv = vmtv.Replace(",", "");
                                                    tpSegs[TimePeriod][SegId].Results.VehMilesTravVolume = Convert.ToDouble(vmtv);
                                                    break;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            xtr.Close();
        }
        public static MainlineOutputs ReadTimePeriodResultsFromFileNetwork(string filename, int timePeriod, int freewayId)
        {
            int FwyId = 0;
            MainlineOutputs results = new MainlineOutputs();
            XmlTextReader xtr;
            xtr = new XmlTextReader(filename);

            while (xtr.Read())
            {
                if (xtr.IsStartElement("OVERALL"))
                {
                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Whitespace)
                        {
                            continue;
                        }
                        if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "OVERALL")
                        {
                            break;
                        }
                    }
                }
                if (xtr.IsStartElement("FREEWAY"))
                {
                    FwyId = Convert.ToInt32(xtr.GetAttribute(0));

                    if (FwyId == freewayId)
                    {
                        while (xtr.Read())
                        {
                            if (xtr.NodeType == XmlNodeType.Whitespace)
                            {
                                continue;
                            }
                            if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "FREEWAY")
                            {
                                xtr.Close();
                                return results;
                            }
                            if (xtr.IsStartElement("TMML"))
                            {
                                xtr.MoveToNextAttribute();
                                string temp = xtr.Value;
                                if (temp != "Freeway")
                                {
                                    //MessageBox.Show("Incorrect Facility");
                                    //return false;
                                    break;
                                }
                            }
                            else if (xtr.IsStartElement("TIMEPERIODS"))
                            {
                                //Fwy.Clear();

                                while (xtr.Read())
                                {

                                    if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TIMEPERIODS")
                                    {
                                        break;
                                    }
                                    else if (xtr.IsStartElement("TimePeriod"))
                                    {
                                        if (xtr.GetAttribute("id").CompareTo(timePeriod.ToString()) == 0)
                                        {
                                            //while (!(xtr.NodeType == XmlNodeType.EndElement && xtr.Name == "TimePeriod")) { xtr.Read(); }

                                            while (xtr.Read())
                                            {
                                                //if (xtr.NodeType == XmlNodeType.EndElement)
                                                //    if (xtr.Name == "TimePeriod")
                                                //        break;

                                                if (xtr.IsStartElement("MOEGROUP"))
                                                {
                                                    while (xtr.Read())
                                                    {

                                                        if (xtr.NodeType == XmlNodeType.EndElement)
                                                            if (xtr.Name == "MOEGROUP")
                                                                return results;

                                                        switch (xtr.Name)
                                                        {
                                                            case "AvgSpeed":
                                                                results.AvgSpeed = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "AvgTravTime":
                                                                results.TravTimeAvg = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "TravTimeIndex":
                                                                results.TravTimeRatio = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "FreeFlowTravTime":
                                                                results.TravTimeFreeFlow = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "DensityVeh":
                                                                results.DensityVeh = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "DensityPC":
                                                                results.DensityPC = xtr.ReadElementContentAsDouble();
                                                                break;
                                                            case "VMTD":
                                                                string vmtd = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                                vmtd = vmtd.Replace(",", "");
                                                                results.VehMilesTravDemand = Convert.ToDouble(vmtd);
                                                                break;
                                                            case "VMTV":
                                                                string vmtv = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                                vmtv = vmtv.Replace(",", "");
                                                                results.VehMilesTravVolume = Convert.ToDouble(vmtv);
                                                                break;
                                                            case "VHT":
                                                                string vht = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                                vmtv = vht.Replace(",", "");
                                                                results.VehHoursTrav = Convert.ToDouble(vht);
                                                                break;
                                                            case "VHD":
                                                                string vhd = xtr.ReadElementContentAsString();  //need to account for commas in values
                                                                vhd = vhd.Replace(",", "");
                                                                results.VehHoursDelay = Convert.ToDouble(vhd);
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }


            }

            xtr.Close();
            //if (!string.IsNullOrEmpty(tempFile)) File.Delete(tempFile);
            //return true;
            return results;
        }
    }
}
