using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CommercialState : NamedEntity
    {
        public virtual string Value { get; protected internal set; }

        protected CommercialState() { }

        public CommercialState(string val) : base(val)
        {
            Value = val;
        }
    }
}
