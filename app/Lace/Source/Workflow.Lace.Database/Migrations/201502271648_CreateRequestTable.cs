using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271648)]
    public class CreateRequestTable : Migration
    {
        public override void Up()
        {
            Create.Table("Requests")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Requests");
        }
    }
}