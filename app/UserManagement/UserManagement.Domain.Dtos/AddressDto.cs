using System;

namespace UserManagement.Domain.Dtos
{
    public class AddressDto : EntityDto
    {
        public Guid Id { get; set; } 
        public virtual string Type { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string City { get; set; }
        public virtual Guid CountryId { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Guid ProvinceId { get; set; }
    }
}