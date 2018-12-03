using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class MyLinkedList
    {
        public MyLinkedListNode Head { get; set; }

        public MyLinkedListNode Append(int data)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            if (Head == null)
            {
                Head = newNode;
                return Head;
            }
            MyLinkedListNode current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            return Head;
        }

        internal void Prepend(int data)
        {
            if (Head == null)
            {
                Head = new MyLinkedListNode(data);
                return;
            }
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            newNode.Next = Head;
            Head = newNode;
        }

        internal void DeleteWithValue(int data)
        {
            if (Head == null)
            {
                return;
            }
            if (Head.Data == data)
            {
                Head = Head.Next;
                return;
            }
            MyLinkedListNode current = Head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    break;
                }
                current = current.Next;
            }
        }

        internal MyLinkedListNode InsertNth(int data, int position)
        {
            int indexToInsert = 0;
            MyLinkedListNode newNode = new MyLinkedListNode(data);
            if (Head == null)
            {
                Head = newNode;
                return Head;
            }
            MyLinkedListNode current = Head;
            MyLinkedListNode prev = null;
            while (indexToInsert < position)
            {
                prev = current;
                current = current.Next;
                indexToInsert++;
            }
            if (position == 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                newNode.Next = current;
                prev.Next = newNode;
            }
            return Head;
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
            DeleteDuplicates(linkedList.Head);
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

        public MyLinkedList AddTwoNosLeftToRight(MyLinkedList list2)
        {
            MyLinkedList list = new MyLinkedList();

            MyLinkedListNode node1 = this.Head;
            MyLinkedListNode node2 = list2.Head;
            MyLinkedListNode node = null;
            MyLinkedListNode head = list.Head;
            int carry = 0;
            while (node1 != null || node2 != null)
            {
                int no1 = node1 != null ? node1.Data : 0;
                int no2 = node2 != null ? node2.Data : 0;

                int sum = no1 + no2 + carry;
                int n = sum % 10;
                carry = sum / 10;

                if (list.Head == null)
                {
                    node = new MyLinkedListNode(n);
                    list.Head = node;
                }
                else
                {
                    node.Next = new MyLinkedListNode(n);
                    node = node.Next;
                }
                if (node1 != null)
                {
                    node1 = node1.Next;
                }
                if (node2 != null)
                {
                    node2 = node2.Next;
                }
            }

            if (carry > 0)
            {
                node.Next = new MyLinkedListNode(carry);
            }

            return list;
        }

        public MyLinkedList AddTwoNosRightToLeft(MyLinkedList list2)
        {
            MyLinkedList list1 = this;
            MyLinkedList list = new MyLinkedList();
            int size1 = Size(list1);
            int size2 = Size(list2);
            int carry = 0;
            //Always list1 should point to larger list;
            MyLinkedListNode resultHead;
            if (size1 < size2)
            {
                MyLinkedList temp = list1;
                list1 = list2;
                list2 = temp;
                int diff = Math.Abs(size1 - size2);
                MyLinkedListNode startNode = null;
                MyLinkedListNode node = list1.Head;
                while (diff > 0)
                {
                    startNode = node;
                    node = node.Next;
                }
                resultHead = AddTwoNosRightToLeft(startNode, list2.Head, ref carry);
                PropogateCarry(list1.Head, startNode, resultHead, ref carry);
            }
            else
            {
                resultHead = AddTwoNosRightToLeft(list1.Head, list2.Head, ref carry);
            }
            list.Head = resultHead;
            return list;
        }

        private void PropogateCarry(MyLinkedListNode head, MyLinkedListNode startNode, MyLinkedListNode resultHead, ref int carry)
        {
            if (head != startNode)
            {
                PropogateCarry(head.Next, startNode, resultHead, ref carry);
                int sum = carry = head.Data;
                MyLinkedListNode newNode = new MyLinkedListNode(sum % 10);
                carry = sum / 10;
                newNode.Next = resultHead;
                resultHead = newNode;
            }
        }

        private int Size(MyLinkedList list)
        {
            int size = 0;
            MyLinkedListNode node = list.Head;
            while (node != null)
            {
                size++;
                node = node.Next;
            }
            return size;
        }

        private MyLinkedListNode AddTwoNosRightToLeft(MyLinkedListNode node1, MyLinkedListNode node2, ref int carry)
        {
            if (node1 == null && node2 == null)
            {
                return null;
            }
            else
            {
                MyLinkedListNode nextNode = AddTwoNosRightToLeft(node1, node2, ref carry);
                int sum = node1.Data + node2.Data + carry;
                carry = sum / 10;
                MyLinkedListNode node = new MyLinkedListNode(sum % 10);
                node.Next = nextNode;
                return node;
            }
        }
    }
}
