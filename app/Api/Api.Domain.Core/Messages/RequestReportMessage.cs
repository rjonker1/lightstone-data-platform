using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Dto;
using DataPlatform.Shared.Helpers;

namespace Api.Domain.Core.Messages
{
    [DataContract]
    public class RequestReportMessage
    {
        public RequestReportMessage()
        {
            Request = new RequestDto();
        }

        public RequestReportMessage(RequestDto request, Guid requestId)
        {
            Request = request;
            RequestId = requestId;
            Date = SystemTime.Now();
        }

        [DataMember] public readonly RequestDto Request;
        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DateTime Date;
    }
}
