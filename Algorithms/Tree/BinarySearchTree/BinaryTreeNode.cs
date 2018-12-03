using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    public class BinaryTreeNode
    {
        int _data;

        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public BinaryTreeNode Parent;


        public BinaryTreeNode(int data)
        {
            this._data = data;
        }

        public int GetData()
        {
            return _data;
        }

        public void SetData(int value)
        {
            this._data = value;
        }

        private bool Contains(int value)
        {
            if (value == _data)
            {
                return true;
            }
            else if (value < _data)
            {
                if (Left == null)
                {
                    return false;
                }
                else
                {
                    return Left.Contains(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    return false;
                }
                else
                {
                    return Right.Contains(value);
                }
            }
        }

        private void PrintInOrderTraversal()
        {
            if (Left != null)
            {
                Left.PrintInOrderTraversal();
            }
            Console.WriteLine(_data);
            if (Right != null)
            {
                Right.PrintInOrderTraversal();
            }
        }

        private void PrintPreOrderTraversal()
        {
            Console.WriteLine(_data);
            if (Left != null)
            {
                Left.PrintPreOrderTraversal();
            }
            if (Right != null)
            {
                Right.PrintPreOrderTraversal();
            }
        }

        private void PrintPostOrderTraversal()
        {
            if (Left != null)
            {
                Left.PrintPostOrderTraversal();
            }

            if (Right != null)
            {
                Right.PrintPostOrderTraversal();
            }

            Console.WriteLine(_data);
        }

        bool CheckBalancedBST(BinaryTreeNode root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }
            if (!(root._data >= min && root._data <= max))
            {
                return false;
            }

            return CheckBalancedBST(root.Left, min, root._data - 1) && CheckBalancedBST(root.Right, root._data + 1, max);
        }

        //Check if tree is Balanced Binary tree
        bool CheckBalancedBST()
        {
            BinaryTreeNode node = null;
            return CheckBalancedBST(node, Int32.MinValue, Int32.MaxValue);
        }

        //This does not consider the case when root could be null
        public static int GetHeight(BinaryTreeNode root)
        {
            if (root.Left == null && root.Right == null)
            {
                return 0;
            }
            int rightHeight = 0;
            if (root.Right != null)
            {
                rightHeight = GetHeight(root.Right);
            }

            int leftHeight = 0;
            if (root.Left != null)
            {
                leftHeight = GetHeight(root.Left);
            }
            if (rightHeight >= leftHeight)
                return rightHeight + 1;
            else
                return leftHeight + 1;
        }

        /// <summary>
        ///For base case giving height of -1.
        ///This method considers the case when root could be null
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int GetHeightUsingBaseCase(BinaryTreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            int leftHeight = GetHeightUsingBaseCase(root.Left);
            int rightHeight = GetHeightUsingBaseCase(root.Right);
            if (leftHeight >= rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }
    }
}
