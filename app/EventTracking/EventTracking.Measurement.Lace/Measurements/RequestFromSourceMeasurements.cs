using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EventTracking.Domain.Read.Core;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;
using EventTracking.Measurement.Lace.Results;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;
        private readonly EventsPublishedForLaceRequests _projection;
        private readonly SourceRequestQuery _query;

        private readonly EventReader _eventReader;
      
        private readonly IConsole _console;

        private readonly ExternalSourceEventInformationProjection _sourceRequestsProjection;

        public RequestFromSourceMeasurements(IProjectionContext context, EventsPublishedForLaceRequests projection,
            EventReader reader, IConsole console, SourceRequestQuery query,
            ExternalSourceEventInformationProjection sourceRequestsProjection)
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

            _console.ReadKey("\nPress ANY key to stop reading and show results\n");

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

            ShowRequestExecutionTimes(values);
        }


        private void ShowRequestExecutionTimes(
            IEnumerable<IShowEventsPublishedForLaceRequests> projectionResults)
        {

            var values = BuildMeasurementResults.ForSourceExecutionTimes(projectionResults);

            var grouped = values.GroupBy(g => g.AggregateId, times => times, (guid, elements) => new
            {
                AggregateId = guid,
                times = elements
            }).ToList();

            foreach (var f in grouped)
            {
                _console.Log("--------------------------------\n");
                _console.Log("Aggregate - {0}", f.AggregateId);

                var groupedTimes = f.times
                    .GroupBy(g => g.Source, times => times, (key, elements) => new
                    {
                        Source = key,
                        times = elements

                    }).ToList();


                foreach (var groupedTime in groupedTimes)
                {

                    foreach (var ft in groupedTime.times)
                    {
                        _console.Log("  - {0}", ft.ToString());
                    }

                    if(!groupedTime.times.Any(w => w.IsExternalSourceCall)) continue;


                    var startTime = groupedTime.times.FirstOrDefault(w => w.StartTime.HasValue) == null
                        ? DateTime.MinValue
                        : groupedTime.times.FirstOrDefault(w => w.StartTime.HasValue).StartTime.Value;

                    var endTime = groupedTime.times.FirstOrDefault(w => w.EndTime.HasValue) == null
                        ? DateTime.MinValue
                        : groupedTime.times.FirstOrDefault(w => w.EndTime.HasValue).EndTime.Value;

                    var execTimes = SetExecutionTime(startTime, endTime);

                    _console.Log(execTimes == null ? "" : "  -- Execution Time {0}\n", execTimes);
                }

                _console.Log("--------------------------------\n");

            }
        }

        private static string SetExecutionTime(DateTime startTime, DateTime endTime)
        {
            var time = (endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;
            return time.ToString("N");
        }
    }
}
