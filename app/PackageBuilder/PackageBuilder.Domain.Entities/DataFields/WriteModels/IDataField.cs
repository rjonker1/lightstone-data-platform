﻿using System;
using System.Collections.Generic;
using PackageBuilder.Core.Entities;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public interface IDataField : INamedEntity
    {
        string Namespace { get; set; }
        string Label { get; }
        string Definition { get; }
        IEnumerable<Industry> Industries { get; }
        double CostOfSale { get; }
        bool? IsSelected { get; }
        int Order { get; }
        Type Type { get; }
        IEnumerable<IDataField> DataFields { get; }
        void OverrideValuesFromPackage(double costPrice, bool? selected);
    }
}