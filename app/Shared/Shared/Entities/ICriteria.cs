using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface ICriteria
    {
        IEnumerable<IDataField> Fields { get; set; }
    }
}