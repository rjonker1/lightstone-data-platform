using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class UserRole : IUserRole
    {
        public UserRole(IUser user, IRole role)
        {
            Id = Guid.NewGuid();
            User = user;
            Role = role;
        }

        public Guid Id { get; private set; }

        public IUser User { get; set; }

        public IRole Role { get; set; }
    }
}