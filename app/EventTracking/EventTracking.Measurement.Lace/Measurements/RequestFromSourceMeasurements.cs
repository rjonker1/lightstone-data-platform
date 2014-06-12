using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EventTracking.Domain.Read.Core;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;
        private readonly SourceRequestsExecutionTimes _projection;
        private readonly SourceRequestQuery _query;

        private readonly EventReader _eventReader;
      
        private readonly IConsole _console;

        private readonly SourceRequestExecutionTimesProjection _sourceRequestsProjection;

        public RequestFromSourceMeasurements(IProjectionContext context, SourceRequestsExecutionTimes projection,
            EventReader reader, IConsole console, SourceRequestQuery query,
            SourceRequestExecutionTimesProjection sourceRequestsProjection)
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

            _console.ReadKey("\nPress ANY key to stop reading and show times\n");

            Stop();

            ShowRequestDetails();

            _console.ReadKey("Press ANY key exit");

        }


        private void Stop()
        {

        }

        private void EnsureProjections()
        {
            _projectionContext.EnableProjection("$by_category");
            _projectionContext.EnableProjection("$stream_by_category");

            _sourceRequestsProjection.Ensure();
        }

        private void ShowRequestDetails()
        {
            _console.Important("Get Request Details");

            ShowRequestDetails("externalSourceInformation");
            //add other projections / streams
        }

        private void ShowRequestDetails(string name)
        {
            var values = _query.GetValues(name);
            _console.Log("Request Details: {0}", name);


            var grouped = values.GroupBy(g => g.AggregateId, times => times, (guid, elements) => new
            {
                AggregateId = guid,
                times = elements
            }).ToList();


            foreach (var f in grouped)
            {
                foreach (var ft in f.times)
                {
                    _console.Log("  - {0}", ft.ToString());
                }

                var execTimes = SetExecutionTime(f.times.Single(w => w.StartTime.HasValue).StartTime.Value,
                    f.times.Single(w => w.EndTime.HasValue).EndTime.Value);

                _console.Log(execTimes == null ? "" : "  -- Execution Time {0}\n", execTimes);
            }
        }


        private static string SetExecutionTime(DateTime startTime, DateTime endTime)
        {
            var time = (endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;
            return time.ToString("N");
        }
    }
}
