using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.EventStore;
using EventTracking.Tests.Helper.Builder.Lace;
using Xunit.Extensions;

namespace EventTracking.Acceptence.Tests.Lace
{
    public class when_writing_events_from_lace_external_sources : Specification
    {
        private readonly IPersistAnEvent _persistAnEvent;
        private readonly IWriteToEventTrackingRepository _repository;

        public when_writing_events_from_lace_external_sources()
        {
          //  _persistAnEvent = new PersistEvent();
        }

        public override void Observe()
        {
           // new MonitoringEventsBuilder(_persistAnEvent).ForStartingAndEndingCallToIvid();
        }
    }
}

