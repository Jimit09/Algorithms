using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Data_Structures;
namespace Algorithms.UnitTests.LinkedListTests
{
    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void AddTwoNos_Input2Nos_ReturnsCorrectSum()
        {
            //Arrange
            MyLinkedList list1 = new MyLinkedList();
            list1.Append(5);
            list1.Append(6);
            list1.Append(3);

            MyLinkedList list2 = new MyLinkedList();
            list2.Append(8);
            list2.Append(4);
            list2.Append(2);

            MyLinkedList list = list1.AddTwoNosLeftToRight(list2);
            int i = 0;
        }
    }
}
