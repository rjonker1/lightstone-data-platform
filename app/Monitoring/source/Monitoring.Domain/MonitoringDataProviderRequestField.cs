using System;
using System.Runtime.Serialization;
using Monitoring.Domain.Identifiers;

namespace Monitoring.Domain
{
    [DataContract]
    public class MonitoringDataProviderRequestField
    {
        public MonitoringDataProviderRequestField(DataProviderIdentifier dataProvider, RequestFieldIdentifier requestField)
        {
            DataProvider = dataProvider;
            RequestField = requestField;
        }

        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public RequestFieldIdentifier RequestField { get; private set; }
    }
}
