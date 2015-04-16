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

        public MonitoringDataProviderIdentifier(Guid id, DateTime date, SearchIdentifier dataProviderSearch)
        {
            Id = id;
            DataProviderSearch = dataProviderSearch;
            Date = date;
        }

        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public Guid StreamId { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public SearchIdentifier DataProviderSearch { get; private set; }
    }
}
