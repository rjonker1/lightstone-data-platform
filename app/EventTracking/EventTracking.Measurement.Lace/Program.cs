using System.Net;
using EventStore.ClientAPI;
using EventTracking.Domain.Read.Core;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Measurements;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;

namespace EventTracking.Measurement.Lace
{
    class Program
    {

        private static readonly IPEndPoint TcpEndPoint = new IPEndPoint(IPAddress.Loopback, 1113);

        static void Main(string[] args)
        {
            var console = new Domain.Read.Core.Console();
            var projectionContext = new ProjectionContext(console);
            var sourceRequestType = new SourceRequestsExecutionTimes();

            var connection = DefaultConnection();

            var eventReader = new EventReader(connection, console, new KnownEventsProvider());


            var measurements = new RequestFromSourceMeasurements(projectionContext, sourceRequestType, eventReader,
                console, new SourceRequestQuery(connection), new SourceRequestExecutionTimesProjection(projectionContext));

            measurements.Run();

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
