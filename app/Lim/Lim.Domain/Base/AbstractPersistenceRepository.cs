using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractPersistenceRepository<T> : IPersist<T>
    {
        public abstract bool Persist(T obj);

        public bool Persist(object obj)
        {
            return Persist((T) obj);
        }
    }
}