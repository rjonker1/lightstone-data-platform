using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractBuildFactory<T,TResult> : IBuild<T, TResult>
    {
        public abstract TResult Build(T @object);

        public object Build(object @object)
        {
            return Build((T)@object);
        }
    }
}