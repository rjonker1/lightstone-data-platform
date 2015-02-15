using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Province : NamedEntity
    {
        public virtual string Value { get; set; }

        protected Province() { }

        public Province(string val) : base(val)
        {
            Value = val;
        }
    }
}
