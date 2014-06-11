using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Systems
{
    public interface IDefineSystemIdentifier
    {
        string Name { get; }
        ServerIdentifier Server { get; }
    }
}