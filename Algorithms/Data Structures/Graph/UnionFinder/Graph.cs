using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Graph.UnionFinder
{
    public class Graph
    {
        public int VerticesCount { get; set; }
        public int EdgesCount { get; set; }

        public Edge[] Edges { get; set; }

        public class Edge
        {
            public int Source { get; set; }
            public int Destination { get; set; }
        }

        public Graph(int v, int e)
        {
            this.VerticesCount = v;
            this.EdgesCount = e;
            this.Edges = new Edge[e];
            for (int i = 0; i < this.EdgesCount; i++)
            {
                this.Edges[i] = new Edge();
            }
        }

        public int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
            {
                return i;
            }
            return Find(parent, parent[i]);
        }

        public bool HasCycle()
        {
            int[] parent = new int[VerticesCount];
            for (int i = 0; i < EdgesCount; i++)
            {
                parent[i] = -1;
            }

            for (int i = 0; i < EdgesCount; i++)
            {
                int x = Find(parent, Edges[i].Source);
                int y = Find(parent, Edges[i].Destination);

                if (x == y)
                {
                    return true;
                }

                Union(parent, x, y);
            }
            return false;
        }

        private void Union(int[] parent, int x, int y)
        {
            int a = Find(parent, x);
            int b = Find(parent, y);
            parent[a] = b;
        }
    }
}
