using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class UserBuilder
    {
        public static IUser Get(string username)
        {
            return new User(username);
        }
    }
}