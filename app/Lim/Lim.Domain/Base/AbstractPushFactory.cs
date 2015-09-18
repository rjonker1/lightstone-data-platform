using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractPushFactory<T> : IPush<T>
    {
        public abstract void Push(T command);

        public void Push(object command)
        {
            Push((T)command);
        }
    }
}