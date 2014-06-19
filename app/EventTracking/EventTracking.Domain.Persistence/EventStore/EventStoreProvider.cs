using System;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;

namespace EventTracking.Domain.Persistence.EventStore
{
    public class EventStoreProvider : IDisposable
    {
        private IEventStoreConnection _connection;

        public EventStoreProvider Instance()
        {
            _connection = ConnectionFactory.Default();
            Repository = new EventStoreRepository(_connection);

            return this;
        }

        public IRepository Repository;

        public void Dispose()
        {
          // _connection.Dispose();
        }
    }
}
