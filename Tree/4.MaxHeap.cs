using DataStructure.Array;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    /// <summary>
    /// 最大二叉堆
    /// 1. 是完全二叉树（将元素从左到右放，所有右子树可能为空）
    /// 2. 任意节点的值不大于父节点的值
    /// 3. 可以使用数组的方式表示一个完全二叉树
    /// 4. Add()和ExtractMax()方法都是O(logn)级别，而且永远不会退化成链表
    /// </summary>
    public class MaxHeap<T> where T : IComparable
    {
        private BaseArray<T> data;

        public MaxHeap(int capacity)
        {
            data = new BaseArray<T>(capacity);
        }

        public MaxHeap()
        {
            data = new BaseArray<T>();
        }

        public bool IsEmpty() => data.IsEmpty();

        public int GetSize() => data.GetSize();

        public T FindMax()
        {
            if (data.IsEmpty())
            {
                throw new ArgumentOutOfRangeException("ths array is empty!");
            }
            return data.Get(0);
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的父亲节点的索引
        /// </summary>
        private int Parent(int index)
        {
            if (index == 0)
            {
                throw new ArgumentOutOfRangeException("index 0 doesn't have parent");
            }
            return (index - 1) / 2;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        /// </summary>
        private int LeftChild(int index)
        {
            return index * 2 + 1;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的右孩子节点的索引
        /// </summary>
        private int RightChild(int index)
        {
            return index * 2 + 2;
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        public void Add(T e)
        {
            data.AddLast(e); // count会+1;
            SiftUp(data.GetSize() - 1);
        }

        /// <summary>
        /// 上浮
        /// </summary>
        private void SiftUp(int k)
        {
            while (k > 0 && data.Get(Parent(k)).CompareTo(data.Get(k)) < 0)
            {
                data.Swap(k, Parent(k));
                k = Parent(k);
            }
        }

        /// <summary>
        /// 取出最大的元素（树的根节点）
        /// </summary>
        public T ExtractMax()
        {
            // 1. 暂存索引为0的元素
            var ret = FindMax();
            // 2. 将最后一个元素换到树根节点，然后删除最后一个元素
            data.Swap(0, data.GetSize() - 1);
            data.Remove(data.GetSize() - 1);
            SiftDown(0);
            return ret;
        }

        /// <summary>
        /// 下沉
        /// </summary>
        public void SiftDown(int k)
        {
            // 当左节点的索引大于等于节点总数时，则说明是叶子节点，无法再继续下沉了
            while (LeftChild(k) < data.GetSize())
            {
                int j = LeftChild(k);
                if (j + 1 < data.GetSize() && data.Get(j + 1).CompareTo(data.Get(j)) > 0) // 如果有右孩子且右孩子大，存右孩子，否则就是左孩子
                {
                    j = RightChild(k);
                    // j++;
                }
                if (data.Get(k).CompareTo(data.Get(j)) >= 0) // 如果父节点比孩子节点大，循环结束，节点已经在正确的位置了
                {
                    break;
                }
                data.Swap(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 取出堆中最大元素，并且替换成元素e
        /// </summary>
        public T Replace(T e)
        {
            var ret = FindMax();
            data.Set(0, e);
            SiftDown(0);
            return ret;
        }

        /// <summary>
        /// 将任意数组整理成堆的形状
        /// 可作为构造函数
        /// </summary>
        public void Heapify(T[] arr)
        {
            // 方法一：可以直接将所有的元素通过堆类的添加方法：O(nlogn)
            // 方法二：直接找到第一个非叶子节点（最后一个叶子节点的父节点），然后依次对剩下的节点一次进行SiftDown操作：O(n)
            data = new BaseArray<T>(arr);
            for (int i = Parent(data.GetSize() - 1) ; i >= 0; i--)
            {
                SiftDown(i);
            }
        }
    }
}
