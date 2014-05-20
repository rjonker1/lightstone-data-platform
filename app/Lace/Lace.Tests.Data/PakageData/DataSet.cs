using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class DataSet : IDataSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataField> DataFields { get; set; }
    }
}
