using System;

namespace Workflow.Lace.Identifiers
{
    public class EventIndentifier
    {
        public EventIndentifier()
        {
            
        }

        public EventIndentifier(Guid requestId, EventPayloadIndentifier payload)
        {
            Id = requestId;
            Payload = payload;
        }

        public Guid Id { get; private set; }
        public EventPayloadIndentifier Payload { get; private set; }
    }
}
