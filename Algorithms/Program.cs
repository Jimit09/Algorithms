using Algorithms.Data_Structures;
using Algorithms.Data_Structures.Arrays;
using Algorithms.RecrusiveAlgos;
using Algorithms.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlgorithm algoToRun;

            // Time for BinarySearch
            //algoToRun = new BinarySearch();

            //Sort using Selection sorts
            //algoToRun = new InsertionSort();

            //Factorial Using Recursions
            //algoToRun = new FactorialUsingRecursion();

            //Palindrome Using Recrusion
            //algoToRun = new Palindrome();
            //algoToRun = new Powers();
            //algoToRun = new MergeSort();
            //algoToRun = new BubbleSort();
            //algoToRun = new LinkedListTest();
            //algoToRun = new QuickSort();
            //algoToRun = new ReferenceSample();
            //algoToRun.DoWork();

            //Heap heap = new Heap();
            //int heapsize = 6;


            // int[] array = new int[] { 25, 10, 25, 10, 32 };
            // int output = solution(array);

            // Console.WriteLine("output -- " + output);
            //int[] array = new int[] { 0, 1, 4, 3, 7, 8, 9, 10 };
            //heap.BuildMaxHeap(array, heapsize);

            //int[] array = new int[] { 0, 10, 8, 9, 7, 6, 5, 4 };
            //heap.BuildMinHeap(array, heapsize);

            //int[] array = new int[] { 0, 1, 4, 3, 7, 8, 10 };
            //heap.Sort(array, heapsize);

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}


            //int[] arr = { 50, 4, 20 };
            //int k = 2;
            //int n = arr.Length / 2;

            //ArraysEx arraysEx = new ArraysEx();
            //int[] arr = { 1, 2, 3 };
            //int smallest = arraysEx.FindSmallestPositiveInt(arr);
            //Console.WriteLine(smallest);

            //// Let us create 3 stacks in an array of size 10
            //int k = 3, n = 10;

            //KStack ks = new KStack(k, n);

            //ks.push(15, 2);
            //ks.push(45, 2);

            //// Let us put some items in stack number 1
            //ks.push(17, 1);
            //ks.push(49, 1);
            //ks.push(39, 1);

            //// Let us put some items in stack number 0
            //ks.push(11, 0);
            //ks.push(9, 0);
            //ks.push(7, 0);

            //Console.WriteLine("Popped element from stack 2 is " + ks.pop(2));
            //Console.WriteLine("Popped element from stack 1 is " + ks.pop(1));
            //Console.WriteLine("Popped element from stack 0 is " + ks.pop(0));




            Console.ReadLine();
            //arraysEx.RearrangeTest();
        }   

        public static int solution(int[] A)
        {
            //write your code in C# 6.0 with .NET 4.5 (Mono)
            int max = 0;
            for (int i = 0; i < A.Length - 2; i++)
            {
                for (int j = i + 1; j < A.Length - 1; j++)
                {
                    for (int k = j + 1; k < A.Length; k++)
                    {
                        int num = A[i] * A[j] * A[k];
                        string text = num.ToString();
                        int count = text.Length - text.TrimEnd('0').Length;
                        if (max < count)
                        {
                            max = count;
                        }
                    }
                }
            }

            return max;
        }

        //int maximumZeros(int[] arr, int n, int k)
        //{
        //    // Initializing each value with -1;
        //    int[][] subset = new int[k + 1][100];

        //    subset[0][0] = 0;

        //    for (int p = 0; p < n; p++)
        //    {
        //        int pw2 = 0, pw5 = 0;

        //        // Calculating maximal power of 2 for
        //        // arr[p].
        //        while (arr[p] % 2 == 0)
        //        {
        //            pw2++;
        //            arr[p] /= 2;
        //        }

        //        // Calculating maximal power of 5 for
        //        // arr[p].
        //        while (arr[p] % 5 == 0)
        //        {
        //            pw5++;
        //            arr[p] /= 5;
        //        }

        //        // Calculating subset[i][j] for maximum
        //        // amount of twos we can collect by
        //        // checking first i numbers and taking
        //        // j of them with total power of five.
        //        for (int i = k - 1; i >= 0; i--)
        //            for (int j = 0; j < MAX5; j++)

        //                // If subset[i][j] is not calculated.
        //                if (subset[i][j] != -1)
        //                    subset[i + 1][j + pw5] =
        //                    max(subset[i + 1][j + pw5],
        //                         subset[i][j] + pw2);
        //    }

        //}
    }
}
