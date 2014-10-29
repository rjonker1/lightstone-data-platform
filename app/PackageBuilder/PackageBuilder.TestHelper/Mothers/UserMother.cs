using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class UserMother
    {
        public static IUser AdminUser
        {
            get
            {
                return new UserBuilder().With("admin").Build();
            }
        }

        public static IUser TestUser
        {
            get
            {
                return new UserBuilder().With("TestUser").Build();
            }
        } 
    }
}