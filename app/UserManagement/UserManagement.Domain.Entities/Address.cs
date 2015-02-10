using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {
        public virtual string AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Province Province { get; set; }

        protected Address() { }

        public Address(string addressType, string line1, string line2, string suburb, string city, string country, string postalCode, Province province, Guid id = new Guid()) : base(id)
        {
            AddressType = addressType;
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