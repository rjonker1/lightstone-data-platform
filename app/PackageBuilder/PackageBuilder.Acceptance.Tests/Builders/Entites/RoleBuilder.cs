using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class RoleBuilder
    {
        public static IRole Get(string name)
        {
            return new Role(name);
        }
    }
}