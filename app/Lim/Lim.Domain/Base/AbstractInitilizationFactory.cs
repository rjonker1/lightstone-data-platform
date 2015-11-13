using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractInitilizationFactory<T> : IInitialize<T>
    {
        public abstract void Init(T command);

        public void Init(object command)
        {
            Init((T) command);
        }
    }
}