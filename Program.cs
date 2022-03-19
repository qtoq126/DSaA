using DataStructure.Chapter1.Week4;
using System;
using static DataStructure.Leetcode.RemoveElements;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //var linkedList = new LinkedListWithDummyHead<int>();
            //for (int i = 0; i < 5; i++)
            //{
            //    linkedList.AddFirst(i);
            //    Console.WriteLine(linkedList);
            //}
            //linkedList.Add(2, 666);
            //Console.WriteLine(linkedList);

            //linkedList.Remove(2);
            //Console.WriteLine(linkedList);

            //linkedList.RemoveFirst();
            //Console.WriteLine(linkedList);

            //linkedList.RemoveLast();
            //Console.WriteLine(linkedList);

            int[] nums = { 1, 2, 5, 6, 7, 8, 9, 3 };
            var head = new ListNode(nums);
            Console.WriteLine(head);
        }

        //测试使用q运行opCount个进队和出队操作所需要的时间，单位：秒
        public static double testQueue(iQueue<int> q, int count)
        {
            Random r = new Random();
            var startTime = System.DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                q.Enqueue(r.Next(int.MaxValue));
            }
            for (int i = 0; i < count; i++)
            {
                q.Dequeue();
            }

            var endTime = System.DateTime.Now;
            var ts = endTime - startTime;
            return ts.Milliseconds;
        }
    }
}