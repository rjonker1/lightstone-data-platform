using System;
using System.Collections.Generic;
using System.Linq;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Lace.Queries;
using EventTracking.Measurement.Lace.Results;
using EventTracking.Tests.Helper.Builder.Lace;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;
        private readonly ExternalSourceEventRead _projection;
        private readonly ExternalSourceExecutionDetectedQuery _query;
        private readonly ExternalSourceEventPublisher _externalSourceEventPublisher;

        private readonly EventReader _eventReader;

        private readonly ExternalSourceEventDetectorProjection _sourceRequestsProjection;

        public RequestFromSourceMeasurements(IProjectionContext context, ExternalSourceEventRead projection,
            EventReader reader, ExternalSourceExecutionDetectedQuery query,
            ExternalSourceEventDetectorProjection sourceRequestsProjection, ExternalSourceEventPublisher externalSourceEventPublisher)
        {
            _projectionContext = context;
            _projection = projection;
            _eventReader = reader;
            _query = query;
            _sourceRequestsProjection = sourceRequestsProjection;
            _externalSourceEventPublisher = externalSourceEventPublisher;
        }


        public void Run()
        {

            EnsureProjections();

            _eventReader.StartReading();

#if DEBUG
            new MonitoringEventsBuilder().ForExternalSourceEvents();
#endif

            Console.WriteLine("\nPress ANY key to stop reading and show results\n");
            Console.ReadKey();

            Stop();

            //  ShowRequestDetails();

            Console.WriteLine("Press ANY key exit");
            Console.ReadKey();

        }


        private void Stop()
        {
            _externalSourceEventPublisher.Stop();
        }

        private void EnsureProjections()
        {
            _projectionContext.EnableProjection("$by_category");
            _projectionContext.EnableProjection("$stream_by_category");

            _sourceRequestsProjection.Ensure();

            _externalSourceEventPublisher.Start();
        }

        //private void ShowRequestDetails()
        //{
        //    _query.SubscribeToEvent(ShowEvent);


        //    var value = _query.GetValue();
        //    Console.WriteLine("External Source  Details: {0}", value);

        //    //Console.WriteLine("Get Request Details");

        //    //ShowRequestDetails("externalSourceInformation");
        //    ////add other projections / streams
        //}

        //private void ShowRequestDetails(string name)
        //{
        //    _query.SubscriveToEvent(ShowEvent);


        //    var value = _query.GetValue();
        //    Console.WriteLine("External Source  Details: {0}", value);

        //}

        private void ShowEvent(ExternalSourceEventRead read)
        {
            Console.WriteLine("External Source Event: {0}", read);
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
