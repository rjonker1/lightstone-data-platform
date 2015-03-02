using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractDuration : ValueEntity
    {
        protected ContractDuration() { }

        public ContractDuration(string val) : base(val)
        {
            Value = val;
        }
    }
}
