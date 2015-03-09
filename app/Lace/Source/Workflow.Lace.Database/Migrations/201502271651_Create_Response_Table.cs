using FluentMigrator;

namespace Workflow.Billing.Database.Migrations
{
    [Migration(201502271651)]
    public class Create_Response_Table : Migration
    {
        public override void Up()
        {
            Create.Table("ResponseHeader")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("ResponseHeader");
        }
    }
}