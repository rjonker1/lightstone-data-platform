using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserRole : Entity//, IUserRole
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
