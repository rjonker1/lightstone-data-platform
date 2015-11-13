using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractFetchFactory<T, TResult> : IFetch<T, TResult>
    {
        public abstract TResult Fetch(T command);

        public object Fetch(object command)
        {
            return (TResult) Fetch((T) command);
        }
    }
}
