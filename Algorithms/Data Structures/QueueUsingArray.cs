using Algorithms.BusinessExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class QueueUsingArray
    {
        int rear;
        int front;
        int _capacity;
        int[] array;

        public QueueUsingArray(int capacity)
        {
            _capacity = capacity;
            array = new int[capacity];
            rear = front = -1;
        }

        public void EnQueue(int item)
        {
            if (isFull())
            {
                throw new StackOverflowException();
            }
            else if (IsEmpty())
            {
                front = 0;
                rear = 0;
            }
            else
            {
                rear = (rear + 1) % _capacity;
            }
            array[rear] = item;
        }


        public int DeQueue()
        {
            if (IsEmpty())
            {
                throw new InsufficientDataException();
            }
            int retVal = array[front];
            if (front == rear)
            {
                front = rear = -1;
            }
            else
            {
                front = (front + 1) % _capacity;
            }
            return retVal;
        }

        public bool IsEmpty()
        {
            return front == -1 && rear == -1;
        }

        public bool isFull()
        {
            return ((rear + 1) % _capacity) == front;
        }

        public int GetFront()
        {
            if (IsEmpty())
            {
                throw new InsufficientDataException();
            }
            return array[front];
        }
    }
}
