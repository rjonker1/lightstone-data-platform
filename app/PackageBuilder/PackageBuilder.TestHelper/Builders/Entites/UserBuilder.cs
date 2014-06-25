using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class UserBuilder
    {
        public static IUser Get(string username)
        {
            return new User(username);
        }
    }
}