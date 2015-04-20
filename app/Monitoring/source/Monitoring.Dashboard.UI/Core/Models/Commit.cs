using System;
using System.Runtime.Serialization;
using System.Text;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class Commit
    {
        [DataMember]
        public string StreamIdOriginal { get; set; }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public int CommitSequence { get; set; }

        [DataMember]
        public DateTime CommitStamp { get; set; }
       
    }
}