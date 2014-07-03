using System;
using System.Linq;

namespace EventTracking.Measurement.Repository
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IQueryable<T> GetAll();
        void Save(T item);
    }
}
