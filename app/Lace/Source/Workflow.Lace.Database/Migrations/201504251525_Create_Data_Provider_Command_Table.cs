using System;
using FluentMigrator;

namespace Workflow.Lace.Database.Migrations
{
    [Tags("DataProvider")]
    [Migration(201504251525)]
    public class Create_Data_Provider_Command_Table : Migration
    {
        public override void Up()
        {
            Create.Table("CommandLog")
                .WithColumn("Id").AsGuid().NotNullable().Indexed()
                .WithColumn("CommitNumber").AsInt64().Identity().PrimaryKey()
                .WithColumn("CommitSequence").AsInt32().NotNullable()
                .WithColumn("Dispatched").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("Payload").AsBinary(Int32.MaxValue)
                .WithColumn("CommitStamp").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("DataProvider").AsString(50)
                .WithColumn("DataProviderId").AsInt32()
                .WithColumn("CommandType").AsString(50)
                .WithColumn("CommandTypeId").AsInt32()
                .WithColumn("Type").AsString(500);

        }

        public override void Down()
        {
            Delete.Table("CommandLog");
        }
    }
}