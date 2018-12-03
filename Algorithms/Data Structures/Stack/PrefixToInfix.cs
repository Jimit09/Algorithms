using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Stack
{
    public class PrefixToInfix
    {
        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
            }
            return false;
        }

        public string Convert(string str)
        {
            Stack<string> stack = new Stack<string>();
            string result = "";
            int length = str.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                char ch = str[i];
                if (isOperator(ch))
                {
                    string operand1 = stack.Pop();
                    string operand2 = stack.Pop();

                    string final = "(" + operand1 + ch + operand2 + ")";
                    stack.Push(final);
                }
                else
                {
                    stack.Push(ch.ToString());
                }
            }
            result = stack.Pop();
            return result;
        }
    }
}
