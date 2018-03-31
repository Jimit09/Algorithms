using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class Node
    {
        internal Node Next { get; set; }
        internal int Data { get; private set; }

        internal Node(int data)
        {
            this.Data = data;
        }
    }
}
