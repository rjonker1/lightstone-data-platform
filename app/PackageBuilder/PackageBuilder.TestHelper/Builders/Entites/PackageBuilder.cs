using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class PackageBuilder
    {
        public static IPackage Get(string name, IAction action, params IDataSet[] dataSets)
        {
            return new Package(name) { Action = action, DataSets = dataSets };
        }
    }
}