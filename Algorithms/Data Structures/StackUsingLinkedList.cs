using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class StackUsingLinkedList
    {
        MyLinkedListNode top;

        void Push(int data)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            newNode.Next = top;
            top = newNode;
        }

        int Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("No items to Pop from the Stack");
            }
            int data = top.Data;
            top = top.Next;
            return data;
        }

        int Peak()
        {
            if (top == null)
            {
                throw new InvalidOperationException("No items to Pop from the Stack");
            }
            return top.Data;
        }
    }
}
