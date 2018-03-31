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
            int[] array = GetArray();
            Console.WriteLine("Before Sorting :- ", array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Sort(array);
            Console.WriteLine("Sorted  array :- ", array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();

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
            Sort(array, left, partitionIndex - 1);
            Sort(array, partitionIndex, right);
        }

        private int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
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

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }
}
