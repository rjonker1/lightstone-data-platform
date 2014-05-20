using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class UserGroup : IUserGroup
    {
        public int Id { get; set; }
        public IUser User { get; set; }
        public IGroup Group { get; set; }
    }
}