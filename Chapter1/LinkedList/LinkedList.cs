using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter1.Week4
{
    /// <summary>
    /// 普通链表
    /// </summary>
    public class LinkedList<T> 
    {
        private class Node
        {
            public T element;
            public Node next;

            public Node(T element, Node next)
            {
                this.element = element;
                this.next = next;
            }

            public Node(T element)
            {
                this.element = element;
                this.next = null;
            }

            public Node()
            {
                this.element = default;
                this.next = null;
            }

            public override string ToString()
            {
                return element.ToString();
            }
        }

        private Node head;
        private int size;

        public LinkedList()
        {
            this.head = null;
            size = 0;
        }
        
        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void AddFirst(T element)
        {
            head = new Node(element, head);
            size++;
        }

        public void Add(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Add Failed!");
            }
            if (index == 0)
            {
                AddFirst(element);
            }
            else
            {
                Node prev = head;
                for (int i = 0; i < index - 1; i++)
                {
                    prev = prev.next;
                }
                prev.next = new Node(element, prev.next);
                size++;
            }
        }

        public void AddLast(T element)
        {
            Add(size, element);
        }
    }
}
