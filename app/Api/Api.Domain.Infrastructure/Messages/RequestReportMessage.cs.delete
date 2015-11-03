using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Contracts;
using DataPlatform.Shared.Helpers;

namespace Api.Domain.Infrastructure.Messages
{
    [DataContract]
    public class RequestReportMessage
    {
        public RequestReportMessage(IRequest request, Guid requestId)
        {
            Request = request;
            RequestId = requestId;
            Date = SystemTime.Now();
        }

        [DataMember] public readonly IRequest Request;
        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DateTime Date;
    }
}
