using System;
using FluentMigrator;

namespace Monitoring.Database.Migrations
{
    [Tags("Monitoring")]
    [Migration(201504251525)]
    public class Create_Data_Provider_Event_Table : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderEventLog")
                .WithColumn("Id").AsGuid().NotNullable().Indexed()
                .WithColumn("CommitNumber").AsInt64().Identity().PrimaryKey("PK_DataProviderEventLog")
                .WithColumn("CommitSequence").AsInt32().NotNullable()
                .WithColumn("Dispatched").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("Payload").AsBinary(int.MaxValue)
                .WithColumn("CommitStamp").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("DataProvider").AsString(50)
                .WithColumn("DataProviderId").AsInt32()
                .WithColumn("CommandType").AsString(50)
                .WithColumn("CommandTypeId").AsInt32()
                .WithColumn("Type").AsString(500);

        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_DataProviderEventLog");
            Delete.Table("DataProviderEventLog");
        }
    }
}
