using System.Collections.Generic;

namespace DataPlatform.Shared.Entities
{
    public interface IPackage : INamedEntity
    {
        IAction Action { get; }
        IEnumerable<IDataSet> DataSets { get; }
        IEnumerable<IWorkflow> Workflows { get; }
    }
}