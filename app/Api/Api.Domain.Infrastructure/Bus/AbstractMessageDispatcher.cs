namespace Api.Domain.Infrastructure.Bus
{
    public abstract class AbstractMessageDispatcher<T> : IDispatchMessagesToBus<T>
    {
        public abstract void Dispatch(T message);

        public void Dispatch(object message)
        {
            Dispatch((T)message);
        }
    }

    public interface IDispatchMessagesToBus
    {
        void Dispatch(object message);
    }

    public interface IDispatchMessagesToBus<in T> : IDispatchMessagesToBus
    {
        void Dispatch(T message);
    }
}
