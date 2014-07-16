using System;
using System.Linq;
using EasyNetQ;
using EventStore.ClientAPI;
using EventTracking.Measurement.Dto;
using EventTracking.Measurement.Lace.Projections;
using EventTracking.Measurement.Repository;
using EventTracking.Tests.Helper.Builder.Lace;
using EventTracking.Tests.Helper.Fakes.Measurement;

namespace EventTracking.Measurement.Lace.Measurements
{
    public class RequestFromSourceMeasurements
    {

        private readonly IProjectionContext _projectionContext;

        private readonly ExternalSourceEventPublisher _externalSourceEventPublisher;

        private readonly EventReader _eventReader;

        private readonly ExternalSourceEventDetectorProjection _sourceRequestsProjection;

        private static readonly IRepository<ExternalSourceExecutionResultDto> Repository =
            new FakeSourceExecutionRepository();

        public RequestFromSourceMeasurements(IEventStoreConnection connection, IProjectionContext context, IBus bus)
        {
            _projectionContext = context;
            _eventReader = new EventReader(connection);
            _sourceRequestsProjection = new ExternalSourceEventDetectorProjection(_projectionContext);
            _externalSourceEventPublisher = new ExternalSourceEventPublisher(connection, bus, Repository);
        }


        public void Run()
        {

            var key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.S)
            {
                GetEvents();

                Console.WriteLine("\n\nPress S to Stop or any key to refresh");
                key = Console.ReadKey();
            }


            Console.WriteLine("Press ANY key close");
            Console.ReadKey();

            Stop();

        }

        private void GetEvents()
        {
            EnsureProjections();

            _eventReader.StartReading();

#if DEBUG
            new MonitoringEventsBuilder().PersistToEventStore().ForExternalSourceEvents();
#endif

            Console.WriteLine("\nPress ANY key to show results\n");
            Console.ReadKey();

            Stop();

            ShowRequestDetails();

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


        private static void ShowRequestDetails()
        {

            var results = Repository.GetAll();

            if (results == null || !results.Any()) return;

            var grouped = results.GroupBy(g => g.AggregateId, times => times, (guid, elements) => new
            {
                AggregateId = guid,
                times = elements
            });


            foreach (var source in grouped)
            {
                foreach (var sourceTime in source.times.OrderBy(o => o.Source).ThenBy(o => o.Order))
                {
                    Console.WriteLine("{0} {1} {2}", sourceTime.AggregateId, sourceTime.Source, sourceTime.TimeStamp);
                }

                Console.WriteLine();
            }


            foreach (var source in grouped)
            {

                var sources = source.times.GroupBy(g => g.Source, aggregate => aggregate, (id, aggr) => new
                {
                    Source = id,
                    Aggregate = aggr
                }).Select(s => new
                {
                    Source = s.Source,
                    AggregateId = s.Aggregate.FirstOrDefault().AggregateId
                });


                foreach (var src in sources.OrderBy(o => o.AggregateId))
                {
                    if (source.times.Count(w => w.Source == src.Source) <= 1) continue;

                    Console.WriteLine();
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("Source {0} ( Aggregate Id {1} )", src.Source, src.AggregateId);
                    Console.WriteLine("Start Time: {0}",
                        source.times.FirstOrDefault(s => s.ExecutionStartTime != null && s.Source == src.Source)
                            .ExecutionStartTime.Value);
                    Console.WriteLine("End Time: {0}",
                        source.times.FirstOrDefault(s => s.ExecutionEndTime != null && s.Source == src.Source)
                            .ExecutionEndTime.Value);
                    Console.WriteLine("Time Taken: {0}",
                        SetExecutionTime(
                            source.times.FirstOrDefault(s => s.ExecutionStartTime != null && s.Source == src.Source)
                                .ExecutionStartTime.Value,
                            source.times.FirstOrDefault(s => s.ExecutionEndTime != null && s.Source == src.Source)
                                .ExecutionEndTime.Value));
                    Console.WriteLine();
                    Console.WriteLine("=============================================================");
                }

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
