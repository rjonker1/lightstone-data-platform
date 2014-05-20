using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class UserRole : IUserRole
    {
        public int Id { get; set; }

        public IUser User { get; set; }

        public IRole Role { get; set; }
    }
}