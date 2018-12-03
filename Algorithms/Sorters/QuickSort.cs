using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    class QuickSort : BaseSorter, IAlgorithm
    {
        public void DoWork()
        {
            int[] array = GetArray(); // new int[] { 9, 7, 8, 3, 2, 1 };
            Console.WriteLine("Before Sorting :- ", array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
            Sort(array);
            //quicksort(array);
            Console.WriteLine("Sorted  array :- ", array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
            //ReadLine();

        }

        private void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = array[(left + right) / 2];
            int partitionIndex = Partition(array, left, right, pivot);
            //Sort the elements less than partition and greater than partition
            Sort(array, left, partitionIndex - 1);
            Sort(array, partitionIndex + 1, right);
        }

        private int Partition(int[] array, int left, int right, int pivot)
        {
            while (left < right)
            {
                //Move left pointer untill u find element to be moved to the right.
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(array, left, right);
                }
            }
            return left;
        }

        void quicksort(int[] A)
        {
            quicksort(A, 0, A.Length - 1);
        }

        void quicksort(int[] A, int start, int end)
        {
            if (start < end)
            {
                //stores the position of pivot element
                int piv_pos = PartitionHackerEarth(A, start, end);
                quicksort(A, start, piv_pos - 1);    //sorts the left side of pivot.
                quicksort(A, piv_pos + 1, end); //sorts the right side of pivot.
            }
        }

        int PartitionHackerEarth(int[] A, int start, int end)
        {
            int i = start + 1;
            int piv = A[start];            //make the first element as pivot element.
            for (int j = start + 1; j <= end; j++)
            {
                /*rearrange the array by putting elements which are less than pivot
                   on one side and which are greater that on other. */

                if (A[j] < piv)
                {
                    Swap(A, i, j);
                    i += 1;
                }
            }
            Swap(A, start, i - 1);  //put the pivot element in its proper place.
            return i - 1;                      //return the position of the pivot
        }

        private void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }
}
