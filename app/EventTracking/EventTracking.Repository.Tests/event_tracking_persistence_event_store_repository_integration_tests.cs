using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using EventTracking.Domain;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.Storage;
using EventTracking.Repository.Tests.Data;
using Newtonsoft.Json.Linq;
using Xunit;
#pragma warning disable 169
// ReSharper disable InconsistentNaming
using Xunit.Extensions;
namespace EventTracking.Repository.Tests
{
    public class event_tracking_persistence_event_store_repository_integration_tests : Specification, IDisposable
    {

        private static readonly IPEndPoint IntegrationTestTcpEndPoint = new IPEndPoint(IPAddress.Loopback, 1113);

        private IEventStoreConnection _connection;
        private EventStoreRepository _repo;

        public override void Observe()
        {
            _connection = EventStoreConnection.Create(IntegrationTestTcpEndPoint);
            _connection.Connect();
            _repo = new EventStoreRepository(_connection);
        }


        [Observation]
        public void event_tracking_can_get_latest_version_by_id()
        {
            var savedId = SaveTestAggregateWithoutCustomHeaders(_repo, 100 /* excludes AggregateCreated */);

            var retrieved = _repo.GetById<EventTrackingTestAggregate>(savedId);
            retrieved.AppliedEventCount.ShouldEqual(100);
            
        }

        [Observation]
        public void event_tracking_can_get_specific_version_from_first_page_by_id()
        {
            var savedId = SaveTestAggregateWithoutCustomHeaders(_repo, 100 /* excludes AggregateCreated */);

            var retrieved = _repo.GetById<EventTrackingTestAggregate>(savedId, 65);
            //retrieved.AppliedEventCount.ShouldEqual(64);
            retrieved.AppliedEventCount.ShouldEqual(65);
        }

        [Observation]
        public void event_tracking_can_get_specific_version_from_subsequent_page_by_id()
        {
            var savedId = SaveTestAggregateWithoutCustomHeaders(_repo, 500 /* excludes AggregateCreated */);

            var retrieved = _repo.GetById<EventTrackingTestAggregate>(savedId, 126);
            //retrieved.AppliedEventCount.ShouldEqual(125);
            retrieved.AppliedEventCount.ShouldEqual(126);
        }

        //[Observation]
        //public void event_tracking_can_handle_large_number_of_events_in_one_transaction()
        //{
        //    const int numberOfEvents = 50000;

        //    var aggregateId = SaveTestAggregateWithoutCustomHeaders(_repo, numberOfEvents);

        //    var saved = _repo.GetById<EventTrackingTestAggregate>(aggregateId);
        //    numberOfEvents.ShouldEqual(saved.AppliedEventCount);
        //}


        //[Observation]
        //public void event_tracking_can_save_existing_aggregate()
        //{
        //    var savedId = SaveTestAggregateWithoutCustomHeaders(_repo, 100 /* excludes TestAggregateCreated */);

        //    var firstSaved = _repo.GetById<EventTrackingTestAggregate>(savedId);
        //    firstSaved.ProduceEvents(50);
        //    _repo.Save(firstSaved, Guid.NewGuid(), d => { });

        //    var secondSaved = _repo.GetById<EventTrackingTestAggregate>(savedId);
        //    secondSaved.AppliedEventCount.ShouldEqual(150);
        //}

        //[Observation]
        //public void event_tracking_can_save_multiples_of_write_page_size()
        //{
        //    var savedId = SaveTestAggregateWithoutCustomHeaders(_repo, 1500 /* excludes TestAggregateCreated */);
        //    var saved = _repo.GetById<EventTrackingTestAggregate>(savedId);
        //    saved.AppliedEventCount.ShouldEqual(1500);
        //}

        [Observation]
        public void event_tracking_clears_events_from_aggregate_once_committed()
        {
            var aggregateToSave = new EventTrackingTestAggregate(Guid.NewGuid());
            aggregateToSave.ProduceEvents(10);
            _repo.Save(aggregateToSave, Guid.NewGuid(), d => { });

            ((IAggregate)aggregateToSave).GetUncommittedEvents().Count.ShouldEqual(0);
        }

        //[Observation]
        //public void event_tracking_throws_on_requesting_specific_version_higher_than_exists()
        //{
        //    var aggregateId = SaveTestAggregateWithoutCustomHeaders(_repo, 10);
            

        //    Assert.Throws<AggregateVersionException>(() => _repo.GetById<EventTrackingTestAggregate>(aggregateId, 50));
        //}

        //[Observation]
        //public void event_tracking_throws_on_get_deleted_aggregate()
        //{
        //    var aggregateId = SaveTestAggregateWithoutCustomHeaders(_repo, 10);

        //    var streamName = string.Format("testAggregate-{0}", aggregateId.ToString("N"));
        //    _connection.DeleteStream(streamName, 11);

        //    Assert.Throws<AggregateDeletedException>(() => _repo.GetById<EventTrackingTestAggregate>(aggregateId));
        //}

        [Observation]
        public void event_tracking_saves_commit_headers_on_each_event()
        {
            var commitId = Guid.NewGuid();
            var aggregateToSave = new EventTrackingTestAggregate(Guid.NewGuid());
            aggregateToSave.ProduceEvents(20);
            _repo.Save(aggregateToSave, commitId, d =>
            {
                d.Add("CustomHeader1", "CustomValue1");
                d.Add("CustomHeader2", "CustomValue2");
            });

            var read = _connection.ReadStreamEventsForward(string.Format("aggregate-{0}", aggregateToSave.Id), 1, 20, false);
            foreach (var serializedEvent in read.Events)
            {
                var parsedMetadata = JObject.Parse(Encoding.UTF8.GetString(serializedEvent.OriginalEvent.Metadata));
                var deserializedCommitId = parsedMetadata.Property("CommitId").Value.ToObject<Guid>();
                commitId.ShouldEqual(deserializedCommitId);

                

                var deserializedCustomHeader1 = parsedMetadata.Property("CustomHeader1").Value.ToObject<string>();
                deserializedCustomHeader1.ShouldEqual("CustomValue1");

                var deserializedCustomHeader2 = parsedMetadata.Property("CustomHeader2").Value.ToObject<string>();
                deserializedCustomHeader2.ShouldEqual("CustomValue2");
            }
        }


        public void Dispose()
        {
            _connection.Close();
        }


        private static Guid SaveTestAggregateWithoutCustomHeaders(IRepository repository, int numberOfEvents)
        {
            var aggregateToSave = new EventTrackingTestAggregate(Guid.NewGuid());
            aggregateToSave.ProduceEvents(numberOfEvents);
            repository.Save(aggregateToSave, Guid.NewGuid(), d => { });
            return aggregateToSave.Id;
        }
    }
}
// ReSharper enable InconsistentNaming
#pragma warning restore 169