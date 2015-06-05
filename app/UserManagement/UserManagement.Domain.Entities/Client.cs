﻿using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Client : NamedEntity, IIndustry
    {
        public virtual string Notes { get; protected internal set; }
        private ClientAccountNumber _clientAccountNumber = new ClientAccountNumber();
        public virtual ClientAccountNumber ClientAccountNumber
        {
            get
            {
                return _clientAccountNumber ?? (_clientAccountNumber = new ClientAccountNumber());
            }
        }

        public virtual Billing Billing { get; protected internal set; }
        public virtual CommercialState CommercialState { get; protected internal set; }
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual ISet<ClientUser> ClientUsers { get; protected internal set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsLocked { get; set; }
        public virtual DateTime? TrialExpiration { get; set; }
		public virtual ISet<ClientIndustry> Industries { get; set; }
        public Client() { }

        public Client(string clientName) : base(clientName)
        {
        }
    }
}
