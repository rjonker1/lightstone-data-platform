using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class UserIdentifier
    {
        public UserIdentifier()
        {
        }

        public UserIdentifier(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        protected bool Equals(UserIdentifier other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserIdentifier) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}