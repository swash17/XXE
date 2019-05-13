using System.Collections.Generic;
using HCMCalc_Definitions;

namespace XXE_DataStructures
{
    public class LinkData
    {
        /**** Fields ****/
        private int _fromNode;
        private int _toNode;
        private double _length;     //units of miles
        private double _freeFlowSpeed; //units of mi/h
        private string _description;
        private bool _printTimePerResults;     //flag indicating whether to print the time period results for a specific link
        private bool _timePerData;          //flag indicating whether a link contains multiple time period data
        private bool _physLink;             //physical link
        //variables that can have values that vary by time period
        private double[] _flow = new double[25];
        private double[] _capacity = new double[25];
        private double[] _vcRatio = new double[25];
        private double[] _propCap = new double[25];
        private double[] _que = new double[25];
        private double[] _travTime = new double[25];           //units of hours
        //public TimePeriodData[] tpdArr;


        /**** Constructors ****/
        public LinkData()
        {
            _fromNode = 0;
            _toNode = 0;
            _length = 0;
            _description = "blank link";
            _timePerData = false;
            _physLink = false;

            InitializeArrays(24);
            

            //TimePeriodData[] tpdArr = new TimePeriodData[50];
            //for (int i = 0; i < 50; i++)
            //    tpdArr[i] = new TimePeriodData();

        }


        //Specify Link Attributes
        public LinkData(int fromNode, int toNode, double length, int flow, long capacity, double ffs, string descrip, bool timePerData)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Length = length;
            //vcRatio = Flow / Capacity;
            FreeFlowSpeed = ffs;
            Description = descrip;
            TimePerData = timePerData;
            //FFTravTime = Length / FreeFlowSpeed;
            InitializeArrays(24);

            //TimePeriodData[] tpdArr = new TimePeriodData[50];
            //for (int i = 0; i < 50; i++)
            //    tpdArr[i] = new TimePeriodData();
        }

        private void InitializeArrays(int NumTimePeriods)
        {

            for (int i = 0; i <= NumTimePeriods; i++)
            {
                _flow[i] = 0;
                _capacity[i] = 0.0;         //index of zero will be used for capacity input on link data screen
                _propCap[i] = 1.0;
                _vcRatio[i] = 0.0;        // _flow / _capacity;
                _que[i] = 0.0;
                _travTime[i] = 0;        //_length / _freeFlowSpeed;
            }

        }

        /**** Properties ****/
        public int FromNode
        {
            get { return _fromNode; }
            set { _fromNode = value; }
        }
        public int ToNode
        {
            get { return _toNode; }
            set { _toNode = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double FreeFlowSpeed    //int FreeFlowSpeed
        {
            get { return _freeFlowSpeed; }
            set { _freeFlowSpeed = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool PrintTimePerResults
        {
            get { return _printTimePerResults; }
            set { _printTimePerResults = value; }
        }
        public bool TimePerData
        {
            get { return _timePerData; }
            set { _timePerData = value; }
        }
        public bool PhysLink
        {
            get { return _physLink; }
            set { _physLink = value; }
        }
        public double[] TravTime
        {
            get { return _travTime; }
            set { _travTime = value; }
        }
        public double[] Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }
        public double[] Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public double[] vcRatio
        {
            get { return _vcRatio; }
            set { _vcRatio = value; }
        }
        public double[] PropCap
        {
            get { return _propCap; }
            set { _propCap = value; }
        }
        public double[] Que
        {
            get { return _que; }
            set { _que = value; }
        }
    }

    public class MainlineOutputsPlan
    {
        private int _planID;
        private MainlineOutputs _outputs;
        private int _tp;

        public int PlanID
        {
            get { return _planID; }
            set { _planID = value; }
        }

        public MainlineOutputs Outputs
        {
            get { return _outputs; }
            set { _outputs = value; }
        }
        public int TP
        {
            get { return _tp; }
            set { _tp = value; }
        }

        public MainlineOutputsPlan(int PlanID, MainlineOutputs Outputs, int TP)
        {
            _planID = PlanID;
            _outputs = Outputs;
            _tp = TP;
        }
    }

    public class FacilityVMT
    {
        List<double> _timePeriodVMT;
        List<double> _segmentVMT;
        double _totalVMT;
        int _fromNode;
        int _toNode;
        int _facilityID;

        public FacilityVMT()
        {
            _timePeriodVMT = new List<double>();
            _segmentVMT = new List<double>();
            _totalVMT = 0;
            _fromNode = 0;
            _toNode = 0;
            _facilityID = 0;
        }
        public List<double> TimePeriodVMT
        {
            get
            {
                return _timePeriodVMT;
            }

            set
            {
                _timePeriodVMT = value;
            }
        }

        public List<double> SegmentVMT
        {
            get
            {
                return _segmentVMT;
            }

            set
            {
                _segmentVMT = value;
            }
        }

        public double TotalVMT
        {
            get
            {
                return _totalVMT;
            }

            set
            {
                _totalVMT = value;
            }
        }

        public int FromNode
        {
            get
            {
                return _fromNode;
            }

            set
            {
                _fromNode = value;
            }
        }

        public int ToNode
        {
            get
            {
                return _toNode;
            }

            set
            {
                _toNode = value;
            }
        }

        public int FacilityID
        {
            get
            {
                return _facilityID;
            }

            set
            {
                _facilityID = value;
            }
        }
    }

}
