using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class DataSetDatabase : CannedDatabase<IDataSet>
    {
        public DataSetDatabase()
        {
            Add(
                new DataSet("Vehicle verification DataSet") { DataFields = new[] { new DataField("Vehicle verification"), } },
                new DataSet("Repair history DataSet") { DataFields = new[] { new DataField("Repair history"), } },
                new DataSet("Values DataSet") { DataFields = new[] { new DataField("Values"), } },
                new DataSet("Driver's license scan DataSet") { DataFields = new[] { new DataField("Driver's license scan"), } },
                new DataSet("EzScore DataSet") { DataFields = new[] { new DataField("EzScore"), } },
                new DataSet("License plate lookup DataSet") { DataFields = new[] { new DataField("License plate number"), } }
                );
        }
    }
}