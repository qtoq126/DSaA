using DataStructure.Sort;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Sort
{
    public class SortHelper
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
        /// 元素换位
        /// </summary>
        public static void Swap<T>(T[] arr, int i, int j)
        {
            var t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
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
                SelectionSort.Sort(arr);
            }
            else if (sortName == "InsertSort")
            {
                InsertSort.Sort(arr);
            }
            else if (sortName == "MergeSort")
            {
                MergeSort.Sort(arr);
            }
            else if (sortName == "MergeSortBU")
            {
                MergeSort.SortBU(arr);
            }
            else if (sortName == "QuickSort")
            {
                QuickSort.Sort(arr);
            }
            else if (sortName == "QuickSort1")
            {
                QuickSort.Sort1(arr);
            }
            else if (sortName == "HeapSort")
            {
                HeapSort.Sort(arr);
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
