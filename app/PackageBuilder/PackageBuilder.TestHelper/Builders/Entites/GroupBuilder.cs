using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class GroupBuilder
    {
        public static IGroup Get(string name)
        {
            return new Group(name);
        }
    }
}