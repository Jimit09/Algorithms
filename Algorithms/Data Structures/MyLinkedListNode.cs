﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures
{
    public class MyLinkedListNode
    {
        public MyLinkedListNode Next { get; set; }
        public int Data { get; set; }

        public MyLinkedListNode(int data)
        {
            this.Data = data;
        }
    }
}
