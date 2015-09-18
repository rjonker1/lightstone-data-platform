using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractReadingFactory<T1, T2> : IRead<T1, T2>
    {
        public abstract T2 Read(T1 command);

        public object Read(object command)
        {
            return (T2)Read((T1) command);
        }
    }
}