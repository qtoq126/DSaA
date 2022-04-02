using DataStructure.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter1.Week2
{
    /// <summary>
    /// 插入排序法
    /// 算法逻辑：每次处理一个值，将其插入到前面已排好序的集合中
    /// O(n^2)：整体
    /// O(n)：对于有序数组
    /// 适合小规模的数据
    /// </summary>
    public class InsertSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var temp = arr[i];
                for (int j = i; j - 1 >= 0 && temp.CompareTo(arr[j - 1]) < 0; j--)
                {
                    arr[j] = arr[j - 1]; // 可以不通过交换而通过平移解决
                }
            }
        }
    }
}
