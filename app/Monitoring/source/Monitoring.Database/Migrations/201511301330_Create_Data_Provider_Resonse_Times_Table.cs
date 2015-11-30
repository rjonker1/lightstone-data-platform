using FluentMigrator;

namespace Monitoring.Database.Migrations
{
    [Tags("Monitoring")]
    [Migration(201511301330)]
    internal class Create_Data_Provider_Resonse_Times_Table : Migration
    {
        public override void Down()
        {
            Delete.PrimaryKey("PK_DataProviderResponseTime");
            Delete.Index("IDX_DataProviderResponseTime_RequestId");
            Delete.Index("IDX_DataProviderResponseTime_DataProviderId");
            Delete.Index("IDX_DataProviderResponseTime_DataProviderCommandType");
            Delete.Table("DataProviderResponseTime");
        }

        public override void Up()
        {
            Create.Table("DataProviderResponseTime")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_DataProviderResponseTime")
                .WithColumn("DataProviderId").AsInt16().NotNullable().Indexed("IDX_DataProviderResponseTime_DataProviderId")
                .WithColumn("DataProviderName").AsString(50).NotNullable()
                .WithColumn("CommandTypeId").AsInt16().NotNullable().Indexed("IDX_DataProviderResponseTime_DataProviderCommandType")
                .WithColumn("CommandTypeName").AsString(50).NotNullable()
                .WithColumn("ElapsedTime").AsString().NotNullable().WithDefaultValue("00:00:00")
                .WithColumn("RequestId").AsGuid().Indexed("IDX_DataProviderResponseTime_RequestId").NotNullable()
                .WithColumn("CommitStamp").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);
        }
    }
}