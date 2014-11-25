using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public interface IDataField : INamedEntity
    {
        string Label { get; }
        string Definition { get; }
        IEnumerable<Industry> Industries { get; }
        double Price { get; }
        bool? IsSelected { get; }
        Type Type { get; }
        IEnumerable<IDataField> DataFields { get; }
    }
}