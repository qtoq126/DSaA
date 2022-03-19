using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text;

namespace DataStructure
{
    public class LoopQueue<E> : iQueue<E>
    {
        private E[] data;
        private int front, tail;
        private int size;

        public LoopQueue(int capacity){
            data = new E[capacity + 1];
            front = 0;
            tail = 0;
            size = 0;
        }

        public LoopQueue()
        {
            data = new E[11];
        }

        public int GetCapacity()
        {
            return data.Length - 1;
        }

        public bool IsEmpty()
        {
            return front == tail;
        }

        public int GetSize() {
            return size;
        }

        public void Enqueue(E e)
        {
            if ((tail + 1) % data.Length == front)
            {
                Resize(GetCapacity() * 2);
            }
            data[tail] = e;
            tail = (tail + 1) % data.Length;
            size ++;
        }

        public E Dequeue() {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Empty Queue");
            }
            E ret = data[front];
            front = (front + 1) % data.Length;
            size --;
            if (size == GetCapacity() / 4 && GetCapacity() / 2 != 0)
            {
                Resize(GetCapacity() / 2);
            }
            return ret;
        }

        private void Resize(int newCapacity){
            E[] newData = new E[newCapacity + 1];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[(i + front) % data.Length];
            }
            data = newData;
            front = 0;
            tail = size;
        }

        public E GetFront()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Empty Queue");
            }
            return data[front];
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(string.Format("LoopQueue: size = {0}, capacity = {1}\n", size, GetCapacity()));
            res.Append("front [");
            for (int i = front; i != tail; i = (i + 1) % data.Length)
            {
                res.Append(data[i]);
                if ((i + 1) % data.Length != tail)
                {
                    res.Append(",");
                }
            }
            res.Append("] tail");
            return res.ToString();
        }
    }
}