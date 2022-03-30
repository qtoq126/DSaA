using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 75：颜色分类
    /// 快排中三路排序的案例
    /// </summary>
    public class SortColors
    {
        public static void SortColors_(int[] nums)
        {
            int lt = -1;
            int gt = nums.Length;
            int i = 0;
            while (i < gt)
            {
                if (nums[i] == 0)
                {
                    lt++;
                    Swap(ref nums[i], ref nums[lt]);
                    i++;
                }
                else if (nums[i] == 2)
                {
                    gt--;
                    Swap(ref nums[i], ref nums[gt]);
                }
                else
                {
                    i++;
                }
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
