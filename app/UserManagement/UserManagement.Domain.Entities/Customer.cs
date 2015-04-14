using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : NamedEntity
    {
        public virtual string AccountOwnerName { get; protected internal set; }

        private CustomerAccountNumber _customerAccountNumber = new CustomerAccountNumber();
        public virtual CustomerAccountNumber CustomerAccountNumber
        {
            get
            {
                return _customerAccountNumber ?? (_customerAccountNumber = new CustomerAccountNumber());
            }
        }

        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        public virtual PlatformStatus PlatformStatus { get; protected internal set; }
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<CreateSource> CreateSources { get; protected internal set; }
        public virtual ISet<User> Users { get; protected internal set; }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual bool IsActive { get; set; }
    }
}
