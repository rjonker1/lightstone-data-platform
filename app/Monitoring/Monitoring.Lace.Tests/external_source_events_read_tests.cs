﻿using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.Storage.Providers;
using Monitoring.Events.Lace;
using Xunit.Extensions;

namespace Monitoring.Lace.Tests
{
    public class external_source_events_read_tests : Specification
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