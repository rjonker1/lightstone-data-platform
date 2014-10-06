using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class Criteria : ICriteria
    {
        public Criteria()
        {
            Fields = Enumerable.Empty<IDataField>();
        }

        public Criteria(IEnumerable<IDataField> fields)
        {
            Fields = fields;
        }

        public IEnumerable<IDataField> Fields { get; set; }
    }
}