using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class RoleBuilder
    {
        public static IRole Get(string name)
        {
            return new Role(name);
        }
    }
}