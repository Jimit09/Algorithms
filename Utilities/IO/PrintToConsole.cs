using System;

namespace Utilities.IO
{
    public class PrintToConsole
    {
        public static void print(int[] elementsToSort)
        {
            for (int i = 0; i < elementsToSort.Length; i++)
            {
                Console.WriteLine(elementsToSort[i]);
            }
        }

    }
}
