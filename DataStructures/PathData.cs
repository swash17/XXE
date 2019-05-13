using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXE_DataStructures
{
    public class PathData
    {
        int _origZone;
        int _destZone;
        List<int> _nodes;
        double _volume;

        public PathData()
        {
            _nodes = new List<int>();
        }

        public int OrigZone
        {
            get
            {
                return _origZone;
            }

            set
            {
                _origZone = value;
            }
        }

        public int DestZone
        {
            get
            {
                return _destZone;
            }

            set
            {
                _destZone = value;
            }
        }

        public List<int> Nodes
        {
            get
            {
                return _nodes;
            }

            set
            {
                _nodes = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }
    }
}
