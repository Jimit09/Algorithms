using Algorithms.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class TwoStacks
    {
        private int _size;
        private int _top1;
        private int _top2;
        private int[] _array;

        public TwoStacks(int size)
        {
            _size = size;
            _array = new int[size];
            _top1 = -1;
            _top2 = size;

        }

        public void push1(int element)
        {
            if (_top1 < _top2 - 1)
            {
                _top1++;
                _array[_top1] = element;
            }
            else
            {
                throw new StackOverflowException();
            }
        }

        public void push2(int element)
        {
            if (_top1 < _top2 - 1)
            {

                _top2--;
                _array[_top2] = element;
            }
            else
            {
                throw new StackOverflowException();
            }
        }

        public int pop1()
        {
            if (_top1 == -1)
            {
                throw new InSufficientDataException();
            }
            else
            {
                int retVal = _array[_top1]; ;
                _top1--;
                return retVal;
            }
        }

        public int pop2()
        {
            if (_top2 == _size)
            {
                throw new InSufficientDataException();
            }
            else
            {
                int retVal = _array[_top2];
                _top2++;
                return retVal;
            }
        }
    }
}
