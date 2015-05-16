using System;
using FluentMigrator;

namespace Lim.Database.Migrations
{
    [Tags("Lim")]
    [Migration(201515051330)]
    public class Create_Lim_Configuration_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Configuration")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().Indexed()
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
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().Indexed()
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
            Delete.Table("ConfigurationApi");
        }
    }

    [Tags("Lim")]
    [Migration(201515051328)]
    public class Create_Lim_Packages_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Packages")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().Indexed()
                .WithColumn("ConfigurationId").AsInt64().NotNullable().Indexed()
                .WithColumn("PackageId").AsGuid()
                .WithColumn("DateCreated").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Table("Packages");
        }
    }

    [Tags("Lim")]
    [Migration(201515051325)]
    public class Create_Lim_ActionType_Table : Migration
    {
        public override void Up()
        {
            Create.Table("ActionType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey().Indexed()
                .WithColumn("Type").AsString()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Table("Action");
        }
    }

    [Tags("Lim")]
    [Migration(201515051326)]
    public class Create_Lim_Integration_Type_Table : Migration
    {
        public override void Up()
        {
            Create.Table("IntegrationType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey().Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Table("IntegrationType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051327)]
    public class Create_Lim_Authentication_Type_Table : Migration
    {
        public override void Up()
        {
            Create.Table("AuthenticationType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey().Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Table("AuthenticationType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051338)]
    public class Create_Lim_FrequencyType_Table : Migration
    {
        public override void Up()
        {
            Create.Table("FrequencyType")
                .WithColumn("Id").AsInt16().Identity().PrimaryKey().Indexed()
                .WithColumn("Type").AsString(50)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Table("FrequencyType");
        }
    }

    [Tags("Lim")]
    [Migration(201515051350)]
    public class Create_Lim_CustomFrequency_Table : Migration
    {
        public override void Up()
        {
            Create.Table("CustomFrequency")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().Indexed()
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
            Delete.Table("CustomFrequency");
        }
    }

    [Tags("Lim")]
    [Migration(201515051350)]
    public class Create_Lim_AuditIntegration_Table : Migration
    {
        public override void Up()
        {
            Create.Table("AuditApiIntegration")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey().Indexed()
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
            Delete.Table("AuditIntegration");
        }
    }
}