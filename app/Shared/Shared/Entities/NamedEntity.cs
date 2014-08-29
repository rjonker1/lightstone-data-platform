using System;

namespace DataPlatform.Shared.Entities
{
    public class NamedEntity : INamedEntity
    {
        protected NamedEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; private set; }
        public Guid Id { get; private set; }

        protected bool Equals(NamedEntity other)
        {
            return string.Equals(Name, other.Name);
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
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
