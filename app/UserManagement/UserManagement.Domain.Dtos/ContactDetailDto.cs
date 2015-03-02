using System;

namespace UserManagement.Domain.Dtos
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; } 
        public virtual string LegalEntityName { get; set; }
        public virtual string AccountsContactName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual AddressDto PhysicalAddress { get; set; }
        public virtual AddressDto PostalAddress { get; set; }
    }
}