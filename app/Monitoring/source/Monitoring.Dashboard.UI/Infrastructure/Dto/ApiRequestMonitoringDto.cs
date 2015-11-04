using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    [DataContract]
    public class ApiRequestMonitoringDto
    {
        public ApiRequestMonitoringDto()
        {
            
        }

        public ApiRequestMonitoringDto(Guid requesteId, DateTime requestDate, string userHostAddress, string authorization, string username,
            string method, string basePath, string hostName, bool isSecure, int? port, string query, string siteBase, string scheme,
            string host, string userAgent, string contentType, DateTime commitDate)
        {
            RequestId = requesteId;
            RequestDate = requestDate;
            UserHostAddress = userHostAddress;
            Authorization = authorization;
            UserName = username;
            Method = method;
            BasePath = basePath;
            HostName = hostName;
            IsSecure = isSecure;
            Query = query;
            SiteBase = siteBase;
            Scheme = scheme;
            Host = host;
            UserAgent = userAgent;
            ContentType = contentType;
            CommitDate = commitDate;
            Port = port ?? 0;
        }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DateTime RequestDate { get; private set; }

        [DataMember]
        public string UserHostAddress { get; private set; }

        [DataMember]
        public string Authorization { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public string Method { get; private set; }

        [DataMember]
        public string BasePath { get; private set; }

        [DataMember]
        public string HostName { get; private set; }

        [DataMember]
        public bool IsSecure { get; private set; }

        [DataMember]
        public int Port { get; private set; }

        [DataMember]
        public string Query { get; private set; }

        [DataMember]
        public string SiteBase { get; private set; }

        [DataMember]
        public string Scheme { get; private set; }

        [DataMember]
        public string Host { get; private set; }

        [DataMember]
        public string UserAgent { get; private set; }

        [DataMember]
        public string ContentType { get; private set; }

        [DataMember]
        public DateTime CommitDate { get; private set; }
    }
}