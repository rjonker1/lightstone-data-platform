using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Dto;

namespace Api.Domain.Core.Messages
{
    [DataContract]
    public class RequestReportMessage
    {
        public RequestReportMessage(RequestDto request, Guid requestId)
        {
            Request = request;
            RequestId = requestId;
        }

        [DataMember] public readonly RequestDto Request;
        [DataMember] public readonly Guid RequestId;
    }
}
