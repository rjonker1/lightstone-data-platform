using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserRole// : Entity//, IUserRole
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
