using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; } 
        public virtual string LegalEntityName { get; set; }
        public virtual string AccountsContactName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual Address PhysicalAddress { get; set; }
        public virtual Address PostalAddress { get; set; }
    }
}