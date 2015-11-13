using FluentMigrator;

namespace Monitoring.Database.Migrations
{
    [Migration(201504151135)]
    public class Create_Data_Provider_Monitoring_Table : Migration
    {
        public override void Down()
        {
            Delete.Table("DataProviderMonitoring");
        }

        public override void Up()
        {
            Create.Table("DataProviderMonitoring")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("RequestId").AsGuid().Indexed().NotNullable()
                .WithColumn("PackageName").AsString().NotNullable()
                .WithColumn("PackageVersion").AsInt64().NotNullable().WithDefaultValue(0)
                .WithColumn("ElapsedTime").AsString().NotNullable()
                .WithColumn("DataProviderCount").AsInt32().WithDefaultValue(0)
                .WithColumn("Action").AsString().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable();
        }
    }
}
