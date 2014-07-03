using System;
using System.Linq;
using EasyNetQ;
using EventStore.ClientAPI;
using EventTracking.Measurement.Dto;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Repository;
using EventTracking.Tests.Helper.Builder.Lace;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;
     
        private readonly ExternalSourceEventPublisher _externalSourceEventPublisher;

        private readonly EventReader _eventReader;

        private readonly ExternalSourceEventDetectorProjection _sourceRequestsProjection;

        private static readonly IRepository<ExternalSourceExecutionResultDto> Repository = new FakeSourceExecutionRepository();

        public RequestFromSourceMeasurements(IEventStoreConnection connection, IProjectionContext context, IBus bus)
        {
            _projectionContext = context;
            _eventReader = new EventReader(connection);
            _sourceRequestsProjection = new ExternalSourceEventDetectorProjection(_projectionContext);
            _externalSourceEventPublisher = new ExternalSourceEventPublisher(connection, bus, Repository);
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

            ShowRequestDetails();

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


        private void ShowRequestDetails()
        {
            var results = Repository.GetAll();

            if (results == null || !results.Any()) return;

            var grouped = results.GroupBy(g => g.AggregateId, times => times, (guid, elements) => new
            {
                AggregateId = guid,
                times = elements
            }).ToList();

            foreach (var source in grouped)
            {
                foreach (var sourceTime in source.times.OrderBy(o => o.Order))
                {
                    Console.WriteLine("{0} {1} {2}", sourceTime.AggregateId, sourceTime.Source, sourceTime.TimeStamp);
                }

                //Console.WriteLine("Execution Start Time: {0}", source.times.Single(s => s.ExecutionStartTime != null).ExecutionStartTime.Value);
                //Console.WriteLine("Execution End Time: {0}", source.times.Single(s => s.ExecutionEndTime != null).ExecutionEndTime.Value);
                //Console.WriteLine("Total Execution Time: {0}", SetExecutionTime(source.times.Single(s => s.ExecutionStartTime != null).ExecutionStartTime.Value, source.times.Single(s => s.ExecutionEndTime != null).ExecutionEndTime.Value));

                //Console.WriteLine();
                Console.WriteLine();
            }
        }

        
        private static string SetExecutionTime(DateTime startTime, DateTime endTime)
        {
            var time = (endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;
            return time.ToString("N");
        }
    }
}
