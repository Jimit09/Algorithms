using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RecrusiveAlgos
{
    internal class Palindrome : IAlgorithm
    {
        public void DoWork()
        {
            CheckPalindrome();
        }

        private void CheckPalindrome()
        {
            Console.WriteLine("Enter the number if Palindrome:-");
            string inputVal = Console.ReadLine();
            bool result = IsPalindrome(inputVal);
            Console.WriteLine("The string {0} is Palindrome:- {1}", inputVal, result );
            Console.ReadLine();
        }

        private bool IsPalindrome(string value)
        {
            if (value.Length <= 1)
            {
                return true;
            }
            if (value.Last() != value.First())
            {
                return false;
            }

            return IsPalindrome(value.Substring(1, value.Length - 2));
        }

    }
}
