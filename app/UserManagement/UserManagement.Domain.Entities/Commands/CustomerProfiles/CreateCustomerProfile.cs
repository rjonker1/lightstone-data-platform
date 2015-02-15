using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.CustomerProfiles
{
    public class CreateCustomerProfile : DomainCommand
    {

        public DateTime FirstCreateDate;
        public string LastUpdateBy;
        public DateTime LastUpdateDate;
        public string PastelID;

        public Billing Billing;
        public CommercialState CommercialState;
        public CreateSource CreateSource;
        public Customer Customer;
        public PlatformStatus PlatformStatus;
        public ContactDetail ContactDetail;

        public CreateCustomerProfile(string pastelId, DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, CommercialState commercialState, Billing billing, 
                                        CreateSource createSource, Customer customer, PlatformStatus platformStatus/*, ProfileDetail profileDetail*/)
        {
            Id = Guid.NewGuid();
            PastelID = pastelId;
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            CommercialState = commercialState;
            Billing = billing;
            CreateSource = createSource;
            Customer = customer;
            PlatformStatus = platformStatus;
            //ProfileDetail = profileDetail;
        }
    }
}