using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {
        public virtual string Line1 { get; protected internal set; }
        public virtual string Line2 { get; protected internal set; }
        public virtual string Suburb { get; protected internal set; }
        public virtual string City { get; protected internal set; }
        public virtual Country Country { get; protected internal set; }
        public virtual string PostalCode { get; protected internal set; }
        public virtual Province Province { get; protected internal set; }

        protected Address() { }

        public Address(string line1, string line2, string suburb, string city, Country country, string postalCode, Province province, Guid id = new Guid())
            : base(id)
        {
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