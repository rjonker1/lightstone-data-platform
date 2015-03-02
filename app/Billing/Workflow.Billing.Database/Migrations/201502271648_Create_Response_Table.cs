using FluentMigrator;

namespace Workflow.Billing.Database.Migrations
{
    [Migration(201502271648)]
    public class Create_Response_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Response")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("PackageId").AsGuid().NotNullable()
                .WithColumn("PackageVersion").AsInt64().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("System").AsString().NotNullable()
                .WithColumn("Server").AsString().NotNullable()
                ;
        }

        public override void Down()
        {
            Delete.Table("Response");
        }
    }
}