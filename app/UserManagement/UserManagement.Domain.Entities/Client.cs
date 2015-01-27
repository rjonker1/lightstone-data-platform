using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public  class Client : Entity
    {

        public virtual string ClientName { get; set; }
        //public virtual Guid? ClientProfileId { get; set; }

        //public virtual ProfileDetail ProfileDetail { get; set; }

        //public virtual IEnumerable<ClientUser> ClientUsers { get; protected internal set; }

        protected Client() { }

        public Client(Guid id, string clientName) : base(id)
        {
            ClientName = clientName;
            //ClientUsers = new Collection<ClientUser>();
        }
    }
}
