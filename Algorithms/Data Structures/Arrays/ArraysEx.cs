using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Arrays
{
    public class ArraysEx
    {
        /// <summary>
        /// This complexity of this solution is O(n^2)
        /// </summary>
        public List<Tuple<int, int>> FindUnqiueSetUsingDoubleForLoop(int[] array)
        {
            List<Tuple<int, int>> listOfSets = new List<Tuple<int, int>>();
            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = i + 1; j < array.Count(); j++)
                {
                    if (array[i] == array[j])
                    {
                        listOfSets.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            return listOfSets;
        }

        public int FindUnqiueSetCountUsingDoubleForLoop(int[] array)
        {
            List<Tuple<int, int>> list = FindUnqiueSetUsingDoubleForLoop(array);
            return list.Count;
        }

        /// <summary>
        ///  This complexity of this solution is still O(n^2) as
        ///  Combination formula is applied.
        /// </summary>
        public int FindUnqiueSetUsingFactorial(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < array.Count(); i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    ++dict[array[i]];
                }
                else
                {
                    dict.Add(array[i], 1);
                }
            }
            int result = CalculatePairWithFactorial(dict);
            return result;
        }

        private int CalculatePairWithFactorial(Dictionary<int, int> dict)
        {
            int count = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict[i] > 1)
                {
                    //Applying combination formula n!/(n -r)! *r! to find unique pair
                    count = factorial(dict[i]) /
                        (factorial(2) * factorial(dict[i] - 2));
                }
            }
            return count;
        }

        private int factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        ///  This complexity of this solution is still O(n) as
        ///  Combination formula is applied.
        /// </summary>
        public int FindUnqiueSetWithBigOofN(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < array.Count(); i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    ++dict[array[i]];
                }
                else
                {
                    dict.Add(array[i], 1);
                }
            }
            int result = CalculatePairWithResolvedCombinationFormula(dict);
            return result;
        }

        private int CalculatePairWithResolvedCombinationFormula(Dictionary<int, int> dict)
        {
            int count = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict[i] > 1)
                {
                    //Applying combination formula n!/(n -r)! *r! to find unique pair
                    count += (dict[i] * (dict[i] - 1)) / 2;
                }
            }
            return count;
        }

        static int[] ReverseArray(int[] a)
        {
            /*
             * Write your code here.
             */
            int start = 0;
            int end = a.Length - 1;

            while (start < end)
            {
                Swap(a, start, end);
                ++start;
                --end;
            }
            return a;
        }

        static void Swap(int[] arr, int index1, int index2)
        {

            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }


        public void RearrangeTest()
        {
            int[] res;

            int _elements_size = 0;
            _elements_size = Convert.ToInt32(Console.ReadLine());
            int[] _elements = new int[_elements_size];
            int _elements_item;
            for (int _elements_i = 0; _elements_i < _elements_size; _elements_i++)
            {
                _elements_item = Convert.ToInt32(Console.ReadLine());
                _elements[_elements_i] = _elements_item;
            }

            res = Rearrange(_elements);
            for (int res_i = 0; res_i < res.Length; res_i++)
            {
                Console.WriteLine(res[res_i]);
            }

            Console.ReadLine();
        }

        int[] Rearrange(int[] elements)
        {
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            for (int i = 0; i < elements.Length; i++)
            {
                string s = ToBinary(elements[i]);
                //s.Where(r => r == '1').
                list.Add(new Tuple<int, string>(elements[i], s));
            }


            //
            // list.Where(r => r.Item2 )

            int[] Sort(int[] elementsToSort)
            {


                return elementsToSort;
            }

            return new int[] { 1, 2, 3 };
        }

        static string ToBinary(int num)
        {
            return Convert.ToString(num, 2);
        }


        /* Write a function:

 class Solution { public int solution(int[] A); }

         that, given an array A of N integers, returns the smallest positive integer(greater than 0) that does not occur in A.

        For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

 Given A = [1, 2, 3], the function should return 4.

 Given A = [−1, −3], the function should return 1.

 Assume that:

 N is an integer within the range[1..100, 000];
 each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].
 Complexity:

 expected worst-case time complexity is O(N);
         expected worst-case space complexity is O(N) (not counting the storage required for input arguments).
         */

        public int FindSmallestPositiveInt(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            HashSet<int> map = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!map.Contains(A[i]))
                {
                    map.Add(A[i]);
                }
            }
            for (int j = 1; j < A.Length; j++)
            {
                if (!map.Contains(j))
                {
                    return j;
                }
            }
            return 1;
        }


        //        Sort an array of 0,1,2
        //        Input :  0, 1, 2, 0, 1, 2
        //        Output : 0, 0, 1, 1, 2, 2
        //        Input :  1, 2, 0, 0, 2, 1, 2, 0
        //        Output : 0, 0, 0, 1, 1, 2, 2, 2
        // Only 3 nos are there and also sort need to support in place. 
        void Sort(int[] array)
        {

            int lowIndex = -1;
            int highIndex = array.Length;
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] == 0)
                {
                    lowIndex++;

                }
                else if (array[i] == 2)
                {
                    highIndex--;
                }

                if (lowIndex < highIndex)
                {
                    Swap(array, lowIndex, highIndex);
                }

            }
        }

        //Complexity is O(n) i.e O(n) for iterating through array. And O(n), when there will be no pairs in the array.
        public static int GetIndenticalPairCount(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    dict[array[i]]++;
                }
                else
                {
                    dict[array[i]] = 0;
                }
            }
            int totalPairCount = 0;
            foreach (var item in dict)
            {
                int value = item.Value;
                totalPairCount += (value * (value - 1)) / 2;
            }
            return totalPairCount;
        }

        //public static void Main()
        //{
        //    int[] array = new int[] { 3, 5, 2, 3, 3, 5 };
        //    int countOfIdenticalPair = GetIndenticalPairCount(array);
        //    Console.WriteLine("The identical pairs in givn array is {0}", countOfIdenticalPair);
        //    Console.ReadLine();
        //}
    }
}
