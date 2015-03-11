using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271649)]
    public class Create_Data_Provider_Response_Table : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderResponses")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("StreamId").AsGuid().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("DataProvider").AsInt32().NotNullable()
                .WithColumn("DataProviderName").AsString().NotNullable()
                .WithColumn("DataProviderRequestId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DataProviderResponses");
        }
    }
}