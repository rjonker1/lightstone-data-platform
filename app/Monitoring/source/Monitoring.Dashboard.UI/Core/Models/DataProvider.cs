using System;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class DataProvider
    {
        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public string SearchType { get; set; }

        [DataMember]
        public string SearchTerm { get; set; }

        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
      
    }

    [DataContract]
    public class Results
    {
        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}