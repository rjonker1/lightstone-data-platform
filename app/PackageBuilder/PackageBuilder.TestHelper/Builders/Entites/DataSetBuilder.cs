using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataSetBuilder
    {
        public static IDataSet Get(string name, params IDataField[] fields)
        {
            return new DataSet(name){ DataFields = fields};
        }
    }
}