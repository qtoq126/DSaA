using System.Text;

namespace DataStructure
{
    public class ArrayQueue<E>: iQueue<E> 
    {
        Array<E> array;

        public ArrayQueue(int capacity){
            array = new Array<E>(capacity);
        }

        public ArrayQueue()
        {
            array = new Array<E>();
        }

         public int GetSize()
         {
             return array.GetSize();
         }

         public bool IsEmpty(){
             return array.IsEmpty();
         }

         public void Enqueue(E e){
             array.AddLast(e);
         }

         public E Dequeue(){ //出队的时间复杂度为O(n)
             return array.RemoveFirst();
         }

         public E GetFront(){
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