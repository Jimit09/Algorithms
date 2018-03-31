using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class MyLinkedList
    {
        internal Node head { get; private set; }

        internal void append(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        internal void prepend(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        internal void deleteWithValue(int data)
        {
            if (head == null)
            {
                return;
            }
            if (head.Data == data)
            {
                head = head.Next;
                return;
            }
            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                }
                current = current.Next;
            }
        }

        internal Node InsertNth(int data, int position)
        {
            int indexToInsert = 0;
            Node newNode = new Node(data);
            Node prev = null;
            if (head == null)
            {
                head = newNode;
                return head;
            }
            Node current = head;
            while (indexToInsert < position)
            {
                prev = current;
                current = current.Next;
                indexToInsert++;
            }
            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                newNode.Next = current;
                prev.Next = newNode;
            }
            return head;
        }

        public Node Delete(Node head, int position)
        {
            int deleteAtIndex = 0;
            Node current = head;
            Node prev = null;

            while (deleteAtIndex < position)
            {
                prev = current;
                current = current.Next;
                deleteAtIndex++;
            }
            if (position == 0)
            {
                head = head.Next;
            }
            else
            {
                prev.Next = current.Next;
            }
            return head;
        }
    }
}
