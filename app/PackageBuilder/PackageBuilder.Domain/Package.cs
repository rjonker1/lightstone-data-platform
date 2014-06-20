using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class Package : NamedEntity, IPackage
    {
        public Package(string name)
            : base(name)
        {
        }

        public IEnumerable<IDataSet> DataSets { get; set; }
        public IEnumerable<IWorkflow> Workflows { get; set; }
    }
}