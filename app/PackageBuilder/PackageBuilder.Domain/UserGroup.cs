using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class UserGroup : IUserGroup
    {
        public Guid Id { get; set; }
        public IUser User { get; set; }
        public IGroup Group { get; set; }
    }
}