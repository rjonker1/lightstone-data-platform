using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class UserRole : IUserRole
    {
        public Guid Id { get; set; }

        public IUser User { get; set; }

        public IRole Role { get; set; }
    }
}