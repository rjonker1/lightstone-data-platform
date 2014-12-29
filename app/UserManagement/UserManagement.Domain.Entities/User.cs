using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class User : Entity
    {

        public virtual Guid Id { get; protected internal set; }
        public virtual DateTime FirstCreateDate { get; protected internal set; }
        public virtual string LastUpdatedBy { get; protected internal set; }
        public virtual DateTime LastUpdatedDate { get; protected internal set; }
        public virtual string Password { get; protected internal set; }

        public User()
        {
        }

    }
}
