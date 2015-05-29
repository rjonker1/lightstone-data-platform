using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Client : NamedEntity
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
        public virtual ContactDetail ContactDetail { get; protected internal set; }
        public virtual ISet<Contract> Contracts { get; protected internal set; }
        public virtual ISet<ClientUser> ClientUsers { get; protected internal set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? TrialExpiration { get; set; }

        public Client() { }

        public Client(string clientName) : base(clientName)
        {
        }
    }
}
