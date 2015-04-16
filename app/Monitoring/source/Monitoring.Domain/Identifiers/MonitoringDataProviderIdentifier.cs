using System;
using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    [Serializable]
    [DataContract]
    public class MonitoringDataProviderIdentifier
    {
        public MonitoringDataProviderIdentifier()
        {

        }

        public MonitoringDataProviderIdentifier(Guid id, DateTime date, SearchIdentifier dataProviderSearch,
            MonitoringActionIdentifier action)
        {
            Id = id;
            DataProviderSearch = dataProviderSearch;
            Date = date;
            Action = action;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public MonitoringActionIdentifier Action { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public SearchIdentifier DataProviderSearch { get; private set; }
    }
}
