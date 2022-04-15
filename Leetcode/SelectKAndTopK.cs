using DataStructure.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Leetcode
{
    /*
     * 快排：O(n)
     * 优先队列：O(nlogk)
     * 优先队列的优势在于以下几项：
     * 1. 不需要一次性知道所有数据（数据以「数据流」的形式产生）
     * 比如：对于一个游戏排行榜，想要实时知道已经完成任务的所有玩家中的第前K名是谁
     * 2. 数据规模极大
     * 比如：数据有1T，内存先加载前k的数，然后其他的数一个个的读取进来
     */

    /// <summary>
    /// SelectK: Leetcode 215：数组中的第K大的元素
    /// TopK: Leetcode 剑指 Offer 40：最小的k个数
    /// 快排中双路排序的应用
    /// 优先队列的应用（二叉堆）
    /// </summary>
    public class SelectKAndTopK
    {
        /// <summary>
        /// 数组中的第K大的元素（快速排序）
        /// </summary>
        public int FindKthLargest(int[] nums, int k)
        {
            return SelectK_(nums, 0, nums.Length - 1, nums.Length - k, new Random());
        }

        ///// <summary>
        ///// 数组中最小的K个数（最小堆）
        ///// </summary>
        //public int FindKthLargestByMinHeap(int[] nums, int k)
        //{
        //    // 使用最小堆
        //    MinHeap<Integer> pq = new MinHeap<>();
        //    for (int i = 0; i < k; i++)
        //        pq.add(nums[i]);

        //    for (int i = k; i < nums.Length; i++)
        //        if (!pq.isEmpty() && nums[i] > pq.findMin())
        //            // 我们可以直接使用我们封装 Heap 类中的 replace
        //            pq.replace(nums[i]);

        //    return pq.findMin();
        //}

        /// <summary>
        /// 数组中最小的K个数（快速排序）
        /// </summary>
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
        /// 数组中最小的K个数（最大堆）
        /// </summary>
        public int[] GetLeastNumbersByMaxHeap(int[] arr, int k)
        {
            var pq = new PriorityQueue<int>();
            for (int i = 0; i < k; i++)
            {
                pq.Enqueue(arr[i]);
            }
            for (int i = k; i < arr.Length; i++)
            {
                // 比前k个最小元素中最大的元素（队首）要小，则入队（每次换出最大的元素，最后所有的元素都是较小的）
                if (!pq.IsEmpty() && arr[i] < pq.GetFront())
                {
                    pq.Dequeue();
                    pq.Enqueue(arr[i]);
                }
            }
            int[] res = new int[k];
            for (int i = 0; i < k; i++)
            {
                res[i] = pq.Dequeue();
            }
            return res;
        }

        /// <summary>
        /// 找到第k小的元素的索引
        /// </summary>
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

        /// <summary>
        /// 找到第k个最小的元素的索引(非递归)
        /// </summary>
        private int SelectK_N(int[] nums, int k, Random random)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l >= r)
            {
                int p = Partition(nums, l, r, random);
                if (p == k)
                {
                    return p;
                }
                if (k < p)
                {
                    r = p - 1;
                }
                else
                {
                    l = p + 1;
                }
            }
            throw new Exception("No Solution");
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
        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
