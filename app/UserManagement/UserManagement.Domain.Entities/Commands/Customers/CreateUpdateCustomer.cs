using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Customers
{
    public class CreateUpdateCustomer : DomainCommand
    {
        public Guid Id;
        public string CustomerName;
        public string AccountOwnerName;
        public CommercialState CommercialState;
        public CreateSource CreateSource;
        public PlatformStatus PlatformStatus;
        //public virtual CustomerProfile CustomerProfile { get; set; }
        //public virtual IList<User> Users { get; set; }

        public CreateUpdateCustomer(string customerName, string accountOwnerName, CommercialState commercialState,
            CreateSource createSource, PlatformStatus platformStatus
            //CustomerProfile customerProfile, IList<User> users
            )
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
            //CustomerProfile = customerProfile;
            //Users = users;
        }
        public CreateUpdateCustomer(Guid id, string customerName, string accountOwnerName, CommercialState commercialState,
            CreateSource createSource, PlatformStatus platformStatus
            //CustomerProfile customerProfile, IList<User> users
            )
        {
            Id = id;
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
            //CustomerProfile = customerProfile;
            //Users = users;
        }

    }
}