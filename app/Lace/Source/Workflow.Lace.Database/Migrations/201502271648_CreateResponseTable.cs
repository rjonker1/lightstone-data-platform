using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Migration(201502271648)]
    public class CreateResponseTable : Migration
    {
        public override void Up()
        {
            Create.Table("Responses")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("ResponseId").AsGuid().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Responses");
        }
    }
}