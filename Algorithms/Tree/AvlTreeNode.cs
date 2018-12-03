using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree
{
    public class AvlTreeNode
    {
        int _data;
        public int Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public AvlTreeNode Left;
        public AvlTreeNode Right;
        public int Height;

        public AvlTreeNode(int data)
        {
            _data = data;
            Height = 1;
        }
    }
}
