using DataStructure.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Sort
{
    /// <summary>
    /// 选择排序法
    /// 算法逻辑：每一次找到数组中最小的那一个元素
    /// O(n^2)
    /// </summary>
    public class SelectionSort
    {
        private SelectionSort() { }

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
                SortHelper.Swap(arr, i, minIndex);
            }
        }
    }
}
