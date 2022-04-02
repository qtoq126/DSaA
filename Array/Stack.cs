public interface IStack<E>
{
    int GetSize();
    bool IsEmpty();
    void Push(E e);
    E Pop();
    E Peek();
}