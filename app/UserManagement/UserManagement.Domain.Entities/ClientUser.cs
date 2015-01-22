using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientUser : Entity
    {
        public virtual string Alias { get; set; }

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}