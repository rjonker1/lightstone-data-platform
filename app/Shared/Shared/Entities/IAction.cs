using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IAction : INamedEntity
    {
        ICriteria Criteria { get; set; }
    }

    public interface ICriteria
    {
        IEnumerable<IDataField> Fields { get; set; }
    }
}