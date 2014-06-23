using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class UserGroup : IUserGroup
    {
        public UserGroup(IUser user, IGroup @group)
        {
            Id = Guid.NewGuid();
            User = user;
            Group = @group;
        }

        public Guid Id { get; private set; }
        public IUser User { get; set; }
        public IGroup Group { get; set; }
    }
}