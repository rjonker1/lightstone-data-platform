using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerUser : Entity
    {
        public virtual Customer Customer { get; protected internal set; }
        public virtual User User { get; protected internal set; }
        public virtual bool IsDefault { get; protected internal set; }

        protected CustomerUser() { }

        public CustomerUser(Customer customer, User user, bool isDefault)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            User = user;
            IsDefault = isDefault;
        }

        public virtual void SetDefault(bool @default)
        {
            IsDefault = @default;
        }
    }
}