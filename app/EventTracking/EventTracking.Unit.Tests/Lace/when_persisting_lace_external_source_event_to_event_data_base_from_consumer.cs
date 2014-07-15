using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventTracking.Domain.Persistence;
using EventTracking.Tests.Helper.Builder.Lace;
using EventTracking.Tests.Helper.Fakes.Persistence;
using EventTracking.Tests.Helper.Mother.EventStore;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Consumer.Lace.Messages;
using Newtonsoft.Json;
using Xunit.Extensions;

namespace EventTracking.Unit.Tests.Lace
{
    public class when_persisting_lace_external_source_event_to_event_data_base_from_consumer : Specification
    {
        private readonly IPersistEvent _persistEvent;
        private LaceExternalSourceExecutionEventMessage _message;
        private readonly Guid _aggregateId;
        private ExternalSourceExecutedConsumer _consumer;

        private string _streamName;

        public when_persisting_lace_external_source_event_to_event_data_base_from_consumer()
        {
            _persistEvent = new FakePersistEvent();
            _aggregateId = Guid.NewGuid();

            FakeDatabase.Events.Clear();
        }

        public override void Observe()
        {
            _message = new EventMessagesBuilder(_aggregateId).ForIvidStartCallingExternalSourceEvent();
            _consumer = new ExternalSourceExecutedConsumer(_persistEvent);
            _consumer.Consume(_message);

            _streamName = string.Format("{0}-{1}", _message.Category, _aggregateId.ToString("N"));
        }

        [Observation]
        public void external_source_event_should_be_persisted()
        {
            FakeDatabase.Events.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void external_source_event_shouls_have_valid_stream_name()
        {
            FakeDatabase.Events.Count(c => c.Key == _streamName).ShouldNotEqual(0);
        }

        [Observation]
        public void external_source_event_data_should_not_be_null()
        {
            var eventData = FakeDatabase.Events.SingleOrDefault(c => c.Key == _streamName).Value;

            eventData.ShouldNotBeNull();
        }

        [Observation]
        public void external_source_event_data_should_not_be_json()
        {
            var eventData = FakeDatabase.Events.SingleOrDefault(c => c.Key == _streamName).Value;

            eventData.IsJson.ShouldBeTrue();
        }

        [Observation]
        public void external_source_event_data_should_serialize_into_json_string()
        {
            var eventData = FakeDatabase.Events.SingleOrDefault(c => c.Key == _streamName).Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Data);

            jsonString.ShouldNotBeNull();
            jsonString.ShouldNotBeEmpty();
        }

        [Observation]
        public void external_source_event_data_should_deserialize_into_json_object()
        {
            var eventData = FakeDatabase.Events.SingleOrDefault(c => c.Key == _streamName).Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            jsonData.ShouldNotBeNull();
            jsonData.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void external_source_event_data_category_key_should_be_valid()
        {
            var eventData = FakeDatabase.Events.SingleOrDefault(c => c.Key == _streamName).Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            jsonData.Keys.Count(c => c == "Category").ShouldNotEqual(0);
        }
    }
}
