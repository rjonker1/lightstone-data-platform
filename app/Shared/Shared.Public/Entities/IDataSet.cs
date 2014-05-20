using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IDataSet : IEntity, INamedEntity
    {
        IEnumerable<IDataField> DataFields { get; set; }
    }
}