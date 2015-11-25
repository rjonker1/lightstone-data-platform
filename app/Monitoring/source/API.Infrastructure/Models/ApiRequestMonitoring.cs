using System;
using System.Runtime.Serialization;

namespace Api.Infrastructure.Models
{
    [DataContract]
    public class ApiRequestMonitoring
    {
        private const string GetApiRequests = "select top 1000 * from ApiRequestMonitoring order by [RequestDate] desc";

        public static string SelectStatement()
        {
            return GetApiRequests;
        }

        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public DateTime RequestDate { get; set; }

        [DataMember]
        public string UserHostAddress { get; set; }

        [DataMember]
        public string Authorization { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Method { get; set; }

        [DataMember]
        public string BasePath { get; set; }

        [DataMember]
        public string HostName { get; set; }

        [DataMember]
        public bool IsSecure { get; set; }

        [DataMember]
        public int? Port { get; set; }

        [DataMember]
        public string Query { get; set; }

        [DataMember]
        public string SiteBase { get; set; }

        [DataMember]
        public string Scheme { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public string UserAgent { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        [DataMember]
        public DateTime CommitDate { get; set; }
    }
}