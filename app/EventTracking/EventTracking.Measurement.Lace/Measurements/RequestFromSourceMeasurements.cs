using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly ExternalSourceEventInformationProjection _sourceRequestsProjection;

        public RequestFromSourceMeasurements(IProjectionContext context, EventsPublishedForLaceRequests projection,
            EventReader reader, SourceRequestQuery query,
            ExternalSourceEventInformationProjection sourceRequestsProjection)
        {
            _projectionContext = context;
            _projection = projection;
            _eventReader = reader;
            _query = query;
            _sourceRequestsProjection = sourceRequestsProjection;
        }


        public void Run()
        {
           
            ShowRequestDetails();

            EnsureProjections();

            _eventReader.StartReading();

            Console.WriteLine("\nPress ANY key to stop reading and show results\n");
            Console.ReadKey();

            Stop();

            ShowRequestDetails();

            Console.WriteLine("Press ANY key exit");
            Console.ReadKey();

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
            Console.WriteLine("Get Request Details");

            ShowRequestDetails("externalSourceInformation");
            //add other projections / streams
        }

        private void ShowRequestDetails(string name)
        {
            var values = _query.GetValues(name);
            Console.WriteLine("Request Details: {0}", name);

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
                Console.WriteLine("--------------------------------\n");
                Console.WriteLine("Aggregate - {0}", f.AggregateId);

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
                        Console.WriteLine("  - {0}", ft.ToString());
                    }

                    if(!groupedTime.times.Any(w => w.IsExternalSourceCall)) continue;


                    var startTime = groupedTime.times.FirstOrDefault(w => w.StartTime.HasValue) == null
                        ? DateTime.MinValue
                        : groupedTime.times.FirstOrDefault(w => w.StartTime.HasValue).StartTime.Value;

                    var endTime = groupedTime.times.FirstOrDefault(w => w.EndTime.HasValue) == null
                        ? DateTime.MinValue
                        : groupedTime.times.FirstOrDefault(w => w.EndTime.HasValue).EndTime.Value;

                    var execTimes = SetExecutionTime(startTime, endTime);

                    Console.WriteLine(execTimes == null ? "" : "  -- Execution Time {0}\n", execTimes);
                }

                Console.WriteLine("--------------------------------\n");

            }
        }

        private static string SetExecutionTime(DateTime startTime, DateTime endTime)
        {
            var time = (endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;
            return time.ToString("N");
        }
    }
}
