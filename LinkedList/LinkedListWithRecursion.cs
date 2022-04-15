using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.LinkedList
{
    /// <summary>
    /// 采用递归的链表
    /// </summary>
    public class LinkedListWithRecursion<T> where T : IEquatable<T>
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

        public LinkedListWithRecursion()
        {
            head = null;
            size = 0;
        }

        public int GetSize() => size;

        public bool IsEmpty() => size == 0;

        /// <summary>
        /// 在链表的index（0-based）位置添加新元素element
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Add(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Add Failed!");
            }

            head = Add(head, index, element);
            size++;
        }

        /// <summary>
        /// 以node为头节点的链表index位置插入元素e，递归
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private Node Add(Node node, int index, T element)
        {
            if (index == 0)
            {
                return new Node(element, node);
            }
            node.next = Add(node.next, index - 1, element);
            return node;
        }

        public void AddFirst(T element) => Add(0, element);

        public void AddLast(T element) => Add(size, element);

        /// <summary>
        /// 获得链表的第index（0-based）个位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Get Failed!");
            }

            return Get(head, index);
        }

        private T Get(Node node, int index)
        {
            if (index == 0)
            {
                return node.element;
            }
            return Get(node.next, index - 1);
        }

        public T GetFirst() => Get(0);

        public T GetLast() => Get(size - 1);

        /// <summary>
        /// 修改链表的第index（0-based）个位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Set(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Set Failed!");
            }

            Set(head, index, element);
        }

        private void Set(Node node, int index, T element)
        {
            if (index == 0)
            {
                node.element = element;
                return;
            }
            Set(node.next, index - 1, element);
        }

        /// <summary>
        /// 查找链表中是否有元素e
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            return Contains(head, element);
        }

        private bool Contains(Node node, T element)
        {
            if (node == null)
            {
                return false;
            }
            if (node.element.Equals(element))
            {
                return true;
            }
            return Contains(node.next, element);
        }

        /// <summary>
        /// 删除链表的第index（0-based）个位置的的元素
        /// </summary>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            { 
                throw new ArgumentOutOfRangeException("Remove Failed!");
            }
            KeyValuePair<Node, T> res = Remove(head, index);
            size--;
            head = res.Key;
            return res.Value;
        }

        private KeyValuePair<Node, T> Remove(Node node, int index)
        {
            if (index == 0)
            {
                return new KeyValuePair<Node, T>(node.next, node.element);
            }
            var res = Remove(node.next, index - 1);
            node.next = res.Key;
            return new KeyValuePair<Node, T>(node, res.Value);
        }

        public T RemoveFirst() => Remove(0);

        public T RemoveLast() => Remove(size - 1);

        /// <summary>
        /// 重写ToString()方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node cur = head;
            while (cur != null)
            {
                sb.Append(cur + "->");
                cur = cur.next;
            }
            sb.Append("NULL");
            return sb.ToString();
        }
    }
}
