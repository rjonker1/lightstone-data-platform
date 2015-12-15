using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractPersistenceRepository<T> : IPersist<T>
    {
        public abstract bool Persist(T @object);

        public bool Persist(object @object)
        {
            return Persist((T) @object);
        }
    }
}