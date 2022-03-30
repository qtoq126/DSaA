using DataStructure.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter1.Week2
{
    /// <summary>
    /// 选择排序法
    /// 算法逻辑：每一次找到数组中最小的那一个元素
    /// O(n^2)
    /// </summary>
    public class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T: IComparable
        {
            int minIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }

        /// <summary>
        /// 换位
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
