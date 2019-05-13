using System;
namespace XXE_DataStructures
{
    [Serializable()]
    public enum TimePeriod
    {
        Single,
        Multiple,
    }
    [Serializable()]
    public class NetworkData
    {
        TimePeriod _timePeriodType;
        int _totalCentroids;
        int _numODrecords;
        int _totalLinks;
        int _totalTime;
        int _timePerSize;
        int _numTimePer;
        int _numRestrictedLinks;
        double _travTimeAdjRatio;
        int _maxIterations;        //maximum number of permitted iterations
        double _convCrit;
        bool _printCentroidConnectors;

        double[] _intRatio = new double[25];
        double[] _pctUninformed = new double[25];
        double[] _pctInformed = new double[25];
        //calculations
        //private double[,] _travTime = new double[40,40];     //travel time from each origin node to each destination node
        double _totTravTime;
        double _totVMT;
        double _totVC;
        double _avgVCnonZeroFlowLinks;
        double _avgVCallPhysLinks;

        int _firstNetworkNode;
        int _numZones;             //also number of centroids
        int _numNodes;
        bool _withFreewayFacilityFiles;
        /**** Constructors ****/
        public NetworkData()
        {
            _timePeriodType = TimePeriod.Single;
            _totalCentroids = 0;
            _numODrecords = 0;
            _totalLinks = 0;
            _totalTime = 60;
            _timePerSize = 60;
            _numTimePer = 1;
            _numRestrictedLinks = 0;
            _travTimeAdjRatio = 1.0;
            _maxIterations = 100;
            _convCrit = 0.0005;
            _printCentroidConnectors = false;
            _withFreewayFacilityFiles = true;

            for (int i = 0; i <= 24; i++)
            {
                _intRatio[i] = 1.0;
                _pctUninformed[i] = 100.0;
                _pctInformed[i] = 0.0;
            }

            _totTravTime = 0;
            _totVMT = 0;
            _totVC = 0;
            _avgVCnonZeroFlowLinks = 0;

        }

        /**** Properties ****/
        public TimePeriod TimePeriodType
        {
            get { return _timePeriodType; }
            set { _timePeriodType = value; }
        }
        public int TotalCentroids
        {
            get { return _totalCentroids; }
            set { _totalCentroids = value; }
        }
        public int NumODrecords
        {
            get { return _numODrecords; }
            set { _numODrecords = value; }
        }
        public int TotalLinks
        {
            get { return _totalLinks; }
            set { _totalLinks = value; }
        }
        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }
        public int TimePeriodSize
        {
            get { return _timePerSize; }
            set { _timePerSize = value; }
        }
        public int NumTimePeriods
        {
            get { return _numTimePer; }
            set { _numTimePer = value; }
        }
        public int NumRestrictedLinks
        {
            get { return _numRestrictedLinks; }
            set { _numRestrictedLinks = value; }
        }
        public double TravTimeAdjRatio
        {
            get { return _travTimeAdjRatio; }
            set { _travTimeAdjRatio = value; }
        }
        public int MaxIterations
        {
            get { return _maxIterations; }
            set { _maxIterations = value; }
        }
        public double ConvCrit
        {
            get { return _convCrit; }
            set { _convCrit = value; }
        }
        public bool PrintCentroidConnectors
        {
            get { return _printCentroidConnectors; }
            set { _printCentroidConnectors = value; }
        }
        public double[] IntensityRatio
        {
            get { return _intRatio; }
            set { _intRatio = value; }
        }
        public double[] PctInformed
        {
            get { return _pctInformed; }
            set { _pctInformed = value; }
        }
        public double[] PctUninformed
        {
            get { return _pctUninformed; }
            set { _pctUninformed = value; }
        }
        public int FirstNetworkNode
        {
            get { return _firstNetworkNode; }
            set { _firstNetworkNode = value; }
        }
        public int NumZones
        {
            get { return _numZones; }
            set { _numZones = value; }
        }
        public int NumNodes
        {
            get { return _numNodes; }
            set { _numNodes = value; }
        }
        /*
        public double[,] TravTime
        {
            get { return _travTime; }
            set { _travTime = value; }
        } */
        public double TotTravTime
        {
            get { return _totTravTime; }
            set { _totTravTime = value; }
        }
        public double TotVMT
        {
            get { return _totVMT; }
            set { _totVMT = value; }
        }
        public double TotVC
        {
            get { return _totVC; }
            set { _totVC = value; }
        }
        public double AvgVCnonZeroFlowLinks
        {
            get { return _avgVCnonZeroFlowLinks; }
            set { _avgVCnonZeroFlowLinks = value; }
        }
        public double AvgVCallPhysLinks
        {
            get { return _avgVCallPhysLinks; }
            set { _avgVCallPhysLinks = value; }
        }

        public bool WithFreewayFacilityFiles
        {
            get
            {
                return _withFreewayFacilityFiles;
            }

            set
            {
                _withFreewayFacilityFiles = value;
            }
        }
    }

}
