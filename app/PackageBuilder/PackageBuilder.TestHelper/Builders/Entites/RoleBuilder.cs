using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class RoleBuilder
    {
        private string _name;
        public IRole Build()
        {
            return new Role(_name);
        }

        public RoleBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}