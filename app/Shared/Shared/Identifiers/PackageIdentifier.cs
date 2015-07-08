using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
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

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public VersionIdentifier Version { get; set; }
        [DataMember]
        public double PackageCostPrice { get; set; }
        [DataMember]
        public double PackageRecommendedPrice { get; set; }

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