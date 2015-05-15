using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class FrequencyType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }

    [DataContract]
    public class FrequencyConfiguration
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int Seconds { get; set; }

        [DataMember]
        public int Minutes { get; set; }

        [DataMember]
        public int Hours { get; set; }

        [DataMember]
        public string DayOfMonth { get; set; }

        [DataMember]
        public string Month { get; set; }

        [DataMember]
        public string DayofWeek { get; set; }
    }
}