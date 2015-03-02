using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Role : ValueEntity
    {
        protected Role() { }

        public Role(string val) : base(val)
        {
            Value = val;
        }

        public virtual void UpdateValue(string value)
        {
            Value = value;
        }
    }
}
