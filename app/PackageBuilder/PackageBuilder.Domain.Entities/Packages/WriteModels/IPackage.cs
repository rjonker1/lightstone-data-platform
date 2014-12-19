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
        int Version { get; }
        string Description { get; }
        double CostOfSale { get; }
        double RecommendedSalePrice { get; }
        IAction Action { get; }
        string Notes { get; }
        IEnumerable<Industry> Industries { get; }
        State State { get; }
        decimal DisplayVersion { get; }
        string Owner { get; }
        DateTime CreatedDate { get; }
        DateTime? EditedDate { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        //IEnumerable<IWorkflow> Workflows { get; }
    }
}