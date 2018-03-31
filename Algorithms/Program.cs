using Algorithms.Data_Structures;
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
            algoToRun = new LinkedListTest();
            //algoToRun = new QuickSort();
            //algoToRun = new ReferenceSample();
            algoToRun.DoWork();
        }
    }
}
