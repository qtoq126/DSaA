using System.Text;

namespace DataStructure.Array
{
    public class ArrayStack<T>: IStack<T> 
    {
        BaseArray<T> array;

        public ArrayStack(int capacity)
        {
            array = new BaseArray<T>(capacity);
        }

        public ArrayStack()
        {
            array = new BaseArray<T>();
        }

        public int GetSize()
        {
            return array.GetSize();
        }

        public bool IsEmpty()
        {
            return array.IsEmpty();
        }

        public int GetCapacity()
        {
            return array.GetCapacity();
        }

        public void Push(T e){
            array.AddLast(e);
        }

        public T Pop(){
            return array.RemoveLast();
        }

        public T Peek(){
            return array.GetLast();
        }

        public override string ToString(){
            StringBuilder res = new StringBuilder();
            res.Append("Stack: ");
            res.Append("[");
            for (int i = 0; i < array.GetSize(); i++)
            {
                res.Append(array.Get(i));
                if (i != array.GetSize() - 1)
                {
                    res.Append(",");
                }
            }
            res.Append("] top");
            return res.ToString();
        }

    }
}