using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Sort
{
    /// <summary>
    /// 快速排序法（随机算法，不用最坏复杂度O(n^2)来评估，使用[期望]（平均值）来分析复杂度）
    /// 算法逻辑：选择一个基点元素，将该数挪到使其在它左侧的元素都比他小，右侧的元素都比他大的位置，然后分别再对该位置的左右侧进行递归
    /// 问题一：O(n^2)：对于已经是有序的数组（都是升序），且如果每次锚定点都取数组中的第一个值的话：则会出现每次划分的话左边都划分为空，右侧每次只能少一个元素 -> 递归深度太深了O(n)
    /// 问题二：O(n^2)：对于数组中的值全部相同时
    /// O(nlogn)：期望（平均来看复杂度跟归并算法相同）
    /// </summary>
    public class QuickSort
    {
        private QuickSort() { }

        public static void Sort<T>(T[] arr) where T : IComparable
        {
            QuickSort_(arr, 0, arr.Length - 1);
        }

        private static void QuickSort_<T>(T[] arr, int lhs, int rhs) where T : IComparable
        {
            if (lhs >= rhs)
            {
                return;
            }
            var r = new Random();
            int p = Partition(arr, lhs, rhs, r);
            QuickSort_(arr, lhs, p - 1);
            QuickSort_(arr, p + 1, rhs);
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
        public static int Partition<T>(T[] arr, int lhs, int rhs, Random r) where T : IComparable
        {
            int j = lhs;

            // 先去随机索引的值，将该值与数组首值互换，再进行遍历（优化有序数列为O(n^2)的情况）-> 解决问题一
            int randomIndex = r.Next(lhs, rhs + 1);
            SortHelper.Swap(arr, j, randomIndex);

            for (int i = lhs + 1; i <= rhs; i++)
            {
                if (arr[lhs].CompareTo(arr[i]) >= 0)
                {
                    j++;
                    SortHelper.Swap(arr, j, i);
                }
            }
            SortHelper.Swap(arr, lhs, j);
            return j;
        }

        /// <summary>
        /// 通过双路进行排序，改进Partition算法 -> 解决问题二
        /// i索引从左到右，j索引从右向左，arr[i]>标定点，arr[j]<标定点，则进行互换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static int Partition2<T>(T[] arr, int lhs, int rhs, Random r) where T : IComparable
        {
            int k = lhs; // 标定点索引

            // 先去随机索引的值，将该值与数组首值互换，再进行遍历（优化有序数列为O(n^2)的情况）-> 解决问题一
            int randomIndex = r.Next(lhs, rhs + 1);
            SortHelper.Swap(arr, k, randomIndex);

            int i = k + 1;
            int j = rhs;

            while(true)
            {
                while (i <= j && arr[i].CompareTo(arr[k]) < 0)
                {
                    i++;
                }
                while (j >= i && arr[j].CompareTo(arr[k]) > 0)
                {
                    j--;
                }
                if (i >= j)
                {
                    break;
                }
                // arr[i]>=标定点且arr[j]<=标定点时互换，使其小的在前面，大的排到了后面
                SortHelper.Swap(arr, i, j);
                i++;
                j--;
            }
            SortHelper.Swap(arr, lhs, j); // 将首元素换到区间位
            return k;
        }

        /// <summary>
        /// 通过三路进行排序，再次改进Partition算法 -> 解决如果全是重复元素时仍然要进行递归的问题
        /// lt索引从左到右（维护所有<v的值），gt索引从右向左（维护所有>v的值）,lt-gt的区间则都为全是重复的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>返回lt和gt</returns>
        public static (int, int) Partition3<T>(T[] arr, int lhs, int rhs, Random r) where T : IComparable
        {
            int k = lhs; // 标定点索引

            int randomIndex = r.Next(lhs, rhs + 1);
            SortHelper.Swap(arr, k, randomIndex);

            int lt = k;
            int gt = rhs + 1;
            int i = lhs + 1;

            while (i < gt)
            {
                if (arr[i].CompareTo(arr[k]) < 0)
                {
                    lt++;
                    SortHelper.Swap(arr, i, lt); // 与lt集合尾元素的后一位（=v的第一个位）互唤
                    i++;
                }
                else if (arr[i].CompareTo(arr[k]) > 0)
                {
                    gt--;
                    SortHelper.Swap(arr, i, gt); // 与gt集合头元素的前一位（=v的最后一位）互换
                }
                else
                {
                    // arr[i] == arr[k]时，使其保持相同的元素集中在中间
                    i++;
                }
            }
            SortHelper.Swap(arr, lhs, lt);
            return (lt, gt);
        }

        /// <summary>
        /// 通过三路进行排序，再次改进Partition算法 -> 解决如果全是重复元素时仍然要进行递归的问题
        /// lt索引从左到右（维护所有<v的值），gt索引从右向左（维护所有>v的值）,lt-gt的区间则都为全是重复的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>返回lt和gt</returns>
        public static (int, int) Partition3<T>(T[] arr, int lhs, int rhs) where T : IComparable
        {
            int k = lhs; // 标定点索引

            int lt = k;
            int gt = rhs + 1;
            int i = lhs + 1;

            while (i < gt)
            {
                if (arr[i].CompareTo(arr[k]) < 0)
                {
                    lt++;
                    SortHelper.Swap(arr, i, lt); // 与lt集合尾元素的后一位（=v的第一个位）互唤
                    i++;
                }
                else if (arr[i].CompareTo(arr[k]) > 0)
                {
                    gt--;
                    SortHelper.Swap(arr, i, gt); // 与gt集合头元素的前一位（=v的最后一位）互换
                }
                else
                {
                    // arr[i] == arr[k]时，使其保持相同的元素集中在中间
                    i++;
                }
            }
            SortHelper.Swap(arr, lhs, lt);
            return (lt, gt);
        }

        /// <summary>
        /// 三路排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        private static void QuickSort1_<T>(T[] arr, int lhs, int rhs) where T : IComparable
        {
            if (lhs >= rhs)
            {
                return;
            }
            var r = new Random();
            (int lt, int gt) = Partition3(arr, lhs, rhs, r);
            QuickSort1_(arr, lhs, lt - 1);
            QuickSort1_(arr, gt, rhs);
        }

        public static void Sort1<T>(T[] arr) where T : IComparable
        {
            QuickSort1_(arr, 0, arr.Length - 1);
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
        public static int PartitionOfMe<T>(T[]arr, int lhs, int rhs) where T : IComparable
        {
            int retIndex = lhs;
            bool flag = false;

            for (int i = lhs + 1; i <= rhs; i++)
            {
                if (arr[retIndex].CompareTo(arr[i]) > 0)
                {
                    SortHelper.Swap(arr, retIndex, i);
                    if (flag)
                    {
                        SortHelper.Swap(arr, retIndex + 1, i);
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
    }
}
