using EventStore.ClientAPI;

namespace EventTracking.Domain.Core
{
    public class ConnectionFactory
    {


        public static IEventStoreConnection Default()
        {
            var settings = ConnectionSettings.Create()
                .KeepReconnecting()
                .UseConsoleLogger();

            var connection = EventStoreConnection.Create(settings, IpEndPointFactory.DefaultTcp());
            connection.Connect();
            return connection;
        }
    }
}
