using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Sort
{
    /// <summary>
    /// 冒泡排序
    /// 每次置换出最大（小）的那个元素（放到尾部）
    /// </summary>
    public class BubbleSort
    {
        private BubbleSort() { }

        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        SortHelper.Swap(arr, j, j + 1);
                    }
                }
            } 
        }

        public static void Sort2<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var isSwapped = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        isSwapped = true;
                        SortHelper.Swap(arr, j, j + 1);
                    }
                }
                // 若某一次循环中一次都没有互换，说明已经达到了有序
                if (!isSwapped)
                {
                    return;
                }
            }
        }
    }
}
