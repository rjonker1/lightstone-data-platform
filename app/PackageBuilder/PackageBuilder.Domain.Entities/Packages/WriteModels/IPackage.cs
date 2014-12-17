using System;
using System.Collections.Generic;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
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
        IEnumerable<Industry> Industries { get; }
        string Description { get; }
        string Owner { get; }
        double CostOfSale { get; }
        double RecommendedSalePrice { get; }
        IAction Action { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        //IEnumerable<IWorkflow> Workflows { get; }
    }
}