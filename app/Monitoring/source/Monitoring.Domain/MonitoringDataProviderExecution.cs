using System.Runtime.Serialization;
using Monitoring.Domain.Identifiers;

namespace Monitoring.Domain
{
    [DataContract]
    public class MonitoringDataProviderExecution
    {

        public MonitoringDataProviderExecution(DataProviderCommandIdentifier command, DataProviderIdentifier dataProvider,
            string elapsedTime = "00:00:00")
        {
            Command = command;
            DataProvider = dataProvider;
            ElapsedTime = elapsedTime;
        }

        [DataMember]
        public DataProviderCommandIdentifier Command { get; private set; }
        [DataMember]
        public DataProviderIdentifier DataProvider { get; private set; }

        [DataMember]
        public string ElapsedTime { get; private set; }
    }
}
