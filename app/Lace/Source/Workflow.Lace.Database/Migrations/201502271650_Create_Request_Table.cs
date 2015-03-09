using FluentMigrator;

namespace Workflow.Billing.Database.Migrations
{
    [Migration(201502271650)]
    public class Create_Request_Table : Migration
    {
        public override void Up()
        {
            Create.Table("RequestHeader")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("RequestHeader");
        }
    }
}