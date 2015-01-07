using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Messaging.Events;

namespace Monitoring.Test.Helper.Builder.DataProviderEvents
{
    public class DataProviderEvents
    {
        public MonitoringEvent ForDataProviderEvent(Guid aggreateId,string payload, DateTime date )
        {
            return new MonitoringEvent(aggreateId, payload,date, MonitoringSource.Lace);
        }

    }
}
