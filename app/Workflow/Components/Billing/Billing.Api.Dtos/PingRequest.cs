using DataPlatform.Shared.Public.Identifiers;

namespace Billing.Api.Dtos
{
    public class PingRequest
    {
        public PingRequest()
        {
        }

        public PingRequest(SystemIdentifier system)
            : this(system, ServerIdentifier.Create())
        {
        }

        public PingRequest(SystemIdentifier system, ServerIdentifier server)
        {
            System = system;
            Server = server;
        }

        public SystemIdentifier System { get; private set; }
        public ServerIdentifier Server { get; private set; }
    }
}