using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractNotificationFactory<T> : INotify<T>
    {
        public abstract void Notify(T message);

        public void Notify(object message)
        {
            Notify((T)message);
        }
    }
}