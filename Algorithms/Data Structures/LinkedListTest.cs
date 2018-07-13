using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    internal class LinkedListTest : IAlgorithm
    {
        public void DoWork()
        {
            //TestLinkedList();
            TestMergeLinkedList();
        }

        private void TestLinkedList()
        {
            Console.WriteLine("Preparing linked list");
            List<int> dataPoints = new List<int>() { 3, 2, 10, 3, 5 };
            MyLinkedListNode node = null;
            MyLinkedList linkedList = CreateLinkedList(dataPoints);

            Console.WriteLine("Displaying Linked List");
            DisplayLinkedList(linkedList.head);

            //MakeCycle(linkedList);
            Console.WriteLine("Detecting any cycle");
            string message = "The Linked list " + (HasCycles(linkedList) ? " is cyclic" : "is not cyclic");
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private void TestMergeLinkedList()
        {
            Console.WriteLine("Preparing linked list");
            List<int> dataPoints = new List<int>() { 1, 3, 7, 9, 13 };
            MyLinkedList linkedList1 = CreateLinkedList(dataPoints);
            dataPoints = new List<int>() { 2, 4, 8 };
            MyLinkedList linkedList2 = CreateLinkedList(dataPoints);
            MyLinkedListNode result = MergeLists1(linkedList1.head, linkedList2.head);
            Console.WriteLine("Displaying Linked List");
            DisplayLinkedList(result);
            Console.ReadLine();
        }

        private MyLinkedList CreateLinkedList(List<int> dataPoints)
        {
            MyLinkedList linkedList = new MyLinkedList();
            for (int i = 0; i < dataPoints.Count; i++)
            {
                linkedList.append(dataPoints[i]);
            }
            return linkedList;
        }

        private bool MakeCycle(MyLinkedList linkedList)
        {
            MyLinkedListNode firstNode = linkedList.head;
            MyLinkedListNode currentNode = linkedList.head;
            if (firstNode == null || firstNode.Next == null)
            {
                return false;
            }
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = firstNode;
            return true;
        }

        private void DisplayLinkedList(MyLinkedListNode node)
        {
            Console.WriteLine();
            MyLinkedListNode current = node;
            if (node == null)
            {
                Console.WriteLine("This is an empty list");
            }
            while (current != null)
            {
                Console.Write("{0}\t", current.Data);
                current = current.Next;
            }
            Console.WriteLine();
        }

        //Used method of two pointers with different increment count.
        //Note here the first Node increments by one.Second one increments by two.
        //Think of two cars with varying speeds eventually will pass through each other in race track.
        //Refer HackerRank video on cycle in LinkedList
        private bool HasCycles(MyLinkedList linkedList)
        {
            MyLinkedListNode node1 = linkedList.head;
            if (node1 == null || node1.Next == null)
            {
                return false;
            }
            MyLinkedListNode node2 = linkedList.head.Next;
            while (node1 != null && node2 != null && node2.Next != null)
            {
                if (node1 == node2)
                    return true;
                node1 = node1.Next;
                node2 = node2.Next.Next;
            }
            return false;
        }

        public static MyLinkedListNode MergeLists(MyLinkedListNode headA, MyLinkedListNode headB)
        {
            // This is a "method-only" submission.
            // You only need to complete this method
            MyLinkedListNode resultCurrent = null;
            MyLinkedListNode resultHead = null;

            while (headA != null && headB != null)
            {
                if (headA.Data < headB.Data)
                {
                    if (resultCurrent == null)
                    {
                        resultCurrent = headA;
                        resultHead = headA;
                    }
                    else
                    {
                        resultCurrent.Next = headA;
                        resultCurrent = resultCurrent.Next;
                    }
                    headA = headA.Next;
                }
                else
                {
                    if (resultCurrent == null)
                    {
                        resultCurrent = headB;
                        resultHead = headB;
                    }
                    else
                    {
                        resultCurrent.Next = headB;
                        resultCurrent = resultCurrent.Next;
                    }
                    headB = headB.Next;
                }
            }

            while (headA != null)
            {
                if (resultCurrent == null)
                {
                    resultCurrent = headA;
                    resultHead = headA;
                }
                else
                {
                    resultCurrent.Next = headA;
                    resultCurrent = resultCurrent.Next;
                }
                headA = headA.Next;
            }

            while (headB != null)
            {
                if (resultCurrent == null)
                {
                    resultCurrent = headB;
                    resultHead = headB;
                }
                else
                {
                    resultCurrent.Next = headB;
                    resultCurrent = resultCurrent.Next;
                }
                headB = headB.Next;
            }

            return resultHead;
        }

        public static MyLinkedListNode MergeLists1(MyLinkedListNode headA, MyLinkedListNode headB)
        {
            // This is a "method-only" submission.
            // You only need to complete this method
            MyLinkedListNode resultCurrent = null;
            MyLinkedListNode resultHead = null;

            while (headA != null && headB != null)
            {
                MyLinkedListNode newNode = null;
                if (headA.Data < headB.Data)
                {
                    newNode = new MyLinkedListNode(headA.Data);
                    headA = headA.Next;
                }
                else
                {
                    newNode = new MyLinkedListNode(headB.Data);
                    headB = headB.Next;
                }
                if (resultHead == null)
                {
                    resultHead = newNode;
                    resultCurrent = newNode;
                }
                else
                {
                    resultCurrent.Next = newNode;
                    resultCurrent = resultCurrent.Next;
                }
            }

            while (headA != null)
            {
                MyLinkedListNode newNode = new MyLinkedListNode(headA.Data);
                if (resultHead == null)
                {
                    resultHead = newNode;
                    resultCurrent = newNode;
                }
                else
                {
                    resultCurrent.Next = newNode;
                    resultCurrent = resultCurrent.Next;
                }
                headA = headA.Next;
            }

            while (headB != null)
            {
                MyLinkedListNode newNode = new MyLinkedListNode(headB.Data);
                if (resultHead == null)
                {
                    resultHead = newNode;
                    resultCurrent = newNode;
                }
                else
                {
                    resultCurrent.Next = newNode;
                    resultCurrent = resultCurrent.Next;
                }
                headB = headB.Next;
            }

            return resultHead;
        }

        public static int GetNode(MyLinkedListNode head, int positionFromTail)
        {
            int counter = -1;
            return FindNode(head, ref positionFromTail, ref counter);
        }

        private static int FindNode(MyLinkedListNode head, ref int positionFromTail, ref int counter)
        {
            if (head.Next == null)
            {
                counter = 0;
                if (positionFromTail == counter)
                {
                    return head.Data;
                }
                else
                {
                    return -1;
                }
            }

            int prevNodeVal = FindNode(head.Next, ref positionFromTail, ref counter);
            if (positionFromTail == counter)
            {
                return prevNodeVal;
            }
            counter++;
            if (positionFromTail == counter)
            {
                return head.Data;
            }
            return -1;
        }

        public static MyLinkedListNode GetNodeFromTail(MyLinkedListNode head, int positionFromTail)
        {
            int counter = 0;
            MyLinkedListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
                counter++;
            }

            counter = (counter - 1) - positionFromTail;
            current = head;
            while (counter != 0)
            {
                current = current.Next;
                --counter;
            }
            //int i = 0;
            //while (i <= counter)
            //{
            //    current = current.Next;
            //    i++;
            //}
            return current;
        }



        /*
         * 
         * Given pointers to the head nodes of  linked lists that merge together at some point, 
         * find the Node where the two lists merge. It is guaranteed that the two head
         * Nodes will be different, and neither will be NULL.

In the diagram below, the two lists converge at Node x:

[List #1] a--->b--->c
                     \
                      x--->y--->z--->NULL
                     /
     [List #2] p--->q
Complete the int FindMergeNode(Node* headA, Node* headB) method so that it finds
and returns the data value of the Node where the two lists merge.
         * 
         */

        private int FindMergeNode(MyLinkedListNode headA, MyLinkedListNode headB)
        {
            // Complete this function
            // Do not write the main method.
            int result = 0;

            bool mergePointFound = false;
            while (headA != null && !mergePointFound)
            {
                MyLinkedListNode currentB = headB;
                while (currentB != null && !mergePointFound)
                {
                    if (headA == currentB)
                    {
                        mergePointFound = true;
                        result = headA.Data;
                        break;
                    }
                    currentB = currentB.Next;
                }
                currentB = headB;
                headA = headA.Next;
            }
            return result;
        }

    }
}
