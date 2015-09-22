namespace Lim.Core
{
    public interface INotify
    {
        void Notify(object message);
    }

    public interface INotify<T> : INotify
    {
        void Notify(T message);
    }
}