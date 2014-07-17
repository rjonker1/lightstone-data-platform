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
    public class when_writing_lace_start_and_end_call_ivid_events : Specification
    {
        private readonly IPersistAnEvent _persistAnEvent;
        public when_writing_lace_start_and_end_call_ivid_events()
        {
            _persistAnEvent = new FakePersistEvent();
        }


        public override void Observe()
        {
            FakeDatabase.Events.Clear();
            new MonitoringEventsBuilder(_persistAnEvent).ForStartingAndEndingCallToIvid();
        }

        [Observation]
        public void event_category_should_be_valid_for_external_source_event()
        {
            var eventData = FakeDatabase.Events.First().Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Event.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            var category = jsonData.Values.Where(c => c.ToString() == Categories.LaceExecutingExternalSource);
            category.ShouldNotBeNull();
            category.Count().ShouldEqual(1);
        }

        [Observation]
        public void event_category_for_calling_ivid_source_should_not_be_null()
        {
            var eventData = FakeDatabase.Events.First().Value;

            var jsonString = Encoding.UTF8.GetString(eventData.Event.Data);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonString);

            jsonData.Keys.Count(c => c == "Category").ShouldNotEqual(0);
        }
    }

}
