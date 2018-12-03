using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    public abstract class BaseSorter
    {
        internal void Display(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}\t", array[i]);
            }
            Console.WriteLine();
        }

        protected int[] GetArray()
        {
            int[] array = new int[] { 3, 7, 4, 2, 0, 1, 6, -9, 20, 5 };
            return array;
        }

        protected int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
