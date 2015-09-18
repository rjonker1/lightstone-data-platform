using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractPullFactory<T> : IPull<T>
    {
        public abstract void Pull(T command);

        public void Pull(object command)
        {
            Pull((T) command);
        }
    }
}
