using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CreateSource : NamedEntity
    {
        public virtual string Value { get; set; }

        protected CreateSource() { }

        public CreateSource(string val) : base(val)
        {
            Value = val;
        }
    }
}
