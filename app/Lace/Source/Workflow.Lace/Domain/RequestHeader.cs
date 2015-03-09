using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Lace.Domain
{
    public class RequestHeader
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public RequestIdentifier Request { get; set; }

        public RequestHeader(Guid id, DateTime date, RequestIdentifier request)
        {
            Id = id;
            Date = date;
            Request = request;
        }
    }
}
