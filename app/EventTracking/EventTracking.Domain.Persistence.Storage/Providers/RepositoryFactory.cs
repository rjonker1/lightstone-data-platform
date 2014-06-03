using System;
using System.Net;
using EventStore.ClientAPI;

namespace EventTracking.Domain.Persistence.Storage.Providers
{
    public class RepositoryFactory : IDisposable
    {
        private static readonly IPEndPoint TcpEndPoint = new IPEndPoint(IPAddress.Loopback, 1113);

        private static IEventStoreConnection _connection;

        public RepositoryFactory Instance()
        {
            _connection = EventStoreConnection.Create(TcpEndPoint);
            _connection.Connect();
            Repository = new EventStoreRepository(_connection);

            return this;
        }

        public IRepository Repository { get; private set; }

        public void Dispose()
        {
            if (_connection == null) return;

            _connection.Close();
            _connection.Dispose();
        }
    }
}
