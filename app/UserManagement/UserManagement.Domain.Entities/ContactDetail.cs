using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class ContactDetail : Entity
    {
        public virtual string ContactPerson { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Address PhysicalAddress { get; set; }
        public virtual Address PostalAddress { get; set; }

        protected internal ContactDetail() { }

        public ContactDetail(string contactPerson, string contactNumber, string emailAddress, Address physicalAddress, Address postalAddress, Guid id = new Guid())
            : base(id)
        {
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            PhysicalAddress = physicalAddress;
            PostalAddress = postalAddress;
        }
    }
}