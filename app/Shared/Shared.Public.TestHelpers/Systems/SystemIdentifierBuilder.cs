using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Systems
{
    public class SystemIdentifierBuilder
    {
        private string name;
        private ServerIdentifier server;

        public SystemIdentifierBuilder()
        {
            server = ServerIdentifier.Create();
        }

        public SystemIdentifier Build()
        {
            return new SystemIdentifier(name, server);
        }

        public SystemIdentifierBuilder With(IDefineSystemIdentifier data)
        {
            return WithName(data.Name)
                .WithServer(data.Server);
        }

        public SystemIdentifierBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public SystemIdentifierBuilder WithServer(ServerIdentifier server)
        {
            this.server = server;
            return this;
        }
    }
}