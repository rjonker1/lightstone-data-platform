using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IAction : INamedEntity
    {
        ICriteria Criteria { get; set; }
    }

    public interface ICriteria
    {
        IEnumerable<IField> Fields { get; set; }
    }
}