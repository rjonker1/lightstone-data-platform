using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class DataSet : NamedEntity, IDataSet
    {
        public DataSet(string name)
            : base(name)
        {
        }

        public IEnumerable<IDataField> DataFields { get; set; }
    }
}