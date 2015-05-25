using FluentMigrator;

namespace Lim.Database.Migrations
{
    [Tags("Lim")]
    [Migration(201522050950)]
    public class AlterPackageResponseTable : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Alter.Table("PackageResponses")
                .AddColumn("Username").AsString(100).NotNullable().WithDefaultValue("Not Supplied");
        }
    }
}
