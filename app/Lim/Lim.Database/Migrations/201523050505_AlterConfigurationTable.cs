using FluentMigrator;

namespace Lim.Database.Migrations
{
    [Tags("Lim")]
    [Migration(201523050505)]
    public class AlterConfigurationTable : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Alter.Table("Configuration")
                .AddColumn("CustomFrequencyTime").AsTime().Nullable()
                .AddColumn("CustomFrequencyDay").AsString(10).Nullable();
        }
    }
}