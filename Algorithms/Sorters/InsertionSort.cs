using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    internal class InsertionSort : IAlgorithm
    {
        public void DoWork()
        {
            //Sort();
            int[] array = new int[] { 3, 7, 4, 2, 1, 6 };
            Console.WriteLine("Before Sorting :- ", array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            SortUsingLoops(array);

            Console.WriteLine("Sorted  array :- ", array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }

        private void SortUsingLoops(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                int valueToInsert = array[i];
                for (; j >= 0; j--)
                {
                    if (valueToInsert < array[j])
                    {
                        array[j + 1] = array[j];
                    }
                    else
                    {
                        break;
                    }
                }
                array[j + 1] = valueToInsert;
            }
        }

        private void Sort()
        {
            int[] array = new int[] { 3, 7, 4, 2, 1, 6 };
            Console.WriteLine("Before Sorting :- ", array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            for (int i = 1; i < array.Length; i++)
            {
                Insert(array, i - 1, array[i]);
            }

            Console.WriteLine("Sorted  array :- ", array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }

        private void Insert(int[] array, int rightIndex, int value)
        {
            int i = rightIndex;
            for (i = rightIndex; i >= 0; i--) //&& value < array[i]
            {
                if (value < array[i])
                {
                    array[i + 1] = array[i];
                }
                else
                {
                    break;
                }
            }

            //for (i = rightIndex; i >= 0 && value < array[i]; i--) //
            //{
            //    if (value < array[i])
            //    {
            //        array[i + 1] = array[i];
            //    }
            //}
            array[i + 1] = value;
        }
    }
}
