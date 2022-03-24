using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Chapter2.Week6
{
    /// <summary>
    /// 快速排序法
    /// 找到某一元素，使其让在它左侧的元素都比他小，右侧的元素都比他大，然后分别再对左右侧递归
    /// </summary>
    public class QuickSort
    {
        public static void Sort<T>(ref T[] arr) where T : IComparable
        {
            QuickSort_(ref arr, 0, arr.Length - 1);
        }

        private static void QuickSort_<T>(ref T[] arr, int lhs, int rhs) where T : IComparable
        {
            if (lhs >= rhs)
            {
                return;
            }
            int p = Partition(ref arr, lhs, rhs);
            QuickSort_(ref arr, lhs, p - 1);
            QuickSort_(ref arr, p + 1, rhs);
        }

        /// <summary>
        /// 找到满足左边都小，右边都大的index位置（原地排序）
        /// by bobo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static int Partition<T>(ref T[] arr, int lhs, int rhs) where T : IComparable
        {
            int j = lhs;
            for (int i = lhs + 1; i <= rhs; i++)
            {
                if (arr[lhs].CompareTo(arr[i]) >= 0)
                {
                    j++;
                    Swap(ref arr[j], ref arr[i]);
                }
            }
            Swap(ref arr[lhs], ref arr[j]);
            return j;
        }


        /// <summary>
        /// 找到满足左边都小，右边都大的index位置（原地排序）
        /// by myself
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static int Partition2<T>(ref T[]arr, int lhs, int rhs) where T : IComparable
        {
            int retIndex = lhs;
            bool flag = false;

            for (int i = lhs + 1; i <= rhs; i++)
            {
                if (arr[retIndex].CompareTo(arr[i]) > 0)
                {
                    Swap(ref arr[retIndex], ref arr[i]);
                    if (flag)
                    {
                        Swap(ref arr[retIndex + 1], ref arr[i]);
                    }
                    retIndex++;
                }
                else if (arr[retIndex].CompareTo(arr[i]) < 0)
                {
                    flag = true;
                }
            }
            return retIndex;
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
