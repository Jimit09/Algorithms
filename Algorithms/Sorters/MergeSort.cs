using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    internal class MergeSort : IAlgorithm
    {
        public void DoWork()
        {
            Sort();
        }

        private void Sort()
        {
            int[] array = new int[] { 10, -9, 4, 7, 18, 20, 0, -15 };

            Console.WriteLine("Before Sorting:-");
            Display(array);
            Sort(array, 0, array.Length - 1);
            Console.WriteLine("After Sorting");
            Display(array);
            Console.ReadLine();
        }

        private void Display(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}\\t", array[i]);
            }
        }

        private void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var middleIndex = (startIndex + endIndex) / 2;
            Sort(array, startIndex, middleIndex);
            Sort(array, middleIndex + 1, endIndex);
            Merge(array, startIndex, middleIndex, endIndex);
        }

        private void Merge(int[] array, int startIndex, int middleIndex, int endIndex)
        {
            int[] lowHalf = new int[middleIndex - startIndex + 1];
            int[] highHalf = new int[endIndex - middleIndex];
            int k = 0;
            for (int i = 0; i <= middleIndex; i++, k++)
            {
                lowHalf[i] = array[k];
            }

            for (int i = 0; k <= endIndex; i++, k++)
            {
                highHalf[i] = array[k];
            }

            int m = 0, n = 0;
            k = startIndex;
            while (m < lowHalf.Length && n < highHalf.Length)
            {
                if (lowHalf[m] < highHalf[n])
                {
                    array[k] = lowHalf[m];
                    m++;
                }
                else
                {
                    array[k] = highHalf[n];
                    n++;
                }
                k++;
            }

            while (m < lowHalf.Length)
            {
                array[k] = lowHalf[m];
                m++;
                k++;
            }

            while (n < highHalf.Length)
            {
                array[k] = highHalf[n];
                n++;
                k++;
            }


        }
    }
}
