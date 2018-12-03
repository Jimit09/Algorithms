using System;
using System.Collections.Generic;
using Algorithms.Tree.BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests.TreeTests
{
    [TestClass]
    public class BinaryTreeNodeTest
    {
        [TestMethod]
        public void GetVerticalOrderInBigONSquare_InBinaryTree_ReturnsNodesInVerticalOrder()
        {
            //Arrange
            BinaryTree binaryTree = MakeVerticalTree();
            List<BinaryTreeNode> expectedNodes = new List<BinaryTreeNode>();

            //Act
            List<BinaryTreeNode> nodes = binaryTree.GetVerticalOrderInBigOofNSquare();
            int i = 0;
            //Assert

        }

        [TestMethod]
        public void GetNodesInVerticalOrderWithBigOofNLogN_ReturnsNodesCorrectlyInBigOofNLogN()
        {
            //Arrange
            BinaryTree binaryTree = MakeVerticalTree();
            List<BinaryTreeNode> expectedNodes = new List<BinaryTreeNode>();

            //Act
            List<BinaryTreeNode> nodes = binaryTree.GetNodesInVerticalOrderInBigOofNLogN();
            int i = 0;
            //Assert
        }


        //[TestMethod]
        //public void GetNodesInVerticalOrderInBigOofN_ReturnsNodesCorrectlyInBigOofN()
        //{
        //    //Arrange
        //    BinaryTree binaryTree = MakeVerticalTree();
        //    List<BinaryTreeNode> expectedNodes = new List<BinaryTreeNode>();

        //    //Act
        //    List<BinaryTreeNode> nodes = binaryTree.GetNodesInVerticalOrderInBigOofN();
        //    int i = 0;
        //    //Assert
        //}

        //TODO:- Write Unit tests for traversal of trees.

        private BinaryTree MakeVerticalTree()
        {
            BinaryTree tree = new BinaryTree();
            tree.Root = new BinaryTreeNode(1);
            tree.Root.Left = new BinaryTreeNode(2);
            tree.Root.Right = new BinaryTreeNode(3);
            tree.Root.Left.Left = new BinaryTreeNode(4);
            tree.Root.Left.Right = new BinaryTreeNode(5);
            tree.Root.Right.Left = new BinaryTreeNode(6);
            tree.Root.Right.Right = new BinaryTreeNode(7);
            tree.Root.Right.Left.Right = new BinaryTreeNode(8);
            tree.Root.Right.Right.Right = new BinaryTreeNode(9);
            return tree;
        }
    }
}
