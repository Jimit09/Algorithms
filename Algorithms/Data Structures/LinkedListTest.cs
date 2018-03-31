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
            Node node = null;
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
            Node result = MergeLists(linkedList1.head, linkedList2.head);
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
            Node firstNode = linkedList.head;
            Node currentNode = linkedList.head;
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

        private void DisplayLinkedList(Node node)
        {
            Console.WriteLine();
            Node current = node;
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
            Node node1 = linkedList.head;
            if (node1 == null || node1.Next == null)
            {
                return false;
            }
            Node node2 = linkedList.head.Next;
            while (node1 != null && node2 != null && node2.Next != null)
            {
                if (node1 == node2)
                    return true;
                node1 = node1.Next;
                node2 = node2.Next.Next;
            }
            return false;
        }

        public static Node MergeLists(Node headA, Node headB)
        {
            // This is a "method-only" submission.
            // You only need to complete this method
            Node result = null;
            Node head = null;

            while (headA != null && headB != null)
            {
                if (headA.Data < headB.Data)
                {
                    if (result == null)
                    {
                        result = headA;
                        head = headA;
                    }
                    else
                    {
                        result.Next = headA;
                        result = result.Next;
                    }
                    headA = headA.Next;
                }
                else
                {
                    if (result == null)
                    {
                        result = headB;
                        head = headB;
                    }
                    else
                    {
                        result.Next = headB;
                        result = result.Next;
                    }
                    headB = headB.Next;
                }
            }

            while (headA != null)
            {
                if (result == null)
                {
                    result = headA;
                    head = headA;
                }
                else
                {
                    result.Next = headA;
                    result = result.Next;
                }
                headA = headA.Next;
            }

            while (headB != null)
            {
                if (result == null)
                {
                    result = headB;
                    head = headB;
                }
                else
                {
                    result.Next = headB;
                    result = result.Next;
                }
                headB = headB.Next;
            }

            return head;
        }

        public static int GetNode(Node head, int positionFromTail)
        {
            // This is a "method-only" submission.
            // You only need to complete this method.
            int counter = -1;
            return FindNode(head, ref positionFromTail, ref counter);
        }

        private static int FindNode(Node head, ref int positionFromTail, ref int counter)
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

        private int FindMergeNode(Node headA, Node headB)
        {
            // Complete this function
            // Do not write the main method.
            int result = 0;

            bool mergePointFound = false;
            while (headA != null && !mergePointFound)
            {
                Node currentB = headB;
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
