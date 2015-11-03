using FluentMigrator;

namespace Workflow.Database.Migrations
{
    [Tags("Billing")]
    [Migration(201510132010)]
    public class Add_Billable_State_For_No_Records : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Create.Column("BillableForNoRecordState").OnTable("DataProviderTransaction").AsString(30).WithDefaultValue("Billable");
            Create.Column("BillableForNoRecordStateId").OnTable("DataProviderTransaction").AsInt16().WithDefaultValue(1);
        }
    }
}
