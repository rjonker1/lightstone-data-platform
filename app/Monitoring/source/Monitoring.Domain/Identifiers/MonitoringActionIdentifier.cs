using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    public class MonitoringActionIdentifier
    {
        [DataMember]
        public string Name { get; private set; }

        public MonitoringActionIdentifier(string name)
        {
            Name = name;
        }
    }
}
