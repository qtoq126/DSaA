using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 206 翻转链表
    /// </summary>
    public class ReverseList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public ListNode(int[] arr)
            {
                if (arr == null || arr.Length == 0)
                {
                    throw new ArgumentException("arr can not be empty or null!");
                }
                val = arr[0];
                ListNode cur = this;
                for (int i = 1; i < arr.Length; i++)
                {
                    cur.next = new ListNode(arr[i]);
                    cur = cur.next;
                }
            }

            public override string ToString()
            {
                return val.ToString();
            }
        }

        public ListNode Head { get; set; }

        /// <summary>
        /// 重写ToString()方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            while (Head != null)
            {
                sb.Append(Head + "->");
                Head = Head.next;
            }
            sb.Append("NULL");
            return sb.ToString();
        }

        public static ListNode Reverse(ListNode head)
        {
            ListNode pre = null;
            var cur = head;
            while (cur != null)
            {
                var next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }

        public static ListNode ReverseByRecursion(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var revListNode = ReverseByRecursion(head.next); // 把握递归函数的宏观语义（对head.next所在的头节点的链表进行翻转）
            head.next.next = head; // 翻转后处理唯一一个没有反转的head节点（此时的head仍然指向的是以head.next为头节点反转之后的尾节点上，将该尾节点指向head即可）
            head.next = null; // 将整个反转后的尾节点的next置为null
            return revListNode;
        }
    }
}
