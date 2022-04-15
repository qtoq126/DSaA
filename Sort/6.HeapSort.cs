using DataStructure.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Sort
{
    public class HeapSort
    {
        private HeapSort() { }

        public static void Sort<T>(T[] data) where T : IComparable
        {
            var maxHeap = new MaxHeap<T>();
            foreach (T e in data)
            {
                maxHeap.Add(e);
            }
            for (int i = data.Length - 1; i >= 0; i--)
            {
                data[i] = maxHeap.ExtractMax();
            }
        }

        /// <summary> 
        /// 使用Heapify
        /// </summary>
        public static void Sort1<T>(T[] data) where T : IComparable
        {
            if (data.Length <= 1)
            {
                return;
            }
            // 进行Heapify
            for (int i = (data.Length - 2) / 2; i >= 0; i--)
            {
                SiftDown(data, i, data.Length);
            }
            for (int i = data.Length - 1; i >= 0; i--)
            {
                SortHelper.Swap(data, 0, i); // 将最大元素与最后元素互换位置
                SiftDown(data, 0, i); // 将除了换位元素索引之前的所有元素（保持着最大堆结构）中进行SiftDown
            }
        }

        /// <summary>
        /// 对data[0,n)所形成的最大堆中，索引为k的元素，执行SiftDown
        /// </summary>
        public static void SiftDown<T>(T[] data, int k, int n) where T : IComparable
        {
            // 当左节点的索引大于等于节点总数时，则说明是叶子节点，无法再继续下沉了
            while (k * 2 + 1 < n)
            {
                int j = k * 2 + 1;
                if (j + 1 < n && data[j + 1].CompareTo(data[j]) > 0) // 如果有右孩子且右孩子大，存右孩子，否则就是左孩子
                {
                    j++;
                }
                if (data[k].CompareTo(data[j]) >= 0) // 如果父节点比孩子节点大，循环结束，节点已经在正确的位置了
                {
                    break;
                }
                SortHelper.Swap(data, k, j);
                k = j;
            }
        }
    }
}
