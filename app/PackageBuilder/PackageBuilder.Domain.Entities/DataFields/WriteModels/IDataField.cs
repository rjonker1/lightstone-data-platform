using System;
using System.Collections.Generic;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public interface IDataField : INamedEntity
    {
        string Label { get; }
        string Definition { get; }
        string Industry { get; }
        double Price { get; }
        bool? IsSelected { get; }
        Type Type { get; }
        IEnumerable<IDataField> DataFields { get; }
    }
}