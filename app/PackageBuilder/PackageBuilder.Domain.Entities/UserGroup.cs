using System;

namespace PackageBuilder.Domain.Entities
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