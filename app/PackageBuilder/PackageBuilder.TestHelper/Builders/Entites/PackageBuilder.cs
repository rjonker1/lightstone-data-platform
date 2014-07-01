using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class PackageBuilder
    {
        private string _name;
        private IAction _action;
        private IDataSet[] _dataSets = Enumerable.Empty<IDataSet>().ToArray();
        public IPackage Build()
        {
            return new Package(_name) { Action = _action, DataSets = _dataSets };
        }

        public PackageBuilder With(string name)
        {
            _name = name;
            return this;
        }
        public PackageBuilder With(IAction action)
        {
            _action = action;
            return this;
        }

        public PackageBuilder With(params IDataSet[] dataSets)
        {
            _dataSets = dataSets;
            return this;
        }
    }
}