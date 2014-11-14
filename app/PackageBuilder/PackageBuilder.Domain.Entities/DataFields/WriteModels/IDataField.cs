using System;
using System.Collections.Generic;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public interface IDataField : INamedEntity
    {
        Type Type { get; }
        IEnumerable<IDataField> DataFields { get; }
        string Industry { get; }
        bool? IsSelected { get; }
    }
}