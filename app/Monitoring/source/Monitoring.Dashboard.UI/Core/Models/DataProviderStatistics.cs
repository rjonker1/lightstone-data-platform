using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [DataContract]
    public class DataProviderStatistics
    {
        public DataProviderStatistics()
        {
            
        }

        [DataMember]
        public string AvgerageRequestTime { get; set; }

        [DataMember]
        public double TotalRequests { get; set; }

        [DataMember]
        public double TotalResponses { get; set; }

        [DataMember]
        public double TotalErrors { get; set; }
    }
}