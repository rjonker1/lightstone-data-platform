using FluentMigrator;

namespace Workflow.Database.Migrations
{
   
    [Tags("Billing")]
    [Migration(201511301615)]
    public class Add_Reference_Number : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Create.Column("ReferenceNumber").OnTable("DataProviderTransaction").AsString(200).Nullable();
        }
    }
}
