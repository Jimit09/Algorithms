using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    internal class SelectionSort : IAlgorithm
    {
        public void DoWork()
        {
            int[] array = new int[] { 4, 10, 3, 2, 100, 45 };
            DoSelectionSort(array);
        }

        private void DoSelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = IndexOfMinimum(array, i);
                //The following if condition is just simple optimization. 
                //If the element is already at the right index in the array then avoid swapping,
                //although this won't affect its performance of O(n^2) as it is trivial 
                //and swapping takes contant time. 
                if (i != j)
                {
                    Swap(i, j, array);
                }
            }
        }

        private void Swap(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index2] = temp;
            array[index1] = temp;
        }

        private int IndexOfMinimum(int[] array, int startIndex)
        {
            int resultIndex = startIndex;
            for (int i = startIndex + 1; i < array.Count(); i++)
            {
                if (array[i] < array[resultIndex])
                {
                    resultIndex = i;
                }
            }
            return resultIndex;
        }
    }
}
