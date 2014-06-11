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

        public Guid Id { get; set; }
        public VersionIdentifier Version { get; set; }

        protected bool Equals(PackageIdentifier other)
        {
            return Id.Equals(other.Id) && Equals(Version, other.Version);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PackageIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode()*397) ^ (Version != null ? Version.GetHashCode() : 0);
            }
        }
    }
}