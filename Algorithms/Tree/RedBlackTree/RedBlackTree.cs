using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.RedBlackTree
{
    /// <summary>
    /// Properties of Red-black tree
    /// 1. Every node is either red or black.
    /// 2. The root is black.
    /// 3. Every leaf(NIL) is black.
    /// 4. If a node is red, then both its children are black.
    /// 5. For each node, all paths from the node to descendant leaves contain the same
    /// number of black nodes.
    /// </summary>
    public class RedBlackTree
    {
        public RedBlackTreeNode Root { get; set; }


        public void Insert(int key)
        {
            RedBlackTreeNode previous = null;
            RedBlackTreeNode current = this.Root;
            RedBlackTreeNode node = new RedBlackTreeNode(key);
            node.Color = Color.Red;
            while (current != null)
            {
                previous = current;
                if (key < current.Data)
                {
                    current = current.Left;
                }
                else if (key > current.Data)
                {
                    current = current.Right;
                }
            }

            if (previous == null)
            {
                this.Root = current;
            }
            else
            {
                if (key < previous.Data)
                {
                    previous.Left = node;
                }
                else
                {
                    previous.Right = node;
                }
                node.Parent = previous;
            }




        }

        private void InsertFix(RedBlackTreeNode z)
        {

            while (z.Parent != null && z.Parent.Color == Color.Red)
            {
                //z.Parent.Parent will exist since control entered the while loop on condition that z.Parent is Red and since root is black, 
                //this means z.Parent.Parent can only be black otherwise there would be violation of Property 4 i.e
                //If a node is red, then both its children are black.
                if (z.Parent == z.Parent.Parent.Left)
                {
                    RedBlackTreeNode y = z.Parent.Parent.Right;
                    if (y.Color == Color.Red)
                    {
                        //Case 1:-
                        z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else// Y's color is black
                    {
                        //Case 2:-
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    RedBlackTreeNode y = z.Parent.Parent.Left;
                    if (y.Color == Color.Red)
                    {
                        //Case 4:
                        y.Color = Color.Black;
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        //Y is  black
                        //Case 5: if z is Right child


                    }
                }
            }
            this.Root.Color = Color.Black;
        }

        public RedBlackTreeNode LeftRotate(RedBlackTreeNode x)
        {
            RedBlackTreeNode y = x.Right;
            x.Right = y.Left;

            if (y.Left != null)
            {
                y.Left.Parent = x;
            }
            y.Parent = x.Parent;
            if (x.Parent == null)
            {
                this.Root = y;
            }
            else
            {
                if (x.Parent.Left == x)
                {
                    x.Parent.Left = y;
                }
                else
                {
                    x.Parent.Right = y;
                }
            }
            y.Left = x;
            x.Parent = y;
            return y;
        }

        public RedBlackTreeNode RightRotate(RedBlackTreeNode y)
        {
            RedBlackTreeNode x = y.Left;
            y.Left = x.Right;

            if (x.Right != null)
            {
                x.Right.Parent = y;
            }

            x.Parent = y.Parent;
            if (y.Parent == null)
            {
                this.Root = x;
            }
            else
            {
                if (y.Parent.Left == y)
                {
                    y.Parent.Left = x;
                }
                else
                {
                    y.Parent.Right = x;
                }
            }

            x.Right = y;
            y.Parent = x;
            return x;
        }
    }
}
