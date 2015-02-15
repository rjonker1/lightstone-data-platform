﻿using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public virtual string CustomerName { get; protected internal set; }
        public virtual string AccountOwnerName { get; protected internal set; }
        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        public virtual CreateSource CreateSource { get; protected internal set; }
        public virtual PlatformStatus PlatformStatus { get; protected internal set; }
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<User> Users { get; protected internal set; }

        protected Customer() { }

        public Customer(string customerName, string accountOwnerName, CommercialState commercialState, 
            CreateSource createSource, PlatformStatus platformStatus, Guid id = new Guid())
            : base(id)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
        }

        public Customer(string customerName, string accountOwnerName, CommercialState commercialState,
            CreateSource createSource, PlatformStatus platformStatus, Billing billing = null, Guid id = new Guid())
            : base(id)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
            Billing = billing;
        }

        public virtual void UpdateCustomer(string customerName, string accountOwnerName, CommercialState commercialState,
            CreateSource createSource, PlatformStatus platformStatus)
        {
            CustomerName = customerName;
            AccountOwnerName = accountOwnerName;
            CommercialState = commercialState;
            CreateSource = createSource;
            PlatformStatus = platformStatus;
        }
    }
}
