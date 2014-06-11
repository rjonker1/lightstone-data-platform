using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class RequestIdentifier
    {
        public RequestIdentifier()
        {
        }

        public RequestIdentifier(Guid id, SystemIdentifier system)
        {
            Id = id;
            System = system;
        }

        public Guid Id { get; set; }
        public SystemIdentifier System { get; set; }

        protected bool Equals(RequestIdentifier other)
        {
            return Id.Equals(other.Id) && Equals(System, other.System);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RequestIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode()*397) ^ (System != null ? System.GetHashCode() : 0);
            }
        }
    }
}