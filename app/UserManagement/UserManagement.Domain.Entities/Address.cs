using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {

        public virtual string AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }

        public virtual Province Province { get; set; }

        protected Address() { }

        public Address(Guid id, string addressType, string line1, string line2, string postalCode, string city, string country, Province province)
            : base(id)
        {

            AddressType = addressType;
            Line1 = line1;
            PostalCode = postalCode;
            Line2 = line2;
            City = city;
            Country = country;
            Province = province;
        }
    }
}