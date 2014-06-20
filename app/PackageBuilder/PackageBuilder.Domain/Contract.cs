using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class Contract : NamedEntity, IContract
    {
        public Contract(string name)
            : base(name)
        {
        }

        public ICustomer Customer { get; set; }

        protected bool Equals(Contract other)
        {
            return Equals(Customer, other.Customer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Contract) obj);
        }

        public override int GetHashCode()
        {
            return (Customer != null ? Customer.GetHashCode() : 0);
        }
    }
}