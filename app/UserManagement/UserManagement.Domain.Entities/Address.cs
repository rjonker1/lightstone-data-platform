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
        public virtual string PostalCode { get; protected internal set; }
        public virtual Province Province { get; protected internal set; }
        public virtual Country Country { get; protected internal set; }
        //public virtual ISet<Customer> CustomerAddresses { get; protected internal set; }
        //public virtual ISet<Client> ClientAddresses { get; protected internal set; }
        //public virtual ISet<Individual> IndividualAddresses { get; protected internal set; }

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

        //public virtual bool IsLinkedToMultipleEntities()
        //{
        //    return CustomerAddresses != null && CustomerAddresses.Any()
        //        && ClientAddresses != null && ClientAddresses.Any()
        //        && IndividualAddresses != null && IndividualAddresses.Any();
        //}

        public override bool Equals(object obj)
        {
            var address = obj as Address;
            if (address == null) return false;

            var line1Equal = (Line1 + "").Trim().ToLower() == (address.Line1 + "").Trim().ToLower();
            var line2Equal = (Line2 + "").Trim().ToLower() == (address.Line2 + "").Trim().ToLower();
            var suburbEqual = (Suburb + "").Trim().ToLower() == (address.Suburb + "").Trim().ToLower();
            var cityEqual = (City + "").Trim().ToLower() == (address.City + "").Trim().ToLower();
            var postalCodeEqual = (PostalCode + "").Trim().ToLower() == (address.PostalCode + "").Trim().ToLower();
            var provinceEqual = address.Province != null && (Province != null && (Province.Value + "").Trim().ToLower() == (address.Province.Value + "").Trim().ToLower());
            var countryEqual = address.Country != null && (Country != null && (Country.Value + "").Trim().ToLower() == (address.Country.Value + "").Trim().ToLower());

            return line1Equal && line2Equal && suburbEqual && cityEqual && postalCodeEqual && provinceEqual && countryEqual;
        }
    }
}