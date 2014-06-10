using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public class PackageIdentifierMother
    {
        public static PackageIdentifier DefaultPackageIdentifier()
        {
            return new PackageIdentifierBuilder().With(new DefaultPackageIdentifier()).Build();
        }
    }
}