using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Addresses
{
    public class CreateAddress : DomainCommand
    {
        public string AddressType;
        public string Line1;
        public string Line2;
        public string Suburb;
        public string City;
        public string Country;
        public string PostalCode;
        public Province Province;

        public CreateAddress(string addressType, string line1, string line2, string suburb, string city, string country, string postalCode, Province province)
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