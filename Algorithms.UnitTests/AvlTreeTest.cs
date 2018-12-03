using System;
using System.Collections.Generic;
using Algorithms.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class AvlTreeTest
    {
        [TestMethod]
        public void Insert_NineNodes_InsertsInCorrectOrder()
        {
            AvlTree avlTree = new AvlTree();
            avlTree.Root = avlTree.Insert(avlTree.Root, 10);
            avlTree.Root = avlTree.Insert(avlTree.Root, 20);
            avlTree.Root = avlTree.Insert(avlTree.Root, 30);
            avlTree.Root = avlTree.Insert(avlTree.Root, 40);
            avlTree.Root = avlTree.Insert(avlTree.Root, 50);
            avlTree.Root = avlTree.Insert(avlTree.Root, 25);

            List<AvlTreeNode> list = avlTree.GetInOrder(avlTree.Root);

            int i = 0;

        }


    }
}
