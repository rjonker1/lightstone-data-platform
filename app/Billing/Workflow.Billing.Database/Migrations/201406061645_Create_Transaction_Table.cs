using FluentMigrator;

namespace Workflow.Billing.Database.Migrations
{
    [Migration(201406061645)]
    public class Create_Transaction_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Transaction")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("PackageId").AsGuid().NotNullable()
                .WithColumn("PackageVersion").AsInt64().NotNullable()
                .WithColumn("ContractId").AsGuid().NotNullable()
                .WithColumn("ContractVersion").AsInt64().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable()
                .WithColumn("System").AsString().NotNullable()
                .WithColumn("Server").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Transaction");
        }
    }
}