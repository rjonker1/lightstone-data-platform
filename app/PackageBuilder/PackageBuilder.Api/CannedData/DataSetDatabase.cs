using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class DataSetDatabase : Repository<IDataSet>
    {
        public DataSetDatabase()
        {
            Add(
                new DataSet("Vehicle verification dataSet") { DataFields = new[] { new DataField("Vehicle verification"), } },
                new DataSet("Repair history dataSet") { DataFields = new[] { new DataField("Repair history"), } },
                new DataSet("Values dataSet") { DataFields = new[] { new DataField("Values"), } },
                new DataSet("Driver's license scan dataSet") { DataFields = new[] { new DataField("Driver's license scan"), } },
                new DataSet("EzScore dataSet") { DataFields = new[] { new DataField("EzScore"), } },
                new DataSet("License plate lookup dataSet") { DataFields = new[] { new DataField("License plate number"), } }
                );
        }
    }
}