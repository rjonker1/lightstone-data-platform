using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IDataSet : INamedEntity
    {
        IEnumerable<IDataField> DataFields { get; }
    }
}