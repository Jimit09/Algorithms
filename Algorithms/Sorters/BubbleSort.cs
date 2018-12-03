using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    internal class BubbleSort : BaseSorter, IAlgorithm
    {
        public void DoWork()
        {
            Sort();
        }

        private void Sort()
        {
            int[] array = GetArray();
            Console.WriteLine("Before Sorting:-");
            Display(array);
            //Sort(array);
            BubbleSortAgain(array);
            Console.WriteLine("After Sorting:-");
            Display(array);
            Console.ReadLine();
        }

        private void Sort(int[] array)
        {
            bool unSorted = false;
            int unsortedCount = array.Length - 1;
            while (!unSorted)
            {
                unSorted = true;
                for (int i = 0; i < unsortedCount; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        unSorted = false;
                    }
                }
                unsortedCount--;
            }
        }

        private void Swap(int[] array, int i, int v)
        {
            int temp = array[i];
            array[i] = array[v];
            array[v] = temp;
        }

        private void BubbleSortAgain(int[] arrayToSort)
        {
            int endIndex = arrayToSort.Length - 1;
            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {

                for (int j = 0; j < arrayToSort.Length - 1 - i; j++)
                {
                    if (arrayToSort[i] > arrayToSort[i + i])
                    {
                        Swap(arrayToSort, i, i + 1);
                    }
                }
            }
        }
    }
}
