using System;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Monitoring.DomainModel.DataProviders
{
    public class MonitoringEvents : AggregateBase
    {
        private MonitoringEvents(Guid id)
        {
            Id = id;
            Register<MonitoringEvent>(e => Id = id);
        }

        public MonitoringEvents(Guid id, string payload, DateTime date, MonitoringSource source)
            : this(id)
        {
            RaiseEvent(new MonitoringEvent(id, payload, date,source));
        }

        public void Add(Guid id, string payload, DateTime date, MonitoringSource source)
        {
            RaiseEvent(new MonitoringEvent(id, payload, date, source));
        }
    }
}
