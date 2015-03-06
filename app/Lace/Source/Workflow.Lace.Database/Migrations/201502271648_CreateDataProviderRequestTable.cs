using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271648)]
    public class CreateDataProviderRequestTable : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderRequests")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("DataProvider").AsInt32().NotNullable()
                .WithColumn("DataProviderName").AsString().NotNullable()
                .WithColumn("ConnectionType").AsString().NotNullable()
                .WithColumn("Connection").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DataProviderRequests");
        }
    }
}