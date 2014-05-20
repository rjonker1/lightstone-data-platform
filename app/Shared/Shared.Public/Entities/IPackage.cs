using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IPackage : IEntity, INamedEntity
    {
        IEnumerable<IDataSet> DataSets { get; set; }
        IEnumerable<IWorkflow> Workflows { get; set; }
    }
}