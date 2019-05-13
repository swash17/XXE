namespace XXE_DataStructures
{
    public class TimePeriodData
    {
        /**** Fields ****/
        private int _linkNum;
        private int _timePer;
        private double _propCap;

        /**** Constructors ****/
        public TimePeriodData()
        {
            _linkNum = 1;
            _timePer = 1;
            _propCap = 1.0;
        }

        //Specify Link Attributes
        /*
        public TimePeriodData(int fromNode, int toNode, double length, int capacity, bool restrictCap, int ffs, string descrip)
        {
            RestrictCap = restrictCap;
            
        }
        */
        public int LinkNum
        {
            get { return _linkNum; }
            set { _linkNum = value; }
        }
        public int TimePer
        {
            get { return _timePer; }
            set { _timePer = value; }
        }
        public double PropCap
        {
            get { return _propCap; }
            set { _propCap = value; }
        }
    }
}
