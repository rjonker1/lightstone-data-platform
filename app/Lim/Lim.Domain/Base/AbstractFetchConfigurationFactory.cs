using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractFetchConfigurationFactory<T, TResult> : IFetchConfiguration<T, TResult>
    {
        public abstract TResult Fetch(T command);

        public object Fetch(object command)
        {
            return (TResult) Fetch((T) command);
        }
    }
}
