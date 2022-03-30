using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 215：数组中的第K个最大元素
    /// Leetcode ：剑指 Offer 40. 最小的k个数
    /// 快排中双路排序的应用
    /// </summary>
    public class SelectK
    {
        /// <summary>
        /// 数组中的第 K 个最大元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            return SelectK_(nums, 0, nums.Length - 1, nums.Length - k, new Random());
        }

        /// <summary>
        /// 找出数组中最小的 K 个数
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] GetLeastNumbers(int[] arr, int k)
        {
            if (k == 0)
            {
                return new int[0];
            }
            int p = SelectK_(arr, 0, arr.Length - 1, k - 1, new Random());
            return arr.Skip(0).Take(p + 1).ToArray();
        }

        /// <summary>
        /// 找到第k个最小的元素的索引
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <param name="k"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private int SelectK_(int[] nums, int lhs, int rhs, int k, Random r)
        {
            int p = Partition(nums, lhs, rhs, r);
            if (p == k)
            {
                return p;
            }
            if (k < p)
            {
                return SelectK_(nums, lhs, p - 1, k, r);
            }
            return SelectK_(nums, p + 1, rhs, k, r);
        }

        private int Partition(int[] nums, int lhs, int rhs, Random r)
        {
            int randomIndex = r.Next(lhs, rhs + 1);
            Swap(ref nums[lhs], ref nums[randomIndex]);

            int i = lhs + 1;
            int j = rhs;

            while (true)
            {
                while (i <= j && nums[i] < nums[lhs])
                {
                    i++;
                }
                while (j >= i && nums[j] > nums[lhs])
                {
                    j--;
                }
                if (i >= j)
                {
                    break;
                }
                Swap(ref nums[i], ref nums[j]); 
                i++;
                j--;
            }
            Swap(ref nums[lhs], ref nums[j]);
            return j;
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
