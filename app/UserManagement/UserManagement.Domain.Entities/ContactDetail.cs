using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContactDetail : Entity
    {
        public virtual string LegalEntityName { get; set; }
        public virtual string AccountsContactName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual Address PhysicalAddress { get; set; }
        public virtual Address PostalAddress { get; set; }

        protected internal ContactDetail() { }

        public ContactDetail(string legalEntityName, string accountsContactName, string emailAddress, string telephoneNumber, Address physicalAddress, Address postalAddress, Guid id = new Guid()) : base(id)
        {
            LegalEntityName = legalEntityName;
            AccountsContactName = accountsContactName;
            EmailAddress = emailAddress;
            TelephoneNumber = telephoneNumber;
            PhysicalAddress = physicalAddress;
            PostalAddress = postalAddress;
        }
    }
}