using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
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