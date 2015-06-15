using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerUser : Entity
    {
        [Required]
        public virtual Customer Customer { get; protected internal set; }
        [Required]
        public virtual User User { get; protected internal set; }
        public virtual bool IsDefault { get; set; }

        protected CustomerUser()
        {
        }

        public CustomerUser(Customer customer, User user, bool isDefault)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            User = user;
            IsDefault = isDefault;
        }
    }
}