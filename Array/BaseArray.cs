using System;
using System.Text;

namespace DataStructure.Array
{
    class BaseArray<T>
    {
        private T[] data;
        private int size;

        public BaseArray(int capacity)
        {
            data = new T[capacity];
            size = 0;
        }

        public BaseArray()
        {
            data = new T[10];
            size = 0;
        }

        public BaseArray(T[] arr)
        {
            data = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                data[i] = arr[i];
            }
            size = arr.Length;
        }

        //获取数组中的元素个数
        public int GetSize()
        {
            return size;
        }

        //获取数组的容量
        public int GetCapacity()
        {
            return data.Length;
        }

        //返回数组是否为空
        public bool IsEmpty()
        {
            return size == 0;
        }

        //在第index个位置插入新的元素
        public void Add(int index, T e)
        {

            if (index < 0 && index > size)
            {
                throw new IndexOutOfRangeException("Add failed. Require index >= 0");
            }

            if (size == data.Length)
            {
                Resize(2 * data.Length);
            }

            for (int i = size - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }
            
            data[index] = e;
            size++;
        }

        public void AddLast(T e)
        {
            Add(size, e);
        }


        public void AddFirst(T e)
        {
            Add(0, e);
        }

        //获取index索引位置的元素
        public T Get(int index)
        {
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeException("Add failed. Require index >= 0");
            }

            return data[index];
        }

        public T GetLast(){
            return Get(size - 1);
        }

        public T GetFirst(){
            return Get(0);
        }

        //修改index索引位置的元素e
        public void Set(int index, T e)
        {
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeException("Add failed. Require index >= 0");
            }

            data[index] = e;
        }

        //查找数组中是否有元素e
        public bool Contains(T e)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                {
                    return true;
                }
            }
            return false;
        }

        //查找数组中元素e所在的索引，如果不存在，则返回-1
        public int Find(T e)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                {
                    return i;
                }
            }
            return -1;
        }

        //从数组中删除index位置的元素，返回删除的元素
        public T Remove(int index)
        {
            if (index < 0 && index >= size)
            {
                throw new IndexOutOfRangeException("Add failed. Require index >= 0");
            }
            T removeE = data[index];
            for (int i = index + 1; i < size; i++)
            {
                data[i - 1] = data[i];
            }
            size--;

            if (size == data.Length / 4 && data.Length / 2 != 0) //Lazy模式
            {
                Resize(data.Length / 2);
            }
            return removeE;
        }

        public T RemoveFirst()
        {
            return Remove(0);
        }

        public T RemoveLast()
        {
            return Remove(size - 1);
        }

        //从数组中删除元素e
        public void RemoveElement(T e)
        {
            int index = Find(e);
            if (index != -1)
            {
                Remove(index);
            }
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(string.Format("Array: size = {0}, capacity = {1}\n", size, data.Length));
            res.Append("[");
            for (int i = 0; i < size; i++)
            {
                res.Append(data[i]);
                if (i != size - 1)
                {
                    res.Append(",");
                }
            }
            res.Append("]");
            return res.ToString();
        }

        //改变数组容积
        private void Resize(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }

        public void Swap(int i, int j)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new ArgumentOutOfRangeException("Index is illegal.");
            }
            var t = data[i];
            data[i] = data[j];
            data[j] = t;
        }
    }
}