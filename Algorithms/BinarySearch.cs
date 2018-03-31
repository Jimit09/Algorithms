using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class BinarySearch: IAlgorithm
    {
        internal static void DoSearch()
        {
            int[] array = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            Console.WriteLine("Input the guessNo");
            int guessNo = Convert.ToInt32(Console.ReadLine());
            DoSearch(array, guessNo);
        }

        private static void DoSearch(int[] array, int guessNo)
        {
            int min = 0; int max = array.Length - 1;
            int guessIndex = 0;
            bool continueSearching = true;
            while (continueSearching)
            {
                if (min > max)
                {
                    Console.WriteLine("min > max. Invalid input. The no is not a prime");
                    break;
                }

                guessIndex = Convert.ToInt32(Math.Floor((min + max) / 2.0));
                Console.WriteLine(String.Format("GuessIndex = {0}", guessIndex));
                if (array[guessIndex] == guessNo)
                {
                    continueSearching = false;
                    Console.WriteLine("The guess no is found!!");
                }
                else if (array[guessIndex] < guessNo)
                {
                    Console.WriteLine("array[guessIndex] < guessNo.");
                    min = guessIndex + 1;
                    Console.WriteLine(String.Format("New min = {0}", min));
                }
                else
                {
                    Console.WriteLine("array[guessIndex] > guessNo.");
                    max = guessIndex - 1;
                    Console.WriteLine(String.Format("New max = {0}", max));
                }


            }
            Console.ReadLine();
        }

        public void DoWork()
        {
            DoSearch();
        }
    }
}
