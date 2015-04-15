using System;
using System.Runtime.Serialization;
using Monitoring.Domain.Identifiers;

namespace Monitoring.Domain
{
    [Serializable]
    [DataContract]
    public class MonitoringDataProviderTransaction
    {
        public MonitoringDataProviderTransaction(MonitoringDataProviderIdentifier monitoring)
        {
            Monitoring = monitoring;
        }

        [DataMember]
        public MonitoringDataProviderIdentifier Monitoring { get; private set; }
    }
}
