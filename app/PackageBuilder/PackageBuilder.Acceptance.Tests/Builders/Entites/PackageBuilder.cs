using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class PackageBuilder
    {
        public static IPackage Get(string name, IAction action, params IDataSet[] dataSets)
        {
            return new Package(name) { Action = action, DataSets = dataSets };
        }
    }
}