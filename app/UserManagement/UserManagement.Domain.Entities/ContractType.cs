using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractType : ValueEntity
    {
        protected ContractType() { }

        public ContractType(string val) : base(val)
        {
            Value = val;
        }
    }
}
