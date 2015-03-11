using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Lace.Domain
{
    public class RequestHeader
    {
        public Guid Id { get; set; }
        public Guid StreamId { get; private set; }
        public DateTime Date { get; set; }
        public RequestIdentifier Request { get; set; }

        public RequestHeader(Guid id, Guid streamId, DateTime date, RequestIdentifier request)
        {
            Id = id;
            StreamId = streamId;
            Date = date;
            Request = request;
        }
    }
}
