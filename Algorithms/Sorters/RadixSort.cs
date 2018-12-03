using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    public class RadixSort : BaseSorter, IAlgorithm
    {
        public void DoWork()
        {
            int[] array = new int[] { 9, 7, 8, 3, 2, 1 };
            Console.WriteLine("Before Sorting :- ");
            Display(array);
            Sort(array);
            Console.WriteLine("Sorted  array :- ");
            Display(array);
        }

        public void Sort(int[] array)
        {
            int max = GetMax(array);
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                Sort(array, exp);
            }
        }

        private void Sort(int[] array, int exp)
        {
            int[] output = new int[array.Length];

            int[] count = new int[10];

            //Initialize the array with 0's 
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }

            //Count for each index position i.e from 0-9 digits
            for (int i = 0; i < array.Length; i++)
            {
                count[(array[i] / exp) % 10]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = 0; i < array.Length; i++)
            {
                output[count[(array[i] / exp) % 10]] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
