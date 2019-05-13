using System.Collections.Generic;

namespace XXE_Calculations
{

    // A directed graph using
    // adjacency list representation
    public class Graph
    {
        // No. of vertices in graph
        private int _v;
        // adjacency list 
        private List<List<int>> _adjList;
        private List<List<int>> _pathList;
        private List<double> _pathFlowList;
        public List<List<int>> AdjList
        {
            get
            {
                return _adjList;
            }

            set
            {
                _adjList = value;
            }
        }

        public int V
        {
            get
            {
                return _v;
            }

            set
            {
                _v = value;
            }
        }

        public List<List<int>> PathList
        {
            get
            {
                return _pathList;
            }

            set
            {
                _pathList = value;
            }
        }

        public List<double> PathFlowList
        {
            get
            {
                return _pathFlowList;
            }

            set
            {
                _pathFlowList = value;
            }
        }

        //Constructor
        public Graph(int vertices)
        {
            //initialise vertex count
            _v = vertices;
            _pathList = new List<List<int>>();
            _pathFlowList = new List<double>();
            // initialise adjacency list
            initAdjList();
        }

        // utility method to initialise adjacency list
        private void initAdjList()
        {
            this.AdjList = new List<List<int>>();

            for (int i = 0; i < V; i++)
            {
                this.AdjList.Add(new List<int>());
            }
        }

        // add edge from u to v
        public void addEdge(int u, int v)
        {
            // Add v to u's list.
            this.AdjList[u].Add(v);
        }

        // Get all paths from
        // 's' to 'd'
        public void getAllPaths(int s, int d, int firstPhysicalNode)
        {
            bool[] isVisited = new bool[V];
            List<int> pathList = new List<int>();

            //add source to path[]
            pathList.Add(s);

            //Call recursive utility
            printAllPathsUtil(s, d, isVisited, pathList,firstPhysicalNode);
        }

        // A recursive function to print all paths from 'u' to 'd'.
        // isVisited[] keeps track of vertices in current path.
        // localPathList<> stores actual vertices in the current path
        private void printAllPathsUtil(int u, int d, bool[] isVisited, List<int> localPathList,int firstPhysicalNode)
        {
            // Mark the current node
            isVisited[u] = true;

            if (u == d)
            {
                List<int> path = new List<int>();
                foreach(int node in localPathList)
                {
                    path.Add(node+ firstPhysicalNode);
                }
                this.PathList.Add(path);
            }

            // Recur for all the vertices adjacent to current vertex
            foreach(int i in AdjList[u])
            {
                if (isVisited[i] == false)
                {
                    // store current node in path[]
                    localPathList.Add(i);
                    printAllPathsUtil(i, d, isVisited, localPathList,firstPhysicalNode);

                    // remove current node in path[]
                    localPathList.Remove(i);
                }
            }

            // Mark the current node
            isVisited[u] = false;
        }

        
    }

}
