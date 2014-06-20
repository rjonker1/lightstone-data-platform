using System;
using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public class PackageIdentifierBuilder
    {
        private Guid id;
        private VersionIdentifier version;

        public PackageIdentifier Build()
        {
            return new PackageIdentifier(id, version);
        }

        public PackageIdentifierBuilder With(IDefinePackageIdentifer data)
        {
            return WithId(data.Id)
                .WithVersion(data.Version);
        }

        public PackageIdentifierBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public PackageIdentifierBuilder WithVersion(VersionIdentifier version)
        {
            this.version = version;
            return this;
        }
    }
}