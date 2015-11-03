using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Dto;
using DataPlatform.Shared.Helpers;

namespace Api.Domain.Core.Messages
{
    [DataContract]
    public class RequestMetadataMessage
    {
        public RequestMetadataMessage()
        {
            Header = new RequestHeaderMetadataDto();
            Url = new RequestUrlMetadataDto();
        }

        public RequestMetadataMessage(RequestHeaderMetadataDto header, RequestUrlMetadataDto url, Guid requestId, string user, string userHostAddress, string method, string path)
        {
            Header = header;
            Url = url;
            RequestId = requestId;
            User = user;
            UserHostAddress = userHostAddress;
            Method = method;
            Path = path;
            Date = SystemTime.Now();
        }

        [DataMember] public readonly RequestHeaderMetadataDto Header;
        [DataMember] public readonly RequestUrlMetadataDto Url;
        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DateTime Date;
        [DataMember] public readonly string User;
        [DataMember] public readonly string UserHostAddress;
        [DataMember] public readonly string Method;
        [DataMember] public readonly string Path;
    }
}
