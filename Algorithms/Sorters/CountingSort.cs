using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    /// The complexity of Counting Sort is BigTheta(N + Max(array[N])) is no of elements in array & max element of the array.
    /// </summary>
    public class CountingSort : BaseSorter, IAlgorithm
    {
        public CountingSort()
        {
        }

        public void DoWork()
        {
            int[] array = new int[] { 9, 7, 8, 3, 2, 1 };
            Console.WriteLine("Before Sorting :- ");
            Display(array);
            Sort1(array);
            Console.WriteLine("Sorted  array :- ");
            Display(array);
        }

        public void Sort(int[] array)
        {
            int max = GetMax(array);
            int[] auxArray = new int[max + 1];

            for (int i = 0; i < auxArray.Length; i++)
            {
                auxArray[i] = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                auxArray[array[i]]++;
            }
            int j = 0;
            for (int i = 0; i < auxArray.Length; i++)
            {
                int count = auxArray[i];
                while (count > 0)
                {
                    array[j] = i;
                    count--;
                    j++;
                }
            }
        }

        public void Sort1(int[] array)
        {
            int max = GetMax(array);
            int[] auxArray = new int[max + 1];

            for (int i = 0; i < auxArray.Length; i++)
            {
                auxArray[i] = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                auxArray[array[i]]++;
            }

            for (int i = 1; i < auxArray.Length; i++)
            {
                auxArray[i] = auxArray[i] + auxArray[i - 1];
            }
            int[] sortedArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sortedArray[auxArray[array[i]] - 1] = array[i];
                auxArray[array[i]]--;
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedArray[i];
            }
        }
    }
}
