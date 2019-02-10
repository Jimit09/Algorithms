using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Stack
{
    public class BalancedParenthesis
    {
        // Complete the isBalanced function below.
        public bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            bool retVal = true;
            foreach (char ch in s)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (stack.Count != 0 && IsMatch(ch, stack.Pop()))
                {
                    continue;
                }
                else
                {
                    retVal = false;
                    break;
                }
            }
            if (stack.Count != 0)
            {
                retVal = false;
            }
            return retVal;
        }

        private bool IsMatch(char ch2, char ch1)
        {
            if ((ch1 == '(' && ch2 == ')') || (ch1 == '[' && ch2 == ']') || (ch1 == '{' && ch2 == '}'))
            {
                return true;
            }
            return false;
        }
    }
}
