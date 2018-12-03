using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    public class BalancedBinaryTree : BinaryTree
    {
        public BalancedBinaryTree()
        {

        }

        public BalancedBinaryTree(BinaryTreeNode root) : base(root)
        {

        }

        public void Insert(BinaryTreeNode node, int value)
        {
            if (value <= node.GetData())
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode(value);
                }
                else
                {
                    Insert(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode(value);
                }
                else
                {
                    Insert(node.Right, value);
                }
            }
        }


        public List<BinaryTreeNode> GetZigZag()
        {
            List<BinaryTreeNode> nodes = new List<BinaryTreeNode>();
            if (Root != null)
            {
                Stack<BinaryTreeNode> currentLevel = new Stack<BinaryTreeNode>();
                Stack<BinaryTreeNode> nextLevel = new Stack<BinaryTreeNode>();
                currentLevel.Push(Root);
                bool leftToRight = true;
                while (currentLevel.Count > 0)
                {
                    var node = currentLevel.Pop();
                    nodes.Add(node);
                    if (leftToRight)
                    {
                        if (node.Left != null)
                        {
                            nextLevel.Push(node.Left);
                        }
                        if (node.Right != null)
                        {
                            nextLevel.Push(node.Right);
                        }
                    }
                    else
                    {
                        if (node.Right != null)
                        {
                            nextLevel.Push(node.Right);
                        }
                        if (node.Left != null)
                        {
                            nextLevel.Push(node.Left);
                        }
                    }

                    if (currentLevel.Count == 0)
                    {
                        leftToRight = !leftToRight;
                        Swap(ref currentLevel, ref nextLevel);
                    }
                }
            }
            return nodes;
        }

        private void Swap(ref Stack<BinaryTreeNode> stack1, ref Stack<BinaryTreeNode> stack2)
        {
            Stack<BinaryTreeNode> temp = stack1;
            stack1 = stack2;
            stack2 = temp;
        }
    }
}
