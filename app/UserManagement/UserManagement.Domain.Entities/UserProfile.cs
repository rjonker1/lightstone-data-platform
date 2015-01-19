using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserProfile : Entity
    {

        public Guid UserId { get; set; }
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }

        public virtual User User { get; set; }

    }
}