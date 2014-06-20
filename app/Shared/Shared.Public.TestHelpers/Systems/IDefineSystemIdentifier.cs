using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Systems
{
    public interface IDefineSystemIdentifier
    {
        string Name { get; }
        ServerIdentifier Server { get; }
    }
}