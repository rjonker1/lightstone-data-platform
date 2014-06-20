using System;
using System.Collections.Generic;

namespace DataPlatform.Shared.Dtos
{
    public class DataSet 
    {
        public IEnumerable<DataField> DataFields { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}