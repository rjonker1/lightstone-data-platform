using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractType : NamedEntity
    {
        public virtual string Value { get; protected internal set; }

        protected ContractType() { }

        public ContractType(string val) : base(val)
        {
            Value = val;
        }
    }
}
