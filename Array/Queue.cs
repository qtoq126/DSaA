public interface iQueue<T>
{
    int GetSize();
    bool IsEmpty();
    void Enqueue(T e);
    T Dequeue();
    T GetFront();
}