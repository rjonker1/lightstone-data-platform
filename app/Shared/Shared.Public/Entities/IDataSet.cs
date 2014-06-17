using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IDataSet : INamedEntity
    {
        IEnumerable<IDataField> DataFields { get; set; }
    }
}