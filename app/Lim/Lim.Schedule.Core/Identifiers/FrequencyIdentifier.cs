using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class FrequencyIdentifier
    {
         [DataMember]
        public string Frequency { get; private set; }

        [DataMember]
        public short Id { get; private set; }

        public FrequencyIdentifier(string frequency, short id)
        {
            Frequency = frequency;
            Id = id;
        }
    }
}
