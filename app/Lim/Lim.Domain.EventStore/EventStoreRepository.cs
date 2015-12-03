using System;
using Lim.Core;
using Lim.Domain.EventStore.Factory;

namespace Lim.Domain.EventStore
{
    public interface IEventStoreRepository : IWriteOnlyRepository
    {
        
    }

    public class EventStoreRepository : IEventStoreRepository
    {
        public void Save<T>(T entity) where T : class
        {
            using (var session = LimEventStoreManager.LimEventStoreInstance.OpenSession())
                session.Save(entity);
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            using (var session = LimEventStoreManager.LimEventStoreInstance.OpenSession())
                session.SaveOrUpdate(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Merge<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
