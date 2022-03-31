using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter2
{
    /// <summary>
    /// 二分查找法
    /// 前置条件：处理有序数组（先排序）
    /// 先找中间元素，比它小则找左边中间，比它大则找右边中间，递归下去
    /// O(logn)
    /// </summary>
    public class BinarySearch
    {
        public bool Search<T>(T[] arr, T target) where T : IComparable
        {
            return SearchR(arr, 0, arr.Length - 1, target);
        }

        /// <summary>           
        /// 递归方式
        /// </summary>
        private bool SearchR<T>(T[] arr, int l, int r, T target) where T : IComparable
        {
            if (l > r)
            {
                return false;
            }
            // double m = (l + r) / 2; 可能会产生溢出
            int mid = l + (r - l) / 2;
            var midVal = arr[mid];
            if (target.Equals(midVal))
            {
                return true;
            }
            if (target.CompareTo(midVal) < 0)
            {
                return SearchR(arr, l, mid - 1, target);
            }
            return SearchR(arr, mid + 1, r, target);
        }

        /// <summary>           
        /// 非递归方式
        /// </summary>
        private bool SearchN<T>(T[] arr, T target) where T : IComparable
        {
            int l = 0;
            int r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid].Equals(target))
                {
                    return true;
                }
                if (target.CompareTo(arr[mid]) < 0)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return false;
        }

        /// <summary>
        /// 寻找大于target的最小索引
        /// </summary>
        public int ToUpper<T>(T[] arr, T target) where T : IComparable
        {
            int l = 0;
            int r = arr.Length;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid].CompareTo(target) <= 0)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            return l;
        }

        /// <summary>
        /// 寻找小于target的最大索引
        /// </summary>
        public int ToLower<T>(T[] arr, T target) where T : IComparable
        {
            int l = -1;
            int r = arr.Length - 1;
            while (l < r)
            {
                // Warning!
                // 例如 {1，1，3，3，5，5，} target = 2
                // l = 0, r= 1（相邻）时 mid = 0 + (1-0)/2 = 0（向下取整造成的问题）
                // 此时 arr[mid] < target，则 l = mid = 0
                // l跟之前的值是一样的，从而陷入死循环
                // 需要修改为向上取整
                int mid = l + (r - l + 1) / 2;
                // int mid = l + (r - l) / 2;
                if (arr[mid].CompareTo(target) < 0)
                {
                    l = mid;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return l;
        }

        /// <summary>
        /// >= target 最小索引
        /// </summary>
        public int Lower_Ceil<T>(T[] arr, T target) where T : IComparable
        {
            int l = 0;
            int r = arr.Length;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid].CompareTo(target) < 0)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            return l;
        }

        /// <summary>
        /// <= target 最大索引
        /// </summary>
        /// <returns></returns>
        public int Upper_Floor<T>(T[] arr, T target) where T : IComparable
        {
            int l = -1;
            int r = arr.Length - 1;
            while (l < r)
            {
                int mid = l + (r - l + 1) / 2;
                if (arr[mid].CompareTo(target) > 0)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid;
                }
            }
            return l;
        }

        /// <summary>
        /// < target ，返回最大值索引
        /// == target，返回最小索引 
        /// </summary>
        public int Lower_Floor<T>(T[] arr, T target) where T : IComparable
        {
            int l = ToLower(arr, target);
            if ((l + 1) < arr.Length && arr[l + 1].Equals(target))
            {
                return l + 1;
            }
            else
            {
                return l;
            }
        }

        /// <summary>
        /// > target ，返回最小值索引
        /// == target，返回最大索引 
        /// </summary>
        public int Upper_Ceil<T>(T[] arr, T target) where T : IComparable
        {
            int u = ToUpper(arr, target);
            if (u - 1 >= 0 && arr[u - 1].Equals(target))
            {
                return u - 1;
            }
            else
            {
                return u;
            }
        }
    }
}
