using System;
namespace Workflow.Lace.Identifiers
{
    public class ResponseIdentifier
    {
        public Guid Id { get; set; }
        public Guid StreamId { get; private set; }
        public Guid RequestId { get; set; }
        public DateTime Date { get; set; }

        public ResponseIdentifier(Guid id, Guid streamId, Guid requestId, DateTime date)
        {
            Id = id;
            StreamId = streamId;
            RequestId = requestId;
            Date = date;
        }

        public ResponseIdentifier()
        {
            
        }
    }
}
