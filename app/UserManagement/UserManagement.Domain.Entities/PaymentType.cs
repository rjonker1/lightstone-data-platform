using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class PaymentType : NamedEntity
    {
        public virtual string Value { get; set; }

        protected PaymentType() { }

        public PaymentType(string name) : base(name)
        {
            Value = name;
        }
    }
}
