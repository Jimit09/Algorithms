using Algorithms.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LRUCache
    {
        public class CustomDoublyLinkedListNode
        {
            public int Data { get; set; }
            public int Key { get; set; }
            public CustomDoublyLinkedListNode previous { get; set; }
            public CustomDoublyLinkedListNode next { get; set; }
        }

        Dictionary<int, CustomDoublyLinkedListNode> dict;
        CustomDoublyLinkedListNode start, end;
        int MaxSize;

        public LRUCache()
        {
            dict = new Dictionary<int, CustomDoublyLinkedListNode>();
            MaxSize = 4;
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                Remove(node);
                AddAtTop(node);
                return node.Data;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                node.Data = value;
                Remove(node);
                AddAtTop(node);
            }
            else
            {
                CustomDoublyLinkedListNode node = new CustomDoublyLinkedListNode();
                node.Data = value;
                node.previous = null;
                node.next = null;
                node.Key = key;
                if (dict.Count > MaxSize)
                {
                    dict.Remove(end.Key);
                    Remove(end);
                }
                AddAtTop(node);
                dict.Add(key, node);
            }
        }

        public void AddAtTop(CustomDoublyLinkedListNode node)
        {
            node.next = start;
            node.previous = null;
            if (start != null)
            {
                start.previous = start;
            }
            start = node;
            if (end == null)
            {
                end = start;
            }
        }

        public void Remove(CustomDoublyLinkedListNode node)
        {
            if (node.previous != null)
            {
                node.previous.next = node.next;
            }
            else
            {
                start = node.next;
            }

            if (node.next != null)
            {
                node.next.previous = node.previous;
            }
            else
            {
                end = node.previous;
            }
        }
    }
}
