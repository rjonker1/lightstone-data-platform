using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.TestHelper.Helpers.Extensions
{
    public static class DataFieldExtensions
    {
        public static IDataField Get(this IEnumerable<IDataField> dataFields, string name)
        {
            return dataFields.FirstOrDefault(x => x.Name == name);
        }
    }
}