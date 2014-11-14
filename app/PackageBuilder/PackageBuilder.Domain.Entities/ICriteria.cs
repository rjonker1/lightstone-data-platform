using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Domain.Entities
{
    public interface ICriteria
    {
        IEnumerable<IDataField> Fields { get; }
    }
}