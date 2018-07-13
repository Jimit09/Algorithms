using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    internal class TreeNode
    {
        int data;
        TreeNode left;
        TreeNode right;

        internal TreeNode(int data)
        {
            this.data = data;
        }

        internal void Insert(int value)
        {
            if (value <= data)
            {
                if (left == null)
                {
                    left = new TreeNode(value);
                }
                else
                {
                    left.Insert(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new TreeNode(value);
                }
                else
                {
                    right.Insert(value);
                }
            }
        }

        private bool contains(int value)
        {
            if (value == data)
            {
                return true;
            }
            else if (value < data)
            {
                if (left == null)
                {
                    return false;
                }
                else
                {
                    return left.contains(value);
                }
            }
            else
            {
                if (right == null)
                {
                    return false;
                }
                else
                {
                    return right.contains(value);
                }
            }
        }

        private void PrintInOrderTraversal()
        {
            if (left != null)
            {
                left.PrintInOrderTraversal();
            }
            Console.WriteLine(data);
            if (right != null)
            {
                right.PrintInOrderTraversal();
            }
        }

        private void PrintPreOrderTraversal()
        {
            Console.WriteLine(data);
            if (left != null)
            {
                left.PrintPreOrderTraversal();
            }
            if (right != null)
            {
                right.PrintPreOrderTraversal();
            }
        }

        private void PrintPostOrderTraversal()
        {
            if (left != null)
            {
                left.PrintPostOrderTraversal();
            }

            if (right != null)
            {
                right.PrintPostOrderTraversal();
            }

            Console.WriteLine(data);
        }

        bool CheckBalancedBST(TreeNode root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }
            if (!(root.data >= min && root.data <= max))
            {
                return false;
            }

            return CheckBalancedBST(root.left, min, root.data - 1) && CheckBalancedBST(root.right, root.data + 1, max);
        }

        //Check if tree is Balanced Binary tree
        bool CheckBalancedBST()
        {
            TreeNode node = null;
            return CheckBalancedBST(node, Int32.MinValue, Int32.MaxValue);
        }
    }
}
