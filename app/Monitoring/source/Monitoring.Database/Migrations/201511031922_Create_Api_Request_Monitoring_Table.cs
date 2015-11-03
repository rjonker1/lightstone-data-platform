using FluentMigrator;

namespace Monitoring.Database.Migrations
{
    [Migration(201511031922)]
    public class Create_Api_Request_Monitoring_Table : Migration
    {
        public override void Down()
        {
            Delete.PrimaryKey("PK_ApiRequestMonitoring");
            Delete.Table("ApiRequestMonitoring");
        }

        public override void Up()
        {
            Create.Table("ApiRequestMonitoring")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_ApiRequestMonitoring")
                .WithColumn("RequestId").AsGuid().Indexed().NotNullable()
                .WithColumn("RequestDate").AsDateTime()
                .WithColumn("UserHostAddress").AsString(500).Nullable()
                .WithColumn("Authorization").AsString(int.MaxValue).Nullable()
                .WithColumn("UserName").AsString(1000).Nullable()
                .WithColumn("Method").AsString(50).Nullable()
                .WithColumn("BasePath").AsString(500).Nullable()
                .WithColumn("HostName").AsString(100).Nullable()
                .WithColumn("IsSecure").AsBoolean().Nullable()
                .WithColumn("Port").AsInt32().Nullable()
                .WithColumn("Query").AsString(1000).Nullable()
                .WithColumn("SiteBase").AsString(100).Nullable()
                .WithColumn("Scheme").AsString(25).Nullable()
                .WithColumn("Host").AsString(1000).Nullable()
                .WithColumn("UserAgent").AsString(1000).Nullable()
                .WithColumn("ContentType").AsString(1000).Nullable()
                .WithColumn("CommitDate").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("JsonRequest").AsString(int.MaxValue).Nullable();
        }
    }
}
