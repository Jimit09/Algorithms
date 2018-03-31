using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    internal class Node
    {
        int data;
        Node left;
        Node right;

        internal Node(int data)
        {
            this.data = data;
        }

        internal void insert(int value)
        {
            if (value <= data)
            {
                if (left == null)
                {
                    left = new Node(value);
                }
                else
                {
                    left.insert(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new Node(value);
                }
                else
                {
                    right.insert(value);
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

        bool CheckBalancedBST(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            return CheckBalancedBST(root.left, min, root.data - 1) && CheckBalancedBST(root.right, root.data + 1, max);
        }

        //Check if tree is Balanced Binary tree
        bool CheckBalancedBST()
        {
            Node node = null;
            return CheckBalancedBST(node, Int32.MinValue, Int32.MaxValue);
        }
    }
}
