using System;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class CustomerAddress : Entity
    {
        public virtual Customer Customer { get; protected internal set; }
        public virtual Address Address { get; protected internal set; }
        public virtual AddressType AddressType { get; protected internal set; }

        protected CustomerAddress() { }

        public CustomerAddress(Customer customer, Address address, AddressType addressType, Guid id = new Guid()) : base(id)
        {
            Customer = customer;
            Address = address;
            AddressType = addressType;
        }
    }
}