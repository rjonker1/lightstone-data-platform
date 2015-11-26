using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.Infrastructure.Dto
{
    [DataContract]
    public class ApiRequestDto
    {
        public ApiRequestDto()
        {
            
        }

        public ApiRequestDto(List<ApiRequestUserAgentDto> userAgents, List<ApiRequestMonitoringDto> apiRequests)
        {
            UserAgents = userAgents;
            ApiRequests = apiRequests;
            TotalDisplayedRequests = apiRequests.Count;
        }


        [DataMember]
        public List<ApiRequestUserAgentDto> UserAgents { get; private set; }
        [DataMember]
        public List<ApiRequestMonitoringDto> ApiRequests { get; private set; }
        [DataMember]
        public int TotalDisplayedRequests { get; private set; }
    }


    [DataContract]
    public class ApiRequestUserAgentDto
    {
        public ApiRequestUserAgentDto()
        {
            
        }
        public ApiRequestUserAgentDto(string label, int value, Enums.UserAgent userAgent)
        {
            Label = label;
            Value = value;
            UserAgent = userAgent;
        }

        [DataMember]
        public string Label { get; private set; }
        [DataMember]
        public int Value { get; private set; }
        [DataMember]
        public Enums.UserAgent UserAgent { get; private set; }
    }


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