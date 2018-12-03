using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public static class StackUsingArrayExtensions
    {
        // reverses the given stack using
        // InsertAtBottom()
        public static void Reverse(this StackUsingArray stack)
        {
            if (!stack.IsEmpty())
            {
                // Hold all items in Function
                // Call Stack until we
                // reach end of the stack 
                int popVal = stack.Pop();
                stack.Reverse();
                // Insert all the items held
                // in Function Call Stack
                // one by one from the bottom
                // to top. Every item is
                // inserted at the bottom
                stack.InsertAtBottom(popVal);
            }
        }

        // Below is a recursive function 
        // that inserts an element
        // at the bottom of a stack.
        private static void InsertAtBottom(this StackUsingArray stack, int element)
        {
            if (stack.IsEmpty())
            {
                stack.Push(element);
            }
            else
            {
                // All items are held in Function
                // Call Stack until we reach end
                // of the stack. When the stack becomes
                // empty, the st.size() becomes 0, the
                // above if part is executed and 
                // the item is inserted at the bottom
                int value = stack.Pop();
                stack.InsertAtBottom(element);
                // push allthe items held 
                // in Function Call Stack
                // once the item is inserted 
                // at the bottom
                stack.Push(value);
            }
        }

        //TODO: Refactor and move this Print to Utilities 
        public static void PrintTopToBottom(this StackUsingArray stack)
        {
            if (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
                stack.PrintTopToBottom();
            }
        }
    }
}
