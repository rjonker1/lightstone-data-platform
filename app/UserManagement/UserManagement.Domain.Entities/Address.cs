using System;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {
        public virtual AddressType Type { get; set; } 
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string City { get; set; }
        public virtual Country Country { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Province Province { get; set; }

        protected Address() { }

        public Address(AddressType type, string line1, string line2, string suburb, string city, Country country, string postalCode, Province province, Guid id = new Guid())
            : base(id)
        {
            Type = type;
            Line1 = line1;
            Line2 = line2;
            Suburb = suburb;
            City = city;
            Country = country;
            PostalCode = postalCode;
            Province = province;
        }
    }
}