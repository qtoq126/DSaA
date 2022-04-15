public interface IStack<T>
{
    int GetSize();
    bool IsEmpty();
    void Push(T e);
    T Pop();
    T Peek();
}