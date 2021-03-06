﻿using FluentMigrator;

namespace Workflow.Database.Migrations
{
    [Tags("Billing")]
    [Migration(201502271652)]
    public class Create_Data_Provider_Transaction_Table : Migration
    {
        public override void Up()
        {
            Create.Table("DataProviderTransaction")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey("PK_DataProvider_Transaction")
                .WithColumn("StreamId").AsGuid().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("RequestId").AsGuid().NotNullable().Indexed("IX_DataProvider_Transaction_RequestId")
                .WithColumn("DataProvider").AsInt32().NotNullable()
                .WithColumn("DataProviderName").AsString().NotNullable()
                .WithColumn("ConnectionType").AsString().NotNullable()
                .WithColumn("Connection").AsString().NotNullable()
                .WithColumn("Action").AsString().NotNullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("StateId").AsInt32().NotNullable()
                .WithColumn("CostPrice").AsDecimal().NotNullable()
                .WithColumn("RecommendedPrice").AsDecimal().NotNullable();
        }

        public override void Down()
        {
            Delete.PrimaryKey("PK_DataProvider_Transaction");
            Delete.Table("DataProviderTransaction");
        }
    }
}