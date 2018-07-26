using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class QueueUsingLinkedList
    {
        MyLinkedListNode head;//Remove using head
        MyLinkedListNode tail;//Add using tail

        void EnQueue(int data)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            if (tail != null)
            {
                tail.Next = newNode;
            }
            else
            {
                tail = newNode;
                head = newNode;
            }
        }

        int DeQueue()
        {
            if (head == null)
            {
                Console.WriteLine("There are no items in the queues");
                return -1;
            }
            int data = head.Data;
            if (head.Next == null)
            {
                tail = null;
            }
            head = head.Next;
            return data;
        }

        int Peak()
        {
            if (head == null)
            {
                Console.WriteLine("There are no items in the queues");
            }
            return head.Data;
        }
    }
}
