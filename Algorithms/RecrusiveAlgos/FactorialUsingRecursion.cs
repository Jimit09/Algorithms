using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RecrusiveAlgos
{
    internal class FactorialUsingRecursion: IAlgorithm
    {
        public void DoWork()
        {
            Factorial();
        }

        private void Factorial()
        {
            Console.WriteLine("Enter the number for which factorial needs to be calculated");
            int n = 0;
            Int32.TryParse(Console.ReadLine(), out n);
            int output = Factorial(n);
            Console.WriteLine("Factorial of n is:- {0}", output);
            Console.ReadLine();
        }

        private int Factorial(int n) {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }


    }
}
