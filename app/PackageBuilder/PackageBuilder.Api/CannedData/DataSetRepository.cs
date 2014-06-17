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
            Add
            (
                new DataSet("Vehicle verification dataSet") { DataFields = new[] { new DataField("Vehicle verification"), } },
                new DataSet("Repair history dataSet") { DataFields = new[] { new DataField("Repair history"), } },
                new DataSet("Values dataSet") { DataFields = new[] { new DataField("Values"), } },
                new DataSet("EzScore dataSet") { DataFields = new[] { new DataField("EzScore"), } },
                new DataSet("License plate lookup dataSet") 
                { 
                    DataFields = new[] 
                    { 
                        new DataField("License plate number")
                        {
                            DataSource = new DataSource("Ivid") { Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A") }
                        }, 
                        new DataField("Field 1")
                        {
                            DataSource = new DataSource("IvidTitleHolder") { Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B") }
                        }, 
                        new DataField("Field 2")
                        {
                            DataSource = new DataSource("RgtVin") { Id = new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D") }
                        }, 
                        new DataField("Field 3")
                        {
                            DataSource = new DataSource("Audatex") { Id = new Guid("18F5D1F8-0187-4EB2-A554-0F6E963F1E51") }
                        }, 
                    } 
                }
            );
        }
    }
}