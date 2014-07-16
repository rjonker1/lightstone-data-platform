using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventTracking.Domain.Persistence;
using EventTracking.Tests.Helper.Builder.Lace;
using EventTracking.Tests.Helper.Fakes.EventStore;
using EventTracking.Tests.Helper.Fakes.Persistence;
using Monitoring.Sources.Lace;
using Newtonsoft.Json;
using Xunit.Extensions;

namespace EventTracking.Unit.Tests.Lace
{
    public class when_persisting_lace_start_and_end_call_ivid_events : Specification
    {

        private readonly IPersistAnEvent _persistAnEvent;

        private when_persisting_lace_start_and_end_call_ivid_events()
        {
            _persistAnEvent = new FakePersistEvent();
        }

        public override void Observe()
        {
            FakeDatabase.Events.Clear();
            new MonitoringEventsBuilder(_persistAnEvent).ForStartingAndEndingCallToIvid();
        }

        [Observation]
        public void events_for_ivid_calling_events_should_be_persisted()
        {
            FakeDatabase.Events.Count.ShouldNotEqual(0);
        }

        [Observation]
        public void events_for_ivid_source_calling_category_should_be_valid()
        {
            var eventData = FakeDatabase.Events.First().Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            var category = jsonData.Keys.Where(c => c == "Category");
            category.FirstOrDefault().ShouldEqual(Categories.LaceExecutingExternalSource);
        }


        [Observation]
        public void events_fr_ivid_source_event_data_category_key_should_be_valid()
        {
            var eventData = FakeDatabase.Events.First().Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            jsonData.Keys.Count(c => c == "Category").ShouldNotEqual(0);
        }
    }
}
