using System;
using Algorithms.Data_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class StackUsingArrayTests
    {
        [TestMethod]
        public void Reverse_WithFourElements_Returns_ReversedFourElements()
        {
            //Arrange
            int size = 4;
            StackUsingArray stack = new StackUsingArray(size);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            //Act
            stack.Reverse();



            //Assert

        }


    }
}
