using System;

namespace PackageBuilder.Core.Entities
{
    public class NamedEntity : INamedEntity, IEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        protected NamedEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

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
