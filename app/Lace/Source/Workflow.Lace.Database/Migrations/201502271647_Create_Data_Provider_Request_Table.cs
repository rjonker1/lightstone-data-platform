using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271647)]
    public class Create_Data_Provider_Request_Table : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderRequests")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("StreamId").AsGuid().NotNullable()
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