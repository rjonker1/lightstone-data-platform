using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class GroupBuilder
    {
        private string _name;
        public IGroup Build()
        {
            return new Group(_name);
        }

        public GroupBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}