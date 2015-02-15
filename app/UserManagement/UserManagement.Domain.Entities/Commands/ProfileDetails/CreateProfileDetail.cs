using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.ProfileDetails
{
    public class CreateProfileDetail : DomainCommand
    {
        public string LegalEntityName;
        public string AccountsContactName;
        public string EmailAddress;
        public string TelephoneNumber;
        public Address Address;
        public Address Address1;

        public CreateProfileDetail(string legalEntityName, string accountsContactName, string emailAddress, string telephoneNumber, Address address, Address address1)
        {
            Id = Guid.NewGuid();
            LegalEntityName = legalEntityName;
            AccountsContactName = accountsContactName;
            EmailAddress = emailAddress;
            TelephoneNumber = telephoneNumber;
            Address = address;
            Address1 = address1;
        }
    }
}