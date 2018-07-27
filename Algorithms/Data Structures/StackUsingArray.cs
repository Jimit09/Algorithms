using Algorithms.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class StackUsingArray
    {
        int[] array;
        int top;
        public StackUsingArray(int size)
        {
            array = new int[size];
            top = -1;
        }

        public void Push(int element)
        {
            if (top++ >= array.Length)
            {
                throw new StackOverflowException();
            }
            array[top] = element;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InsufficientDataException();
            }
            int retVal = array[top--];
            return retVal;
        }

        public bool IsEmpty()
        {
            return top < 0 ? true : false;
        }

        public int Peak()
        {
            if (IsEmpty())
            {
                throw new InsufficientDataException();
            }
            int retVal = array[top];
            return retVal;
        }

    }
}
