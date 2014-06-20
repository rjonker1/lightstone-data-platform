using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IPackage : INamedEntity
    {
        IEnumerable<IDataSet> DataSets { get; set; }
        IEnumerable<IWorkflow> Workflows { get; set; }
    }
}