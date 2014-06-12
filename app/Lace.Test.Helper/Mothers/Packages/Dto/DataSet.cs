using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class DataSet : IDataSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataField> DataFields { get; set; }
    }
}
