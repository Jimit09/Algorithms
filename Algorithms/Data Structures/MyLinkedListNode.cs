using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class MyLinkedListNode
    {
        internal MyLinkedListNode Next { get; set; }
        internal int Data { get; private set; }

        internal MyLinkedListNode(int data)
        {
            this.Data = data;
        }
    }
}
