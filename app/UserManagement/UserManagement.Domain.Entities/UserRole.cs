using System;

namespace UserManagement.Domain.Entities
{
    public class UserRole : IUserRole
    {

        public Guid Id { get; protected internal set; }
        public IUser User { get; set; }
        public IRole Role { get; set; } 

        public UserRole(IUser user, IRole role)
        {
            Id = new Guid();
            User = user;
            Role = role;
        }

    }
}
