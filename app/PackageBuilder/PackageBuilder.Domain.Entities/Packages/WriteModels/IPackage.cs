using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public interface IPackage : INamedEntity
    {
        Guid Id { get; }
        State State { get; }
        DateTime CreatedDate { get; }
        int Version { get; }
        decimal DisplayVersion { get; }
        string Industry { get; }
        string Description { get; }
        //IAction Action { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        //IEnumerable<IWorkflow> Workflows { get; }
    }
}