using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractPersistenceRepository<T> : IPersistObject<T>
    {
        public abstract bool Persist(T obj);

        public bool Persist(object obj)
        {
            return Persist((T) obj);
        }
    }
}