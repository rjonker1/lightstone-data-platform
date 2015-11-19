using System;

namespace Workflow.Lace.Identifiers
{
    public class EventIndentifier
    {
        public EventIndentifier()
        {
            
        }

        public EventIndentifier(Guid requestId, EventPayloadIndentifier payload, DateTime commitStamp)
        {
            Id = requestId;
            Payload = payload;
            CommitStamp = commitStamp;
        }

        public Guid Id { get; private set; }
        public EventPayloadIndentifier Payload { get; private set; }
        public DateTime CommitStamp { get; private set; }
    }
}
