using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class EscalationType : ValueEntity
    {
        protected EscalationType() { }

        public EscalationType(string val) : base(val)
        {
            Value = val;
        }
    }
}
