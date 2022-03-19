public interface iQueue<E>
{
    int GetSize();
    bool IsEmpty();
    void Enqueue(E e);
    E Dequeue();
    E GetFront();
}