using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class PackageIdentifier
    {
        public PackageIdentifier()
        {
        }

        public PackageIdentifier(Guid id, VersionIdentifier version)
        {
            Id = id;
            Version = version;
        }

        public Guid Id { get; private set; }
        public VersionIdentifier Version { get; private set; }
    }
}