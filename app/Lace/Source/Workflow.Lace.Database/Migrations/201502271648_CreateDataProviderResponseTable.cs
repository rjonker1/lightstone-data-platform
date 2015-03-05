using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271648)]
    public class CreateDataProviderResponseTable : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderResponses")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("DataProvider").AsInt32().NotNullable()
                .WithColumn("DataProviderName").AsString().NotNullable()
                .WithColumn("DataProviderRequestId").AsGuid().NotNullable()
                .WithColumn("DataProviderResponseId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DataProviderResponses");
        }
    }
}