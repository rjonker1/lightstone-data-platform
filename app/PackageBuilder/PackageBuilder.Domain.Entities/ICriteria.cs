using System.Collections.Generic;

namespace PackageBuilder.Domain.Entities
{
    public interface ICriteria
    {
        IEnumerable<IDataField> Fields { get; }
    }
}