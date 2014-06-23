using System;
using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos
{
    public class Package 
    {
        public Action Action { get; set; }
        public IEnumerable<DataSet> DataSets { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}