using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 203
    /// </summary>
    public class RemoveElements
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
                StringBuilder sb = new StringBuilder();
                ListNode cur = this;
                while (cur != null)
                {
                    sb.Append(cur.val + "->");
                    cur = cur.next;
                }
                sb.Append("NULL");
                return sb.ToString();
            }
        }

        public ListNode RemoveElementsOnLinkedList(ListNode head, int val)
        {
            var dummyHead = new ListNode(0, head);
            ListNode prev = dummyHead;
            while (prev.next != null)
            {
                if (prev.next.val == val)
                {
                    prev.next = prev.next.next;
                }
                prev = prev.next;
            }
            return dummyHead.next;
        }
    }
}
