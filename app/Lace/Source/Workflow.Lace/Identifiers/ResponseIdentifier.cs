using System;
namespace Workflow.Lace.Identifiers
{
    public class ResponseIdentifier
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public DateTime Date { get; set; }

        public ResponseIdentifier(Guid id, Guid requestId, DateTime date)
        {
            Id = id;
            RequestId = requestId;
            Date = date;
        }

        public ResponseIdentifier()
        {
            
        }
    }
}
