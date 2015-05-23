using System;
using FluentMigrator;

namespace Lim.Database.Migrations
{
    [Tags("Lim")]
    [Migration(201515051315)]
    public class CreateLimTables : Migration
    {
        public override void Up()
        {
            Create.Table("Configuration")
               .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_Configuration").Indexed()
               .WithColumn("Key").AsGuid().WithDefaultValue(SystemMethods.NewGuid).NotNullable().Indexed()
               .WithColumn("FrequencyType").AsInt16().NotNullable()
               .WithColumn("ActionType").AsInt16().NotNullable()
               .WithColumn("IntegrationType").AsInt16().NotNullable()
               .WithColumn("ClientId").AsGuid()
               .WithColumn("ContractId").AsGuid()
               .WithColumn("AccountNumber").AsInt32()
               .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
               .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);


            Create.Table("ConfigurationApi")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_ConfigurationApi").Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("BaseAddress").AsString()
                .WithColumn("Suffix").AsString()
                .WithColumn("Username").AsString()
                .WithColumn("Password").AsString()
                .WithColumn("HasAuthentication").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("AuthenticationToken").AsString()
                .WithColumn("AuthenticationKey").AsString()
                .WithColumn("AuthenticationType").AsInt16().NotNullable()
                .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);

            Create.Table("Packages")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_Pacakges").Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("PackageId").AsGuid()
                .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("ActionType")
               .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_Action").Indexed()
               .WithColumn("Type").AsString()
               .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("IntegrationType")
               .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_IntegrationType").Indexed()
               .WithColumn("Type").AsString(50)
               .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("AuthenticationType")
               .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_AuthenticationType").Indexed()
               .WithColumn("Type").AsString(50)
               .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("FrequencyType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_FrequencyType").Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("CustomFrequency")
               .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_CustomFrequency").Indexed()
               .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
               .WithColumn("Seconds").AsInt32()
               .WithColumn("Minutes").AsInt32()
               .WithColumn("Hours").AsInt32()
               .WithColumn("Month").AsString(3)
               .WithColumn("WeekDay").AsString(3)
               .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.Table("AuditApiIntegration")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_AuditApiIntegration").Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("ActionType").AsInt16()
                .WithColumn("IntegrationType").AsInt16()
                .WithColumn("Date").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("WasSuccessful").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("Address").AsString(500).NotNullable()
                .WithColumn("Suffix").AsString(50).NotNullable()
                .WithColumn("Payload").AsString(Int32.MaxValue);

            Create.Table("PackageResponses")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_PackageResponses").Indexed()
                .WithColumn("PackageId").AsGuid().Indexed()
                .WithColumn("UserId").AsGuid()
                .WithColumn("ContractId").AsGuid().Indexed()
                .WithColumn("AccountNumber").AsInt32()
                .WithColumn("ResponseDate").AsDateTime()
                .WithColumn("RequestId").AsGuid().Indexed()
                .WithColumn("Payload").AsString(Int32.MaxValue)
                .WithColumn("HasResponse").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CommitDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime);

            Create.Table("Weekdays")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_Weekday").Indexed()
                .WithColumn("Day").AsString(10);


            Execute.Script("InsertSeedData.sql");
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_Configuration");
            Delete.Table("Configuration");

            Delete.PrimaryKey("PK_ConfigurationApi");
            Delete.Table("ConfigurationApi");

            Delete.PrimaryKey("PK_Pacakges");
            Delete.Table("Packages");

            Delete.PrimaryKey("PK_Action");
            Delete.Table("Action");

            Delete.PrimaryKey("PK_Weekday");
            Delete.Table("Weekdays");

            Delete.PrimaryKey("PK_PackageResponses");
            Delete.Table("PackageResponses");

            Delete.PrimaryKey("PK_IntegrationType");
            Delete.Table("IntegrationType");

            Delete.PrimaryKey("PK_AuthenticationType");
            Delete.Table("AuthenticationType");

            Delete.PrimaryKey("PK_FrequencyType");
            Delete.Table("FrequencyType");

            Delete.PrimaryKey("PK_CustomFrequency");
            Delete.Table("CustomFrequency");

            Delete.PrimaryKey("PK_AuditApiIntegration");
            Delete.Table("AuditIntegration");

            Delete.PrimaryKey("PK_PackageResponses");
            Delete.Table("PackageResponses");
        }
    }
}
