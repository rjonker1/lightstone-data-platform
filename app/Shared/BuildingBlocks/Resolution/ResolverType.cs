using System;

namespace Shared.Resolution
{
    public class ResolverType
    {
        public ResolverType(Type type)
        {
            Type = type;
        }

        public Type Type { get; private set; }

        protected bool Equals(ResolverType other)
        {
            return Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResolverType) obj);
        }

        public override int GetHashCode()
        {
            return (Type != null ? Type.GetHashCode() : 0);
        }
    }
}