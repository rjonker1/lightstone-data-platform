using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class IndividualAddress : Entity
    {
        public virtual Individual Individual { get; protected internal set; }
        public virtual Address Address { get; protected internal set; }
        public virtual AddressType AddressType { get; protected internal set; }

        protected IndividualAddress() { }

        public IndividualAddress(Individual individual, Address address, AddressType addressType)
        {
            Individual = individual;
            Address = address;
            AddressType = addressType;
        }
    }
}