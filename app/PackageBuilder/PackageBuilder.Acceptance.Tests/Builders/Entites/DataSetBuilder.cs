using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class DataSetBuilder
    {
        public static IDataSet Get(string name, params IDataField[] fields)
        {
            return new DataSet(name){ DataFields = fields};
        }
    }
}