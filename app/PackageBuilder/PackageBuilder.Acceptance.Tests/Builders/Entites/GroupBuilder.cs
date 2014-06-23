using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class GroupBuilder
    {
        public static IGroup Get(string name)
        {
            return new Group(name);
        }
    }
}