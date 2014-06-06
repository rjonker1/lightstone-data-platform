﻿using System;
using EventTracking.Domain.Core;
using Monitoring.Events.Lace;
using Monitoring.Sources;

namespace Monitoring.Consumer.Lace.Aggregates
{
    public class ExternalSourcesResponseSuccesses : AggregateBase
    {

        public ExternalSourcesResponseSuccesses(Guid id, Guid aggregateId, FromSource source, string message,
            DateTime eventDate)
            : this()
        {
            RaiseEvent(new ExternalSourceResponseSuccessEvent(id, aggregateId, source.ToString(), message,
                eventDate));
        }

        private ExternalSourcesResponseSuccesses()
        {
            Register<ExternalSourceResponseSuccessEvent>(e => Id = e.AggregateId);
        }
    }
}