using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Addresses
{
    public class CreateAddress : DomainCommand
    {

        public string AddressType;
        public string Line1;
        public string PostalCode;
        public string Line2;
        public string City;
        public string Country;

        public Province Province;

        public CreateAddress(string addressType, string line1, string postalCode, string line2, string city, string country, Province province)
        {
            Id = Guid.NewGuid();
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