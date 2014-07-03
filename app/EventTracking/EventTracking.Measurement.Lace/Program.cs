using EventTracking.Domain.Core;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Measurements;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;

namespace EventTracking.Measurement.Lace
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectionContext = new ProjectionContext();
            var sourceRequestType = new ExternalSourceEventRead();

            var connection = ConnectionFactory.Default();

            var eventReader = new EventReader(connection);


            var measurements = new RequestFromSourceMeasurements(projectionContext, sourceRequestType, eventReader,
                new ExternalSourceRequestQuery(connection, projectionContext), new ExternalSourceEventInformationProjection(projectionContext));

            measurements.Run();
        }


    }
}
