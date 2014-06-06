﻿using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class Package : IPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataSet> DataSets { get; set; }
        public IEnumerable<IWorkflow> Workflows { get; set; }
    }
}