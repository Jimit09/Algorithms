using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class Heap
    {
        public void BuildMaxHeap(int[] array, int heapsize)
        {
            for (int i = heapsize / 2; i >= 1; i--)
            {
                Max_Heapify(array, i, heapsize);
            }
        }

        private void Max_Heapify(int[] array, int index, int heapsize)
        {
            //Calculate Left child
            int leftChildIndex = 2 * index;
            //Calculate Right child index
            int rightChildIndex = (2 * index + 1);
            int largest = index;
            if (leftChildIndex <= heapsize && array[leftChildIndex] > array[index])
            {
                largest = leftChildIndex;
            }

            if (rightChildIndex <= heapsize && array[rightChildIndex] > array[largest])
            {
                largest = rightChildIndex;
            }

            if (largest != index)
            {
                Swap(array, largest, index);
                Max_Heapify(array, largest, heapsize);
            }
        }

        public void BuildMinHeap(int[] array, int heapsize)
        {
            for (int i = heapsize / 2; i >= 1; i--)
            {
                MinHeapify(array, i, heapsize);
            }
        }

        private void MinHeapify(int[] array, int index, int heapsize)
        {
            int leftChildIndex = index * 2;
            int rightChildIndex = index * 2 + 1;

            int smallest = index;

            if (leftChildIndex <= heapsize && array[leftChildIndex] < array[smallest])
            {
                smallest = leftChildIndex;
            }

            if (rightChildIndex <= heapsize && array[rightChildIndex] < array[smallest])
            {
                smallest = rightChildIndex;
            }

            if (smallest != index)
            {
                Swap(array, smallest, index);
                MinHeapify(array, smallest, heapsize);
            }
        }

        private void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        //Heap Sort
        public void Sort(int[] array, int heapsize)
        {
            BuildMaxHeap(array, heapsize);

            for (int i = heapsize; i >= 2; i--)
            {
                //Swap max element, which is at position 1 in  max heap with element i.
                Swap(array, 1, i);
                //As the max element in the current iteration is placed to its 
                //correct position in the sorted array keep processing in the
                //remaining front part of the unsorted array.
                heapsize--;
                //Always max heapify from the max element position i.e index 1 so that array is max heapfied.
                Max_Heapify(array, 1, heapsize);
            }

        }

        //Priority Queue implementation
        //Complexity:-  O(1)
        int GetMaximum(int[] array)
        {
            return array[1];
        }

        int ExtractMaximum(int[] array, int heapSize)
        {
            if (heapSize == 0)
            {
                return -1;
            }

            int maxElement = array[1];
            array[heapSize] = array[1];
            --heapSize;

            Max_Heapify(array, 1, heapSize);
            return maxElement;
        }

        void IncreaseValue(int[] array, int index, int newValue)
        {
            if (array[index] >= newValue)
            {
                throw new InvalidInputException();
            }
            array[index] = newValue;

            while (index > 1 && array[index / 2] < array[index])
            {
                Swap(array, index, index / 2);
                index = index / 2;
            }
        }

        //TODO:- heapSize should be class variable.
        //Complexity: O(n)
        void Insert(int[] array, int value, int heapSize)
        {
            ++heapSize;
            //assuming all the numbers greater than int.MinValue are to be inserted in queue.
            array[heapSize] = int.MinValue;
            IncreaseValue(array, heapSize, value);
        }
    }
}
