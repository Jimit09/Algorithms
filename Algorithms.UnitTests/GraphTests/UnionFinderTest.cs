using System;
using Algorithms.Data_Structures.Graph.UnionFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests.GraphTests
{
    [TestClass]
    public class UnionFinderTest
    {
        [TestMethod]
        public void Should_GraphWithCycles_CheckHasCycles_ReturnsHasCycles()
        {
            //Arrange
            Graph graph = new Graph(3, 3);

            graph.Edges[0].Source = 0;
            graph.Edges[0].Destination = 1;

            graph.Edges[1].Source = 1;
            graph.Edges[1].Destination = 2;

            graph.Edges[2].Source = 0;
            graph.Edges[2].Destination = 2;

            //Act  
            var hasCycle = graph.HasCycle();

            //Assert    
            Assert.IsTrue(hasCycle);
        }
    }
}
