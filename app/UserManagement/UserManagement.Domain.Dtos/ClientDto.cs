using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; } 
        public string ClientName { get; set; }
        public ContactDetailDto ContactDetailDto { get; set; } 
    }

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

    public class AddressDto
    {
        public Guid Id { get; set; } 
        public virtual string AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Guid ProvinceId { get; set; }
    }
}