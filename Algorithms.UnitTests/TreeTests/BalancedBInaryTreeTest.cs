using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Tree.BinarySearchTree;
using System.Collections.Generic;

namespace Algorithms.UnitTests.TreeTests
{
    [TestClass]
    public class BalancedBinaryTreeTest
    {
        [TestMethod]
        public void GetZigZag_EmptyTree_ReturnsEmptyList()
        {
            BalancedBinaryTree tree = new BalancedBinaryTree();

            List<BinaryTreeNode> nodes = tree.GetZigZag();

            Assert.IsTrue(nodes.Count == 0);
        }

        [TestMethod]
        public void GetZigZag_TreeWith6Nodes_Returns6NodesInZigZagOrder()
        {
            BalancedBinaryTree tree = new BalancedBinaryTree();
            tree.Root = new BinaryTreeNode(4);
            tree.Insert(tree.Root, 2);
            tree.Insert(tree.Root, 6);
            tree.Insert(tree.Root, 1);
            tree.Insert(tree.Root, 5);
            tree.Insert(tree.Root, 7);
            tree.Insert(tree.Root, 3);

            List<BinaryTreeNode> nodes = tree.GetZigZag();


            Assert.IsTrue(nodes.Count == 6);
        }


    }
}
