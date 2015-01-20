using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserLinkedToCustomer : Entity
    {
        public virtual Guid CustomerId { get; set; }
        public virtual Guid UserId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}
