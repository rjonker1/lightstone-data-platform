using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IPackage : INamedEntity
    {
        IAction Action { get; set; }
        IEnumerable<IDataSet> DataSets { get; set; }
        IEnumerable<IWorkflow> Workflows { get; set; }
    }
}