using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.Storage.Providers;
using Monitoring.Events.Lace;
using Xunit.Extensions;

namespace Monitoring.Unit.Tests.Lace.Events
{
    public class when_external_source_event_gets_read : Specification
    {
      
        private IRepository _repo;

        public override void Observe()
        {
            _repo = new EventStoreConnectionFactory().Instance().Repository;
        }

        [Observation]
        public void get_stream_by_name_test()
        {

            var streams = _repo.GetStreams<ExternalSourceHandledEvent>("externalSourcesHandled", 1000);

            streams.ShouldNotBeNull();

        }
    }
}
