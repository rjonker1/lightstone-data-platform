using System;
namespace Workflow.DataProvider.Bus.Domain.Indentifiers
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
