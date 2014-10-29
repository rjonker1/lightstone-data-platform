using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IPackage : INamedEntity
    {
        IAction Action { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        IEnumerable<IWorkflow> Workflows { get; }
    }
}