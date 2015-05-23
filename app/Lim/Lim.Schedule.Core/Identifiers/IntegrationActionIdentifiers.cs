using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class IntegrationActionIdentifier
    {
        [DataMember]
        public string Action { get; private set; }

        public IntegrationActionIdentifier(string action)
        {
            Action = action;
        }
    }
}
