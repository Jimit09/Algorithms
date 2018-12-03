using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    public class BinaryTree
    {
        public BinaryTreeNode Root;

        public BinaryTree()
        {

        }

        public BinaryTree(BinaryTreeNode root)
        {
            this.Root = root;
        }

        //For reference goto :- https://www.geeksforgeeks.org/print-binary-tree-vertical-order/
        //From left vertical line to right vertical line.
        public List<BinaryTreeNode> GetVerticalOrderInBigOofNSquare()
        {
            int min = 0, max = 0, hd = 0;
            FindMinMax(this.Root, ref min, ref max, hd);
            List<BinaryTreeNode> list = new List<BinaryTreeNode>();
            //From left vertical line to right vertical line.
            for (int i = min; i <= max; i++)
            {
                list.AddRange(GetNodeOnLine(this.Root, i, 0));
            }
            return list;
        }

        private List<BinaryTreeNode> GetNodeOnLine(BinaryTreeNode node, int lineNo, int hd)
        {
            List<BinaryTreeNode> treeNodes = new List<BinaryTreeNode>();
            if (node != null)
            {
                if (hd == lineNo)
                {
                    treeNodes.Add(node);
                }

                treeNodes.AddRange(GetNodeOnLine(node.Left, lineNo, hd - 1));
                treeNodes.AddRange(GetNodeOnLine(node.Right, lineNo, hd + 1));
            }
            return treeNodes;
        }

        private void FindMinMax(BinaryTreeNode node, ref int min, ref int max, int hd)
        {
            if (node == null)
            {
                return;
            }

            if (hd < min)
            {
                min = hd;
            }
            else if (hd > max)
            {
                max = hd;
            }

            //For left child
            FindMinMax(node.Left, ref min, ref max, hd - 1);
            //For right child
            FindMinMax(node.Right, ref min, ref max, hd + 1);
        }

        public List<BinaryTreeNode> GetNodesInVerticalOrderInBigOofNLogN()
        {
            SortedDictionary<int, List<BinaryTreeNode>> map = new SortedDictionary<int, List<BinaryTreeNode>>();
            GetVerticalOrderWithBigOofNLogN(this.Root, map, 0);
            return map.Values.SelectMany(r => r).ToList();
        }

        private void GetVerticalOrderWithBigOofNLogN(BinaryTreeNode node, SortedDictionary<int, List<BinaryTreeNode>> map, int hd)
        {
            if (node == null)
            {
                return;
            }

            if (map.ContainsKey(hd))
            {
                var list = map[hd];
                list.Add(node);
            }
            else
            {
                map[hd] = new List<BinaryTreeNode>() { node };
            }

            GetVerticalOrderWithBigOofNLogN(node.Left, map, hd - 1);
            GetVerticalOrderWithBigOofNLogN(node.Right, map, hd + 1);
        }

        public List<BinaryTreeNode> GetInOrderTraversal()
        {
            return GetInOrderTraversal(this.Root);
        }

        public List<BinaryTreeNode> GetInOrderTraversal(BinaryTreeNode node)
        {
            List<BinaryTreeNode> list = new List<BinaryTreeNode>();
            if (node == null)
            {
                return list;
            }
            list.AddRange(GetInOrderTraversal(node.Left));
            list.Add(node);
            list.AddRange(GetInOrderTraversal(node.Right));
            return list;
        }

        public List<BinaryTreeNode> GetPreOrderTraversal()
        {
            return GetPreOrderTraversal(this.Root);
        }

        public List<BinaryTreeNode> GetPreOrderTraversal(BinaryTreeNode node)
        {
            List<BinaryTreeNode> list = new List<BinaryTreeNode>();
            if (node == null)
            {
                return list;
            }
            list.Add(node);
            list.AddRange(GetInOrderTraversal(node.Left));
            list.AddRange(GetInOrderTraversal(node.Right));
            return list;
        }

        public List<BinaryTreeNode> GetPostOrderTraversal()
        {
            return GetPostOrderTraversal(this.Root);
        }

        public List<BinaryTreeNode> GetPostOrderTraversal(BinaryTreeNode node)
        {
            List<BinaryTreeNode> list = new List<BinaryTreeNode>();
            if (node == null)
            {
                return list;
            }
            list.AddRange(GetPostOrderTraversal(node.Left));
            list.AddRange(GetPostOrderTraversal(node.Right));
            list.Add(node);
            return list;
        }

        public List<BinaryTreeNode> GetLevelOrderTraversal()
        {
            return GetLevelOrderTraversal(this.Root);
        }

        public List<BinaryTreeNode> GetLevelOrderTraversal(BinaryTreeNode root)
        {
            List<BinaryTreeNode> nodes = new List<BinaryTreeNode>();
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                BinaryTreeNode node = queue.Dequeue();
                nodes.Add(node);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return nodes;
        }

        public List<BinaryTreeNode> GetTopView()
        {
            return GetTopView(this.Root);
        }

        public List<BinaryTreeNode> GetTopView(BinaryTreeNode root)
        {
            Dictionary<int, BinaryTreeNode> dict = new Dictionary<int, BinaryTreeNode>();
            if (root != null)
            {
                Queue<Tuple<BinaryTreeNode, int>> queue = new Queue<Tuple<BinaryTreeNode, int>>();
                queue.Enqueue(new Tuple<BinaryTreeNode, int>(root, 0));
                while (queue.Count > 0)
                {
                    var queueItem = queue.Dequeue();
                    var hd = queueItem.Item2;
                    var node = queueItem.Item1;
                    if (!dict.ContainsKey(hd))
                    {
                        dict.Add(hd, node);
                    }

                    if (node.Left != null)
                    {
                        queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Left, hd - 1));
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Right, hd + 1));
                    }
                }
            }
            return dict.OrderBy(r => r.Key).Select(r => r.Value).ToList();
        }


        public List<BinaryTreeNode> GetRightView()
        {
            return GetRightView(this.Root);
        }

        public List<BinaryTreeNode> GetRightView(BinaryTreeNode root)
        {
            HashSet<int> set = new HashSet<int>();
            List<BinaryTreeNode> nodes = new List<BinaryTreeNode>();
            Queue<Tuple<BinaryTreeNode, int>> queue = new Queue<Tuple<BinaryTreeNode, int>>();
            queue.Enqueue(new Tuple<BinaryTreeNode, int>(root, 0));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                var node = item.Item1;
                var hd = item.Item2;
                if (!set.Contains(hd) && hd >= 0)
                {
                    set.Add(hd);
                    nodes.Add(node);
                }
                if (node.Left != null)
                {
                    queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Left, hd - 1));
                }
                if (node.Right != null)
                {
                    queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Right, hd + 1));
                }
            }
            return nodes;
        }

        public List<BinaryTreeNode> GetLeftView()
        {
            return GetLeftView(this.Root);
        }

        public List<BinaryTreeNode> GetLeftView(BinaryTreeNode root)
        {
            HashSet<int> set = new HashSet<int>();
            List<BinaryTreeNode> nodes = new List<BinaryTreeNode>();

            Queue<Tuple<BinaryTreeNode, int>> queue = new Queue<Tuple<BinaryTreeNode, int>>();
            queue.Enqueue(new Tuple<BinaryTreeNode, int>(root, 0));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                BinaryTreeNode node = item.Item1;
                int hd = item.Item2;

                if (!set.Contains(hd) && hd <= 0)
                {
                    set.Add(hd);
                    nodes.Add(node);
                }

                if (node.Left != null)
                {
                    queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Left, hd - 1));
                }
                if (node.Right != null)
                {
                    queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.Right, hd + 1));
                }
            }
            return nodes;
        }

        public BinaryTreeNode GetSuccessor(BinaryTreeNode node)
        {
            if (node.Right != null)
            {
                return GetMinimum(node.Right);
            }

            BinaryTreeNode successor = node.Parent;

            while (successor != null && successor.Left == node)
            {
                node = successor;
                successor = node.Parent;
            }
            return successor;
        }

        public BinaryTreeNode GetPredeccessor(BinaryTreeNode node)
        {
            if (node.Left != null)
            {
                return GetMaximum(node.Left);
            }
            BinaryTreeNode predecessor = node.Parent;

            while (predecessor != null && node == predecessor.Right)
            {
                node = predecessor;
                predecessor = predecessor.Parent;
            }
            return predecessor;
        }

        public BinaryTreeNode GetMinimum()
        {
            return GetMinimum(this.Root);
        }

        public BinaryTreeNode GetMinimum(BinaryTreeNode node)
        {
            BinaryTreeNode currentNode = node;
            if (currentNode != null)
            {
                while (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
            }
            return currentNode;
        }

        public BinaryTreeNode GetMaximum()
        {
            return GetMaximum(this.Root);
        }

        public BinaryTreeNode GetMaximum(BinaryTreeNode node)
        {
            BinaryTreeNode currentNode = node;
            if (currentNode != null)
            {
                while (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }
            }
            return currentNode;
        }

        //public void Delete(BinaryTreeNode nodeToDelete)
        //{
        //    if (nodeToDelete.left == null && nodeToDelete.right == null)
        //    {
        //        BinaryTreeNode parent = nodeToDelete.parent;
        //        if (parent == null)// Only one node i.e root node in the tree
        //        {
        //            this.root = null;
        //        }
        //        else
        //        {
        //            if (parent.left == nodeToDelete)
        //            {
        //                parent.left = null;
        //            }
        //            else
        //            {
        //                parent.right = null;
        //            }
        //        }
        //    }
        //    else if (nodeToDelete.right == null)
        //    {
        //        BinaryTreeNode parent = nodeToDelete.parent;
        //        if (parent == null)// Means nodeToDelete is root node.
        //        {
        //            this.root = nodeToDelete.left;
        //        }
        //        else
        //        {
        //            if (parent.right == nodeToDelete)
        //            {
        //                parent.right = nodeToDelete.left;
        //            }
        //            else//nodeToDelete is leftchild
        //            {
        //                parent.left = nodeToDelete.left;
        //            }
        //            nodeToDelete.left.parent = parent;
        //        }
        //        nodeToDelete.parent = null;
        //        nodeToDelete.left = null;
        //    }
        //    else if (nodeToDelete.left != null && nodeToDelete.right != null)
        //    {

        //    }
        //    else if (nodeToDelete.left == null)
        //    {
        //        BinaryTreeNode parent = nodeToDelete.parent;
        //        if (parent == null)// Means nodeToDelete is root node.
        //        {
        //            this.root = nodeToDelete.right;
        //        }
        //        else
        //        {
        //            if (parent.right == nodeToDelete)
        //            {
        //                parent.right = nodeToDelete.right;
        //            }
        //            else
        //            {
        //                parent.left = nodeToDelete.right;
        //            }
        //            nodeToDelete.right.parent = parent;
        //        }
        //        nodeToDelete.parent = null;
        //        nodeToDelete.right = null;
        //    }
        //    else
        //    {

        //    }



        //}

        public BinaryTreeNode DeleteNode(int data)
        {
            return DeleteNode(this.Root, data);
        }


        /// <summary>
        ///Recursive function to deleteNode
        ///This function takes pointer to the root node. Deletes the given node.
        ///and then passes the pointer to the root node. 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private BinaryTreeNode DeleteNode(BinaryTreeNode node, int key)
        {
            //If node is null return null

            if (node == null)
            {
                return node;
            }

            /* Otherwise recursively go down the tree*/
            if (key < node.GetData())
            {
                var child = DeleteNode(node.Left, key);
                node.Left = child;
                if (child != null)
                {
                    child.Parent = node;
                }
            }
            else if (key > node.GetData())
            {
                var child = DeleteNode(node.Right, key);
                node.Right = child;
                if (child != null)
                {
                    child.Parent = node;
                }
            }
            else // if node.GetData() == key, then this is the node to be deleted.
            {
                // if the node is leaf node.
                if (node.Left == null && node.Right == null)
                {
                    node.Parent = null;
                    return null;
                }

                // If node having only one child.
                if (node.Left == null)
                {
                    node.Parent = null;
                    var rightChild = node.Right;
                    node.Right = null;
                    return rightChild;
                }
                else if (node.Right == null)
                {
                    node.Parent = null;
                    var leftChild = node.Left;
                    node.Left = null;
                    return leftChild;
                }

                //if both left and right childs are present then,
                //Either replace it with successor or with predecessor

                //Here replacing it with successor
                var successor = GetSuccessor(node.Right);
                node.SetData(successor.GetData());

                node.Right = DeleteNode(node.Right, successor.GetData());
                return node;

            }
            //Returning the root node after processing.
            return node;
        }

        public void LeftRotate(BinaryTreeNode x)
        {
            BinaryTreeNode y = x.Right;

            //Change X and Y's child pointers
            x.Right = y.Left;
            if (y.Left != null)
            {
                y.Left.Parent = x;
            }

            //Adjust for Y's Parent pointers
            y.Parent = x.Parent;
            if (x.Parent == null)
            {
                Root = y;
            }
            else if (x.Parent.Left == x)// Then x was left child of its parent
            {
                x.Parent.Left = y;
            }
            else //Then x was right child of its parent
            {
                x.Parent.Right = y;
            }

            //Finally change pointers of X and Y, making X right child of Y

            y.Left = x;
            x.Parent = y;
        }

        public void RightRotate(BinaryTreeNode y)
        {
            BinaryTreeNode x = y.Left;

            //Change pointer of child of y
            y.Left = x.Right;
            if (x.Right != null)
            {
                x.Right.Parent = y;
            }

            //Change parent pointers of X and Y
            x.Parent = y.Parent;
            if (y.Parent != null)
            {
                //if y was the root, Then x is the new Root
                this.Root = x;
            }
            else if (y.Parent.Left == y)// Y was the left child of its parent node
            {
                y.Parent.Left = x;
            }
            else
            {//Y was the Right child of its parent node
                y.Parent.Right = x;
            }

            x.Right = y;
            y.Parent = x;
        }

        //public List<BinaryTreeNode> GetNodesInVerticalOrderInBigOofN()
        //{
        //    Dictionary<int, List<BinaryTreeNode>> map = new Dictionary<int, List<BinaryTreeNode>>();

        //    Queue<Tuple<BinaryTreeNode, int>> queue = new Queue<Tuple<BinaryTreeNode, int>>();
        //    if (this.root != null)
        //    {
        //        queue.Enqueue(new Tuple<BinaryTreeNode, int>(this.root, 0));
        //        while (queue.Count > 0)
        //        {
        //            var item = queue.Dequeue();
        //            BinaryTreeNode node = item.Item1;
        //            int hd = item.Item2;
        //            if (map.ContainsKey(hd))
        //            {
        //                map[hd].Add(node);
        //            }
        //            else
        //            {
        //                map[hd] = new List<BinaryTreeNode>() { node };
        //            }

        //            if (node.left != null)
        //            {
        //                queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.left, hd - 1));
        //            }

        //            if (node.right != null)
        //            {
        //                queue.Enqueue(new Tuple<BinaryTreeNode, int>(node.right, hd + 1));
        //            }
        //        }
        //    }

        //    return map.Values.SelectMany(r => r).ToList();
        //}



        // Diameter is  length from one to another node in the binary tree.
        // In below tree, the max diameter would be from node 11 - node 24. 11- 4-8- 20-22-25-14
        // So the max length need not involve root node at all.
        //           7 
        //         /   \
        //       20    12
        //     /    \   
        //   8      22
        //  /   \      \
        //5      4     25
        //       /       \      
        //      11     14 
        int GetMaxDiameter()
        {
            int max = 0;
            return GetMaxDiameter(this.Root, max);
        }

        int GetMaxDiameter(BinaryTreeNode node, int max)
        {
            if (node == null)
            {
                return 0;
            }

            int leftChildHeight = GetMaxDiameter(node.Left, max);
            int rightChildHeight = GetMaxDiameter(node.Right, max);

            int diameter = leftChildHeight + rightChildHeight + 1;
            if (diameter > max)
            {
                max = diameter;
            }

            return max;
        }
    }
}
