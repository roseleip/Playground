namespace CQRSTest1
{
    public interface IHandles<T>
    {
        void Handle<T>(T message);
        bool IsComplete();
    }
}