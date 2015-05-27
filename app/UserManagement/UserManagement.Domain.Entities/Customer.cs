using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Customer : NamedEntity
    {
        public virtual User AccountOwner { get; protected internal set; }
        public virtual string Notes { get; protected internal set; }

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
        [DoNotMap] // Calculated read only property, if needed for MI reporting a specific query should be created
        public virtual PlatformStatus PlatformStatus
        {
            get
            {
                var activated = Contracts != null && (Contracts.Any() && Contracts.SelectMany(x => x.Packages).Any());
                var platformStatusType = activated ? PlatformStatusType.Activated : PlatformStatusType.Incomplete;
                if (IsLocked) platformStatusType = PlatformStatusType.Locked;
                return ServiceLocator.Current.GetInstance<IRepository<PlatformStatus>>().FirstOrDefault(x => x.PlatformStatusType == platformStatusType);
            }
        }

        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual CreateSource CreateSource { get; set; }
        public virtual ISet<User> Users { get; protected internal set; }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual bool IsLocked { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
