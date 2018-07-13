using System;
using System.Collections.Generic;
using Algorithms.Data_Structures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class ArrayExTests
    {
        ArraysEx arrayEx;

        [TestInitialize]
        public void SetUp()
        {
            arrayEx = new ArraysEx();
        }

        [TestMethod]
        public void DisplayUniqueSet()
        {
            //Arrange
            int[] array = new int[] { 3, 7, 4, 3, 3, 4 };

            //Act
            List<Tuple<int, int>> list = arrayEx.FindUnqiueSetUsingDoubleForLoop(array);

            //Assert
            List<Tuple<int, int>> expectedResult = new List<Tuple<int, int>>() {
                new Tuple<int, int>( 0, 3 ),
                new Tuple<int, int>( 0, 4 ),
                new Tuple<int, int>( 2, 5 ),
                new Tuple<int, int>( 3, 4 )
            };
            Assert.IsTrue(Compare(list, expectedResult));
        }

        [TestMethod]
        public void FindUnqiueSetCountUsingDoubleForLoop_4UniqueSets_ReturnsCountOf4()
        {
            //Arrange
            int[] array = new int[] { 3, 7, 4, 3, 3, 4 };

            //Act
            int result = arrayEx.FindUnqiueSetCountUsingDoubleForLoop(array);

            //Assert
            int expectedResult = 4;
            

            Assert.IsTrue(result == expectedResult);
        }



        private bool Compare(List<Tuple<int, int>> list, List<Tuple<int, int>> expectedList)
        {
            if (list.Count != expectedList.Count)
            {
                return false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 != expectedList[i].Item2 &&
                    list[i].Item2 != expectedList[i].Item2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
