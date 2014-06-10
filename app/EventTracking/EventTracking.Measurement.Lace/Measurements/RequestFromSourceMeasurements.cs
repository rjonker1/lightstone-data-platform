using System.Net.NetworkInformation;
using EventTracking.Domain.Read.Core;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;
        private readonly SourceRequestType _projection;
        private readonly SourceRequestQuery _query;

        private readonly EventReader _eventReader;

        //private readonly DeviceSimulator _deviceSimulator;
        private readonly IConsole _console;

        private readonly SourceRequestDetailsProjection _sourceRequestsProjection;

        public RequestFromSourceMeasurements(IProjectionContext context, SourceRequestType projection,
            EventReader reader, IConsole console, SourceRequestQuery query, SourceRequestDetailsProjection sourceRequestsProjection)
        {
            _projectionContext = context;
            _projection = projection;
            _eventReader = reader;
            _console = console;
            _query = query;
            _sourceRequestsProjection = sourceRequestsProjection;
        }


        public void Run()
        {
            ShowRequestDetails();

            EnsureProjections();

            _eventReader.StartReading();

            _console.ReadKey("Press ANY key to stop");

            Stop();

            ShowRequestDetails();

            _console.ReadKey("Press ANY key exit");

        }

      
        private void Stop()
        {
            //TODO: Need to stop the simulator
        }

        private void EnsureProjections()
        {
            _projectionContext.EnableProjection("$by_category");
            _projectionContext.EnableProjection("$stream_by_category");

            _sourceRequestsProjection.Ensure(); //TODO: Implement check to ensure prediction exists; first create the projection?
        }

        private void ShowRequestDetails()
        {
            _console.Important("Get Request Details");

            ShowRequestDetails("RequestsSentToSources");
            //add other projections / streams
        }

        private void ShowRequestDetails(string name)
        {
            var values = _query.GetValues(name);
            _console.Log("Request Details: {0}", name);

            foreach (var value in values)
            {
                _console.Log("  - {0}", value);
            }
        }
    }
}
