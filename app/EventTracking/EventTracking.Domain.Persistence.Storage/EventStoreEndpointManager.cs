using System;
using System.Net;
using EventStore.ClientAPI;

namespace EventTracking.Domain.Persistence.Storage
{
    public class EventStoreEndpointManager : IDisposable
    {
        private static readonly IPEndPoint TcpEndPoint = new IPEndPoint(IPAddress.Loopback, 1113);

        private static IEventStoreConnection _connection;
        private static EventStoreRepository _instance;

        public static EventStoreRepository Instance
        {
            get
            {
                if (_instance != null) return _instance;

                _connection = EventStoreConnection.Create(TcpEndPoint);
                _instance = new EventStoreRepository(_connection);

                return _instance;
            }
        }

        public void Dispose()
        {
            if (_connection == null) return;

            _connection.Close();
            _connection.Dispose();
        }
    }
}
