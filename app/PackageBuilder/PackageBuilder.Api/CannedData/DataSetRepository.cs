using System;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class DataSetRepository : Repository<IDataSet>
    {
        public DataSetRepository()
        {
            Add(
                new DataSet("Vehicle verification dataSet") { DataFields = new[] { new DataField("Vehicle verification"), } },
                new DataSet("Repair history dataSet") { DataFields = new[] { new DataField("Repair history"), } },
                new DataSet("Values dataSet") { DataFields = new[] { new DataField("Values"), } },
                new DataSet("EzScore dataSet") { DataFields = new[] { new DataField("EzScore"), } },
                new DataSet("License plate lookup dataSet") { DataFields = new[] { new DataField("License plate number") { DataSource = new DataSource("Ivid") { Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A") } }, } }
                );
        }
    }
}