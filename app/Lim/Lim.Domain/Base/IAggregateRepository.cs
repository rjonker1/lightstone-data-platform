using System;

namespace Lim.Domain.Base
{
    public interface IAggregateRepository<out T> where T : Aggregate, new()
    {
        void Save(Aggregate aggregate, long expectedVersion);
        T GetById(Guid id);
    }
}
