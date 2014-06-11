using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Systems
{
    public class DefaultTestSystem : IDefineSystemIdentifier
    {
        public string Name
        {
            get { return "TESTING"; }
        }

        public ServerIdentifier Server
        {
            get { return ServerIdentifier.Create(); }
        }
    }
}