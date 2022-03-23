using DataStructure.Chapter1.Week4;
using DataStructure.Leetcode;
using System;
using static DataStructure.Leetcode.ReverseList;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6};
            var listNode = new ListNode(nums);
            var obj = new ReverseList();
            obj.Head = listNode;
            Console.WriteLine(obj.ToString());
            obj.Head = ReverseByRecursion(listNode);
            Console.WriteLine(obj.ToString());
        }

        ////测试使用q运行opCount个进队和出队操作所需要的时间，单位：秒
        //public static double testQueue(iQueue<int> q, int count)
        //{
        //    Random r = new Random();
        //    var startTime = System.DateTime.Now;

        //    for (int i = 0; i < count; i++)
        //    {
        //        q.Enqueue(r.Next(int.MaxValue));
        //    }
        //    for (int i = 0; i < count; i++)
        //    {
        //        q.Dequeue();
        //    }

        //    var endTime = System.DateTime.Now;
        //    var ts = endTime - startTime;
        //    return ts.Milliseconds;
        //}
    }
}