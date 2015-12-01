using FluentMigrator;

namespace Monitoring.Database.Migrations
{
  
    [Migration(201512010705)]
    public class Create_Data_Provider_Request_Field_Table : Migration
    {
        public override void Down()
        {
            Delete.PrimaryKey("PK_DataProviderResponseTime");
            Delete.Index("IDX_DataProviderRequestField_RequestId");
            Delete.Index("IDX_DataProviderRequestField_RequestFieldType");
            Delete.Index("IDX_DataProviderRequestField_PackageId");
            Delete.Table("DataProviderRequestField");
        }

        public override void Up()
        {
            Create.Table("DataProviderRequestField")
                .WithColumn("DataProviderId").AsInt16().NotNullable().Indexed("IDX_DataProviderResponseTime_DataProviderId")
                .WithColumn("DataProviderName").AsString(50).NotNullable()
                .WithColumn("RequestFields").AsBinary(int.MaxValue).Nullable()
                .WithColumn("RequestId").AsGuid().Indexed("IDX_DataProviderRequestField_RequestId").NotNullable()
                .WithColumn("PackageName").AsString(100).Indexed("IDX_DataProviderRequestField_PackageName").NotNullable()
                .WithColumn("CommitStamp").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);
        }
    }
}