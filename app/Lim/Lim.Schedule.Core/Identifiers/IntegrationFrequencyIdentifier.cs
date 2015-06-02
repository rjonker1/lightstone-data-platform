using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class IntegrationFrequencyIdentifier
    {
         [DataMember]
        public string Frequency { get; private set; }

        [DataMember]
        public short Id { get; private set; }

        public IntegrationFrequencyIdentifier(string frequency, short id)
        {
            Frequency = frequency;
            Id = id;
        }
    }
}
