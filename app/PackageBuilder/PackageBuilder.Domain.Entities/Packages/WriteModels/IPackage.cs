using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public interface IPackage : INamedEntity
    {
        IAction Action { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        IEnumerable<IWorkflow> Workflows { get; }
    }
}