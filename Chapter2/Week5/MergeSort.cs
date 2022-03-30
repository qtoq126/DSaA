using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter2.Week5
{
    /// <summary>
    /// 归并排序法
    /// 递归思路:
    /// 1. 先定义宏观语义 MergeSort(arr[], l, r)： 对数组的从l到r的区间进行排序
    /// 2. mid = (l + r) / 2：划分为平均的两块
    /// 3. MergeSort(arr[], l, mid): 对左侧一半进行归并排序
    /// 4. MergeSort(arr[], mid + 1, r)：对右侧一半进行归并排序
    /// 5. Merge(arr[], l, mid, r): 合并（将两个有序数组合并成一个有序数组）
    /// 6. O(nlogn)：递归树（有log2^n层，每一次是O(n)）
    /// 适合大数据规模，规模越大，优势越大
    /// </summary>
    public class MergeSort
    {
        private static int res = 0;

        /// <summary>
        /// 自顶向下的递归方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Sort<T>(T[] arr) where T: IComparable
        {
            MergeSort_(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// 通过归并算法计算数组中的逆序列对数（数组中前面的一个数大于后面的数）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int InversePairs<T>(T[] arr) where T : IComparable
        {
            MergeSort_(arr, 0, arr.Length - 1);
            return res;
        }

        private static void MergeSort_<T>(T[] arr, int lhs, int rhs) where T : IComparable
        {
            if (lhs >= rhs)
            {
                return;
            }
            int mid = (lhs + rhs) / 2; // 可能会越界溢出 mid = lhs + (rhs - lhs) / 2
            MergeSort_(arr, lhs, mid);
            MergeSort_(arr, mid + 1, rhs);
            Merge(arr, lhs, mid, rhs);
        }

        /// <summary>
        /// 自底向上的方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void SortBU<T>(T[] arr) where T : IComparable
        {
            int n = arr.Length;
            // 遍历合并的区间长度
            for (int sz = 1; sz < n; sz += sz)
            {
                // 遍历合并的两个区间的起始位置[i, i+sz) 和 [i+sz, i+sz+sz)
                for (int i = 0; i + sz < n; i += sz + sz)
                {
                    Merge(arr, i, i + sz - 1, Math.Min(i + sz + sz - 1, n - 1));
                }
            }
        }

        private static void Merge<T>(T[] arr, int lhs, int mid, int rhs) where T : IComparable
        {
            if (arr[mid].CompareTo(arr[mid + 1]) < 0 ) // 左半数组都比右半数组小，整个数组已有序
            {
                return;
            }
            var copyArr = (T[])arr.Clone(); // 利用了辅助空间，不是原地排序算法
            int i = lhs;
            int j = mid + 1;
            for (int k = lhs; k <= rhs; k++)
            {
                if (i > mid)
                {
                    arr[k] = copyArr[j++];
                }
                else if (j > rhs)
                {
                    arr[k] = copyArr[i++]; 
                }
                else if (copyArr[i].CompareTo(copyArr[j]) < 0)
                {
                    arr[k] = copyArr[i++];
                }
                else
                {
                    res += mid - i + 1;
                    arr[k] = copyArr[j++];
                }
            }
        }
    }
}
