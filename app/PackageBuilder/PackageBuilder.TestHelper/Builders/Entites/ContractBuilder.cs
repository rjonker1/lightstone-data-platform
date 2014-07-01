using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ContractBuilder
    {
        private string _name = "";

        public IContract Build()
        {
            return new Contract(_name);
        }

        public ContractBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}