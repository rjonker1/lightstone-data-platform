﻿using System;
using System.Collections.Generic;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.Actions;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Contracts.States.Read;

namespace PackageBuilder.Domain.Entities.Contracts.Packages.Write
{
    public interface IPackage : INamedEntity
    {
        Guid Id { get; }
        int Version { get; }
        string Description { get; }
        decimal CostOfSale { get; }
        decimal RecommendedSalePrice { get; }
        IAction Action { get; set; }
        string Notes { get; }
        IEnumerable<IIndustry> Industries { get; }
        IState State { get; }
        decimal DisplayVersion { get; }
        string Owner { get; }
        DateTime CreatedDate { get; }
        DateTime? EditedDate { get; }
        IEnumerable<IDataProvider> DataProviders { get; }
        //IEnumerable<IWorkflow> Workflows { get; }
    }
}