using System.Text;

namespace DataStructure.Array
{
    public class ArrayQueue<T>: iQueue<T> 
    {
        BaseArray<T> array;

        public ArrayQueue(int capacity){
            array = new BaseArray<T>(capacity);
        }

        public ArrayQueue()
        {
            array = new BaseArray<T>();
        }

         public int GetSize()
         {
             return array.GetSize();
         }

         public bool IsEmpty(){
             return array.IsEmpty();
         }

         public void Enqueue(T e){
             array.AddLast(e);
         }

         public T Dequeue(){ //出队的时间复杂度为O(n)
             return array.RemoveFirst();
         }

         public T GetFront(){
             return array.GetFirst();
         }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("Queue: ");
            res.Append("front [");
            for (int i = 0; i < array.GetSize(); i++)
            {
                res.Append(array.Get(i));
                if (i != array.GetSize() - 1)
                {
                    res.Append(",");
                }
            }
            res.Append("] tail");
            return res.ToString();
        }
    }
    
}