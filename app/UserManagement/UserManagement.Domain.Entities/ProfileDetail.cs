using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ProfileDetail : Entity
    {

        public virtual string LegalEntityName { get; set; }
        public virtual string AccountsContactName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Guid? PhysicalAddressId { get; set; }
        public virtual Guid? PostalAddressId { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual string VATNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        public ProfileDetail()
        {
            Client = new HashSet<Client>();
            Contract = new HashSet<Contract>();
            CustomerProfile = new HashSet<CustomerProfile>();
        }
    }
}