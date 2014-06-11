using System;

namespace DataPlatform.Shared.Public.Entities
{
    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }

    public class NamedEntity : INamedEntity
    {
        protected NamedEntity(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }

        protected bool Equals(NamedEntity other)
        {
            return string.Equals(Name, other.Name) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NamedEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Id.GetHashCode();
            }
        }
    }
}
