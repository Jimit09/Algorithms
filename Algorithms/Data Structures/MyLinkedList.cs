using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class MyLinkedList
    {
        internal MyLinkedListNode head { get; private set; }

        internal MyLinkedListNode append(int data)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            if (head == null)
            {
                head = newNode;
                return head;
            }
            MyLinkedListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            return head;
        }

        internal void prepend(int data)
        {
            if (head == null)
            {
                head = new MyLinkedListNode(data);
                return;
            }
            MyLinkedListNode newNode = new MyLinkedListNode(data);
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
            MyLinkedListNode current = head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                }
                current = current.Next;
            }
        }

        internal MyLinkedListNode InsertNth(int data, int position)
        {
            int indexToInsert = 0;
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            MyLinkedListNode prev = null;
            if (head == null)
            {
                head = newNode;
                return head;
            }
            MyLinkedListNode current = head;
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

        public MyLinkedListNode Delete(MyLinkedListNode head, int position)
        {
            int deleteAtIndex = 0;
            MyLinkedListNode current = head;
            MyLinkedListNode prev = null;

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

        static MyLinkedList DeleteDuplicates(MyLinkedList linkedList)
        {
            DeleteDuplicates(linkedList.head);
            return linkedList;
        }

        private static MyLinkedListNode DeleteDuplicates(MyLinkedListNode head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            HashSet<int> set = new HashSet<int>();
            MyLinkedListNode previous = head;
            MyLinkedListNode current = head.Next;
            set.Add(head.Data);
            while (current != null)
            {
                if (set.Contains(current.Data))
                {
                    previous.Next = current.Next;
                    current = previous.Next;
                }
                else
                {
                    set.Add(current.Data);
                    previous = current;
                    current = current.Next;
                }
            }
            return head;
        }
    }
}
