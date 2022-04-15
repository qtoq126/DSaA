using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    /// <summary>
    /// 优先队列
    /// </summary>
    public class PriorityQueue<T> : iQueue<T> where T : IComparable
    {
        /// <summary>
        /// 最大堆
        /// </summary>
        private MaxHeap<T> maxHeap;

        public PriorityQueue()
        {
            maxHeap = new MaxHeap<T>();
        }

        public T Dequeue()
        {
            return maxHeap.ExtractMax(); // 每次出队最大的元素
        }

        public void Enqueue(T e)
        {
            maxHeap.Add(e); // 添加时会进行排序
        }

        public T GetFront()
        {
            return maxHeap.FindMax();
        }

        public int GetSize()
        {
            return maxHeap.GetSize();
        }

        public bool IsEmpty()
        {
            return maxHeap.IsEmpty();
        }
    }
}
