using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.Contracts
{
    public interface ICriteria
    {
        IEnumerable<IDataField> Fields { get; }
    }
}