using System;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class ClientAddress : Entity
    {
        public virtual Client Client { get; protected internal set; }
        public virtual Address Address { get; protected internal set; }
        public virtual AddressType AddressType { get; protected internal set; }

        protected ClientAddress() { }

        public ClientAddress(Client client, Address address, AddressType addressType, Guid id = new Guid()) : base(id)
        {
            Client = client;
            Address = address;
            AddressType = addressType;
        }
    }
}