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
        public virtual string TelephoneNumber { get; set; }
        public virtual string VATNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        //public virtual ICollection<Client> Client { get; set; }
        //public virtual ICollection<Contract> Contract { get; set; }
        //public virtual ICollection<CustomerProfile> CustomerProfile { get; set; }

        protected ProfileDetail() { }

        public ProfileDetail(Guid id, string legalEntityName, string accountsContactName, string emailAddress, string telephoneNumber, string vatNumber, Address address, Address address1)
            : base(id)
        {

            LegalEntityName = legalEntityName;
            AccountsContactName = accountsContactName;
            EmailAddress = emailAddress;
            TelephoneNumber = telephoneNumber;
            VATNumber = vatNumber;
            Address = address;
            Address1 = address1;
        }
    }
}