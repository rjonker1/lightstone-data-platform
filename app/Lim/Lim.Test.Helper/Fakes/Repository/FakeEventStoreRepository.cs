using System;
using System.Collections.Generic;
using Lim.Domain.EventStore;
using Lim.Domain.EventStore.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeEventStoreDatabase
    {
        public static List<EventCommand> Events = new List<EventCommand>(); 
    }

    public class FakeEventStoreRepository : IEventStoreRepository
    {
        public void Save<T>(T entity) where T : class
        {
            var e = entity as EventCommand;
            e.Id = e.Id == 0 ? new Random().Next(1000, 10000000) : e.Id;
            FakeEventStoreDatabase.Events.Add(e);
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            var e = entity as EventCommand;
            FakeEventStoreDatabase.Events.Add(e);
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
