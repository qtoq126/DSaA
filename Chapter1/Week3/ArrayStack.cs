using System.Text;

namespace DataStructure
{
    public class ArrayStack<E>: IStack<E> 
    {
        Array<E> array;

        public ArrayStack(int capacity)
        {
            array = new Array<E>(capacity);
        }

        public ArrayStack()
        {
            array = new Array<E>();
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

        public void Push(E e){
            array.AddLast(e);
        }

        public E Pop(){
            return array.RemoveLast();
        }

        public E Peek(){
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