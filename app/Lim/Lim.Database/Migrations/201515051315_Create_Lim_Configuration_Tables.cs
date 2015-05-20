using System;
using FluentMigrator;

namespace Lim.Database.Migrations
{
    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_Configuration_Table : Migration
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
                .WithColumn("AccountNumber").AsString(50)
                .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_Configuration");
            Delete.Table("Configuration");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_ApiConfiguration_Table : Migration
    {
        public override void Up()
        {
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
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_ConfigurationApi");
            Delete.Table("ConfigurationApi");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_Packages_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Packages")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_Pacakges").Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("PackageId").AsGuid()
                .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_Pacakges");
            Delete.Table("Packages");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_ActionType_Table : Migration
    {
        public override void Up()
        {
            Create.Table("ActionType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_Action").Indexed()
                .WithColumn("Type").AsString()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_Action");
            Delete.Table("Action");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_Integration_Type_Table : Migration
    {
        public override void Up()
        {
            Create.Table("IntegrationType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_IntegrationType").Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_IntegrationType");
            Delete.Table("IntegrationType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_Authentication_Type_Table : Migration
    {
        public override void Up()
        {
            Create.Table("AuthenticationType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_AuthenticationType").Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_AuthenticationType");
            Delete.Table("AuthenticationType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_FrequencyType_Table : Migration
    {
        public override void Up()
        {
            Create.Table("FrequencyType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey("PK_FrequencyType").Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_FrequencyType");
            Delete.Table("FrequencyType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_CustomFrequency_Table : Migration
    {
        public override void Up()
        {
            Create.Table("CustomFrequency")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey("PK_CustomFrequency").Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("Seconds").AsInt32()
                .WithColumn("Minutes").AsInt32()
                .WithColumn("Hours").AsInt32()
                .WithColumn("Month").AsString(3)
                .WithColumn("WeekDay").AsString(3)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_CustomFrequency");
            Delete.Table("CustomFrequency");
        }
    }

    [Tags("Lim")]
    [Migration(201515051315)]
    public class Create_Lim_AuditIntegration_Table : Migration
    {
        public override void Up()
        {
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
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_AuditApiIntegration");
            Delete.Table("AuditIntegration");
        }
    }
}