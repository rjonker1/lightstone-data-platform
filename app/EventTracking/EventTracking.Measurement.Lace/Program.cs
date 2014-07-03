using EventTracking.Domain.Core;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Measurements;
using Workflow.BuildingBlocks;

namespace EventTracking.Measurement.Lace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var projectionContext = new ProjectionContext();
            var connection = ConnectionFactory.Default();

            var measurements = new RequestFromSourceMeasurements(connection, projectionContext, BusFactory.CreateBus(""));

            measurements.Run();
        }
    }
}
