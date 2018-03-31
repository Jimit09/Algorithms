using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RecrusiveAlgos
{
    internal class Powers : IAlgorithm
    {
        public void DoWork()
        {
            CalculatePowers();
        }

        private void CalculatePowers()
        {
            int baseVal = 0, NthPower = 0;
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if (Int32.TryParse(input1, out baseVal) && Int32.TryParse(input2, out NthPower))
            {
                int result = Power(baseVal, NthPower);
                Console.WriteLine("{0} ^ {1} = {2}", baseVal, NthPower, result);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            Console.ReadLine();
        }

        private int Power(int baseVal, int nthPower)
        {
            if (nthPower == 0)
            {
                return 1;
            }
            else if (nthPower < 0)
            {
                return 1 / Power(baseVal, -nthPower);
            }
            else if (IsOdd(nthPower))
            {
                return baseVal * Power(baseVal, nthPower - 1);
            }
            else//Only case left is nth is positive even number.
            {
                var result = Power(baseVal, nthPower / 2);
                return result * result;
            }
        }

        private bool IsEven(int n)
        {
            return (n % 2 == 0);
        }

        private bool IsOdd(int n)
        {
            return !IsEven(n);
        }
    }
}
