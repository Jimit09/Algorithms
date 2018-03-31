using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    internal abstract class BaseSorter
    {
        internal void Display(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0}\t", array[i]);
            }
        }

        internal int[] GetArray()
        {
            int[] array = new int[] { 3, 7, 4, 2, 0, 1, 6, -9, 20, 5 };
            return array;
        }
    }
}
