using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter1.Week4
{
    /// <summary>
    /// 采用虚拟头节点的链表
    /// </summary>
    public class LinkedListWithDummyHead<T> where T: IEquatable<T>
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

        private Node dummyHead;
        private int size;

        public LinkedListWithDummyHead()
        {
            this.dummyHead = new Node(default, null);
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

            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            prev.next = new Node(element, prev.next);
            size++;
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

            Node cur = dummyHead.next;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            return cur.element;
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

            Node cur = dummyHead.next;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            cur.element = element;
        }

        /// <summary>
        /// 查找链表中是否有元素e
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contain(T element)
        {
            Node cur = dummyHead.next;
            while (cur != null)
            {
                if (cur.element.Equals(element))
                {
                    return true;
                }
                cur = cur.next;
            }
            return false;
        }

        /// <summary>
        /// 删除链表的第index（0-based）个位置的的元素
        /// </summary>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException("Remove Failed!");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            var delNode = prev.next;
            prev.next = delNode.next;
            delNode.next = null;
            size--;
            return delNode.element;
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
            Node cur = dummyHead.next;
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
