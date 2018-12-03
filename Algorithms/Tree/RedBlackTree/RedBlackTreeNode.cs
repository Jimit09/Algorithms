using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.RedBlackTree
{
    public class RedBlackTreeNode
    {
        public RedBlackTreeNode Left { get; set; }
        public RedBlackTreeNode Right { get; set; }
        public RedBlackTreeNode Parent { get; set; }

        public int Data { get; set; }
        public Color Color { get; set; }

        public RedBlackTreeNode(int data)
        {
            Data = data;
        }
    }
}
