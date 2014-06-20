using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Systems
{
    public class SystemIdentifierMother
    {
        public static SystemIdentifier TestSystemIdentifier()
        {
            return new SystemIdentifierBuilder()
                .With(new DefaultTestSystem())
                .Build();
        }
    }
}