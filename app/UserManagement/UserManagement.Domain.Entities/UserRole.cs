using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    //NHibernate will handle the creation of the M-2-M entities
    public class UserRole// : Entity//, IUserRole
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
