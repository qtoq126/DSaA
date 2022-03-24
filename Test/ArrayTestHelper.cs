using DataStructure.Chapter1.Week2;
using DataStructure.Chapter2.Week5;
using DataStructure.Chapter2.Week6;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Test
{
    public class ArrayTestHelper
    {
        /// <summary>
        /// 生成随机数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int[] GeneratorArray(int n, int maxValue)
        {
            int[] arr = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(maxValue);
            }
            return arr;
        }

        /// <summary>
        /// 是否成功排序了
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static bool IsSorted<T>(T[] arr) where T: IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SortTest(string sortName, int[] arr)
        {
            var startTime = System.DateTime.Now;

            if (sortName == "SelectionSort")
            {
                SelectionSort.Sort(ref arr);
            }
            else if (sortName == "InsertSort")
            {
                InsertSort.Sort(ref arr);
            }
            else if (sortName == "MergeSort")
            {
                MergeSort.Sort(ref arr);
            }
            else if (sortName == "MergeSortBU")
            {
                MergeSort.SortBU(ref arr);
            }
            else if (sortName == "QuickSort")
            {
                QuickSort.Sort(ref arr);
            }

            if (!IsSorted(arr))
            {
                throw new Exception(sortName + " Sort Failed!!!");
            }

            DateTime afterDT = System.DateTime.Now;

            //Console.WriteLine(string.Join(",", arr));

            var ts = afterDT.Subtract(startTime);
            Console.WriteLine($"{sortName}: n={arr.Length}, 总耗时={ts.TotalSeconds}s.");

            Console.WriteLine();
        }
    }
}
