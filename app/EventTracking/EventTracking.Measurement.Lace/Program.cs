using EventTracking.Domain.Core;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Measurements;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;
using Workflow.BuildingBlocks;

namespace EventTracking.Measurement.Lace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var projectionContext = new ProjectionContext();
            var sourceRequestType = new ExternalSourceEventRead();

            var connection = ConnectionFactory.Default();

            var eventReader = new EventReader(connection);


            var measurements = new RequestFromSourceMeasurements(projectionContext, sourceRequestType, eventReader,
                new ExternalSourceExecutionDetectedQuery(connection, projectionContext),
                new ExternalSourceEventDetectorProjection(projectionContext),
                new ExternalSourceEventPublisher(connection, BusFactory.CreateBus("")));

            measurements.Run();
        }
    }
}
