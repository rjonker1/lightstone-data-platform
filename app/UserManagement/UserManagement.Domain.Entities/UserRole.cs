using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserRole : Entity//, IUserRole
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        //public IUser User { get; set; }
        //public IRole Role { get; set; }

        //public UserRole(IUser user, IRole role)
        //{
        //    Id = new Guid();
        //    User = user;
        //    Role = role;
        //}
    }
}
