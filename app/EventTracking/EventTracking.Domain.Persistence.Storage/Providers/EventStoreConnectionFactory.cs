using System;
using System.Net;
using EventStore.ClientAPI;

namespace EventTracking.Domain.Persistence.Storage.Providers
{
    public class EventStoreConnectionFactory : IDisposable
    {
        private static readonly IPEndPoint TcpEndPoint = new IPEndPoint(IPAddress.Loopback, 1113);

        private static readonly IEventStoreConnection Connection = DefaultConnection();

        public EventStoreConnectionFactory Instance()
        {
            Repository = new EventStoreRepository(Connection);

            return this;
        }

        //~EventStoreConnectionFactory()
        //{
            
        //}

        public IRepository Repository;

        public void Dispose()
        {
            //if (Connection == null) return;

            //Connection.Close();
        }

     
        private static IEventStoreConnection DefaultConnection()
        {
            var settings = ConnectionSettings.Create()
                .KeepReconnecting()
                .UseConsoleLogger();


            var connection = EventStoreConnection.Create(settings, TcpEndPoint);
            connection.Connect();
            return connection;
        }
    }
}
