using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Graph
{
    internal class GraphNode
    {
        internal int Id;
        internal List<GraphNode> Adjacent = new List<GraphNode>();
        internal GraphNode(int Id)
        {
            this.Id = Id;
        }
    }
}
