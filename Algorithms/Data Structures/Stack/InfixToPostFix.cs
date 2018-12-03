using Algorithms.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Stack
{
    public class InfixToPostFix
    {
        public InfixToPostFix()
        {

        }

        private int GetPrecedence(char value)
        {
            if (value == '+' || value == '-')
            {
                return 1;
            }
            else if (value == '*' || value == '/')
            {
                return 2;
            }
            else if (value == '^')
            {
                return 3;
            }
            return -1;
        }

        public string Convert(string input)
        {
            string result = "";
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (isOperand(ch))
                {
                    result += ch;
                }
                else if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    while (stack.Count != 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }
                    if (stack.Pop() != '(')
                    {
                        throw new InvalidInputException();
                    }
                }
                else
                {
                    while (stack.Count != 0 && GetPrecedence(ch) <= GetPrecedence(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(ch);
                }
            }

            while (stack.Count != 0)
            {
                result += stack.Pop();
            }
            return result;
        }

        private bool isOperand(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= 0 && ch <= 9))
            {
                return true;
            }
            return false;
        }
    }
}
