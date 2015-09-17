using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class ContactDetail : Entity
    {
        public virtual string ContactPerson { get; protected internal set; }
        public virtual string ContactNumber { get; protected internal set; }
        public virtual string EmailAddress { get; protected internal set; }
        public virtual ContactNumberType ContactNumberType { get; protected internal set; }
        public virtual Address PhysicalAddress { get; protected internal set; }
        public virtual Address PostalAddress { get; protected internal set; }

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