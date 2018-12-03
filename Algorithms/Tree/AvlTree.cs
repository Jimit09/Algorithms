using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree
{
    /// <summary>
    /// Only Unique keys/data value is allowed
    /// </summary>
    public class AvlTree
    {
        public AvlTreeNode Root;

        int GetNodeHeight(AvlTreeNode avlTreeNode)
        {
            if (avlTreeNode == null)
            {
                return 0;
            }

            return avlTreeNode.Height;
        }

        //        T1, T2 and T3 are subtrees of the tree
        //          rooted with y(on the left side) or x(on
        //          the right side)
        //            y                               x
        //           / \     Right Rotation          /  \
        //          x  T3   – – – – – – – >         T1   y 
        //         / \       < - - - - - - -            / \
        //        T1 T2     Left Rotation             T2   T3
        //Keys in both of the above trees follow the
        //following order
        // keys(T1) < key(x) < keys(T2) < key(y) < keys(T3)
        //So BST property is not violated anywhere.
        public AvlTreeNode RightRotate(AvlTreeNode y)
        {
            AvlTreeNode x = y.Left;
            AvlTreeNode t2 = x.Right;

            x.Right = y;
            y.Left = t2;

            x.Height = (Math.Max(x.Left.Height, x.Right.Height)) + 1;
            y.Height = (Math.Max(y.Left.Height, y.Right.Height)) + 1;

            //Return the new root
            return x;
        }

        public AvlTreeNode LeftRotate(AvlTreeNode x)
        {
            AvlTreeNode y = x.Right;
            AvlTreeNode t2 = y.Left;
            y.Left = x;
            x.Right = t2;

            x.Height = (Math.Max(x.Left.Height, x.Right.Height)) + 1;
            y.Height = (Math.Max(y.Left.Height, y.Right.Height)) + 1;

            return y;
        }

        int GetBalanceHeight(AvlTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetNodeHeight(node.Left) - GetNodeHeight(node.Right);
        }

        public AvlTreeNode Insert(AvlTreeNode node, int key)
        {
            /* 1.  Perform the normal BST insertion */
            if (node == null)
            {
                return new AvlTreeNode(key);
            }

            if (key < node.Data)
            {
                node.Left = Insert(node.Left, key);
            }
            else if (key > node.Data)
            {
                node.Right = Insert(node.Right, key);
            }
            else // Node with same key cannot be inserted into the tree.
            {
                return node;
            }

            /* 2. Update height of this ancestor node */
            node.Height = (Math.Max(GetNodeHeight(node.Left), GetNodeHeight(node.Right))) + 1;

            /* 3. Get the balance factor of this ancestor
              node to check whether this node became
              unbalanced */
            int balance = GetBalanceHeight(node);

            // If this node becomes unbalanced, then there
            // are 4 cases 

            //Left left case
            if (balance > 1 && key < node.Left.Data)
            {
                return RightRotate(node);
            }

            //Right right case 
            if (balance < -1 && key > node.Right.Data)
            {
                return LeftRotate(node);
            }

            //Left Right case
            if (balance > 1 && key > node.Left.Data)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            //Right Left case
            if (balance < -1 && key < node.Right.Data)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            //return unchanged node pointer
            return node;
        }

        //public AvlTreeNode InsertFixUp(AvlTreeNode z)
        //{

        //}

        public AvlTreeNode Delete(AvlTreeNode node, int key)
        {
            if (node == null)
            {
                return node;
            }
            if (key < node.Data)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (key > node.Data)
            {
                node.Right = Delete(node.Right, key);
            }
            if (node.Left == null && node.Right == null)
            {
                return null;
            }
            if (node.Left == null)
            {
                AvlTreeNode temp = node.Right;
                node.Right = null;
                return temp;
            }
            if (node.Right == null)
            {
                AvlTreeNode temp = node.Left;
                node.Left = null;
                return temp;
            }

            AvlTreeNode successor = GetMinimum(node.Right);
            node.Data = successor.Data;
            node.Right = Delete(node.Right, successor.Data);

            //Recalculate the height of node
            node.Height = Math.Max(node.Left.Height, node.Right.Height) + 1;

            //Check the Height Balance 
            int balance = GetBalanceHeight(node);

            //Left Left case
            if (balance > 1 && GetBalanceHeight(node.Left) >= 0)
            {
                node = RightRotate(node);
            }

            //Left Right case
            if (balance > 1 && GetBalanceHeight(node.Left) < 0)
            {
                node.Left = LeftRotate(node.Left);
                node = RightRotate(node);
            }

            //Right Right case
            if (balance < 1 && GetBalanceHeight(node.Right) <= 0)
            {
                node = LeftRotate(node);
            }

            //Right Left case
            if (balance < 1 && GetBalanceHeight(node.Right) > 0)
            {
                node.Right = RightRotate(node.Right);
                node = LeftRotate(node);
            }
            return node;
        }

        public AvlTreeNode GetMinimum()
        {
            return GetMinimum(this.Root);
        }

        public AvlTreeNode GetMinimum(AvlTreeNode node)
        {
            AvlTreeNode currentNode = node;
            if (currentNode != null)
            {
                while (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
            }
            return currentNode;
        }

        public List<AvlTreeNode> GetPreOrder(AvlTreeNode node)
        {
            List<AvlTreeNode> avlTreeNodes = new List<AvlTreeNode>();
            if (node != null)
            {
                avlTreeNodes.Add(node);
                avlTreeNodes.AddRange(GetPreOrder(node.Left));
                avlTreeNodes.AddRange(GetPreOrder(node.Right));
            }
            return avlTreeNodes;
        }

        public List<AvlTreeNode> GetInOrder(AvlTreeNode node)
        {
            List<AvlTreeNode> avlTreeNodes = new List<AvlTreeNode>();
            if (node != null)
            {
                avlTreeNodes.AddRange(GetInOrder(node.Left));
                avlTreeNodes.Add(node);
                avlTreeNodes.AddRange(GetInOrder(node.Right));
            }
            return avlTreeNodes;
        }

        public List<AvlTreeNode> GetPostOrder(AvlTreeNode node)
        {
            List<AvlTreeNode> avlTreeNodes = new List<AvlTreeNode>();
            if (node != null)
            {
                avlTreeNodes.AddRange(GetPostOrder(node.Left));
                avlTreeNodes.AddRange(GetPostOrder(node.Right));
                avlTreeNodes.Add(node);
            }
            return avlTreeNodes;
        }
    }
}
