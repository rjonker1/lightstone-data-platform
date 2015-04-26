using System;

namespace Workflow.Lace.Identifiers
{
    public class CommandIndentifier
    {
        public CommandIndentifier()
        {
            
        }

        public CommandIndentifier(Guid requestId, CommandPayloadIndentifier payload)
        {
            Id = requestId;
            Payload = payload;
        }

        public Guid Id { get; private set; }
        public CommandPayloadIndentifier Payload { get; private set; }
    }
}
