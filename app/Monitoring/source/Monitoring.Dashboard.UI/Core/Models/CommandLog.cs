using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class CommandLog
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public int CommitSequence { get; set; }

        [DataMember]
        public long CommitNumber { get; set; }

        [DataMember]
        public DateTime CommitStamp { get; set; }

    }
}