using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class Package : IPackage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataSet> DataSets { get; set; }
        public IEnumerable<IWorkflow> Workflows { get; set; }
    }
}
