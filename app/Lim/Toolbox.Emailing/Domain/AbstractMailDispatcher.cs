namespace Toolbox.Emailing.Domain
{
    public abstract class AbstractMailDispatcher<T> : IDispatchMail<T>
    {
        public abstract void Send(T message);

        public void Send(object message)
        {
            Send((T)message);
        }
    }
}
