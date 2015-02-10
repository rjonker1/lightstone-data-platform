using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Role : NamedEntity
    {
        public virtual string Value { get; protected internal set; }

        protected Role() { }

        public Role(string val) : base(val)
        {
            Value = val;
        }
    }
}
