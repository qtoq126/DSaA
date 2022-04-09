using DataStructure.Chapter1;
using DataStructure.Chapter2;
using DataStructure.Leetcode;
using DataStructure.Test;
using DataStructure.Tree;
using System;
using System.Linq;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = { 1, 1, 3, 3 ,5, 5};
            //QuickSort.Partition3(arr, 0, arr.Length - 1, new Random());
            //var objectK = new BinarySearch();


            var bst = new BinarySearchTree();
            int[] piles = { 41, 22, 58, 15, 33, 50, 63, 13, 37, 42, 53 };
            //int[] piles = { 13, 23, 10};
            foreach (var p in piles)
            {
                bst.Add(p);
            }

            bst.Depth();

            var ret = bst.Rank(58);
            var e = bst.Select(58);
            Console.WriteLine();

            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"{i} : {bst.Select(i)}");
            }
            Console.WriteLine();

            //bst.InOrder();

            //bst.PreOrder();

            //bst.RemoveMin();

            //bst.InOrder();
            //Console.WriteLine();

            //bst.PostOrder();
            //Console.WriteLine();

            //Console.WriteLine(string.Join(",", arr));

            //ArrayTestHelper.SortTest("QuickSort", ref arr1);
            //ArrayTestHelper.SortTest("QuickSort1", ref arr1);

            //Console.WriteLine(arr1[0]);

            //DateTime startTime = System.DateTime.Now;

            //QuickSort.Partition(ref arr1, 0, arr1.Length - 1);

            //DateTime afterDT = System.DateTime.Now;

            ////Console.WriteLine(string.Join(",", arr));

            //var ts = afterDT.Subtract(startTime);
            //Console.WriteLine($"bobo: n={arr1.Length}, 总耗时={ts.TotalSeconds}s.");



            //startTime = System.DateTime.Now;


            //QuickSort.Partition2(ref arr2, 0, arr2.Length - 1);

            //afterDT = System.DateTime.Now;

            ////Console.WriteLine(string.Join(",", arr));

            //ts = afterDT.Subtract(startTime);
            //Console.WriteLine($"myself: n={arr2.Length}, 总耗时={ts.TotalSeconds}s.");

            //var listNode = new ListNode(nums);
            //var obj = new ReverseList();
            //obj.Head = listNode;
            //Console.WriteLine(obj.ToString());
            //obj.Head = ReverseByRecursion(listNode);
            //Console.WriteLine(obj.ToString());
            //SelectionSort.Sort(ref nums);
            //MergeSort.Sort(ref nums);
            //Console.WriteLine(string.Join(",", nums));

            //var arr1 = ArrayTestHelper.GeneratorArray(1000, 1000);
            //var arr2 = (int[])arr1.Clone();

            // ArrayTestHelper.SortTest("InsertSort", arr1);
            //ArrayTestHelper.SortTest("MergeSort", arr1);
            //ArrayTestHelper.SortTest("MergeSortBU", arr2);
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