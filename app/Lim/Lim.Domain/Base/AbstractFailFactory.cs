using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractFailFactory<T> : IFail<T>
    {
        public abstract bool Fail(T command);

        public bool Fail(object command)
        {
            return Fail((T)command);
        }
    }
}
