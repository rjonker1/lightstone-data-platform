using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271652)]
    public class Create_Data_Provider_Transaction_Table : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderTransaction")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("StreamId").AsGuid().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("DataProvider").AsInt32().NotNullable()
                .WithColumn("DataProviderName").AsString().NotNullable()
                .WithColumn("ConnectionType").AsString().NotNullable()
                .WithColumn("Connection").AsString().NotNullable()
                .WithColumn("Action").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("StateId").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DataProviderTransaction");
        }
    }
}