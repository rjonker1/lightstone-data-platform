using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PaymentType : ValueEntity
    {
        protected PaymentType() { }

        public PaymentType(string value)
            : base(value)
        {
            Value = value;
        }
    }
}
