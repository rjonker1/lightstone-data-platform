﻿using System;
using EventTracking.Domain.Core;
using Monitoring.Modules.Lace.AggregateEvents;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.Aggregates
{
    public class AggregateExternalSourceInformation : AggregateBase
    {
        public AggregateExternalSourceInformation(Guid id, Guid aggregateId, FromSource source, string message, DateTime eventDate)
            : this()
        {
            RaiseEvent(new AggregateExternalSourceEvent(id, aggregateId, source.ToString(), message, eventDate));
        }

        private AggregateExternalSourceInformation()
        {

            Register<AggregateExternalSourceEvent>(e => Id = e.AggregateId);
        }

    }

}
