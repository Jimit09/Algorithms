using System;
using Algorithms.Data_Structures.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests.StackTests
{
    [TestClass]
    public class InfixToPostFixTest
    {
        [TestMethod]
        public void ShouldConvertInfixToPostFix()
        {
            InfixToPostFix obj = new InfixToPostFix();
            string input = "a+b*(c^d-e)^(f+g*h)-i";
            string expected = "abcd^e-fgh*+^*+i-";
            string result = obj.Convert(input);
            Assert.AreEqual<string>(expected, result);
        }

        [TestMethod]
        public void ShouldConvertPrefixToInfix()
        {
            PrefixToInfix obj = new PrefixToInfix();
            string input = "*-A/BC-/AKL";
            string expected = "((A-(B/C))*((A/K)-L))";
            string result = obj.Convert(input);
            Assert.AreEqual<string>(expected, result);
        }


    }
}
