using System;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;

namespace EventTracking.Domain.Persistence.EventStore
{
    public class EventStoreProvider : IDisposable
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreProvider()
        {
            _connection = ConnectionFactory.Default();
            Repository = new EventStoreRepository(_connection);
        }

        //public EventStoreProvider Instance()
        //{


        //    return this;
        //}

        public readonly EventStoreRepository Repository;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _connection.Close();
            Repository.Dispose();

        }
    }
}
