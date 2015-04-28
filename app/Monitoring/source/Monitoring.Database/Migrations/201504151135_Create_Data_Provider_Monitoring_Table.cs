﻿using System;
using FluentMigrator;

namespace Monitoring.Database.Migrations
{
    [Migration(201504151135)]
    public class Create_Data_Provider_Monitoring_Table : Migration
    {
        public override void Down()
        {
            Delete.Table("DataProviderMonitoring");
        }

        public override void Up()
        {
            Create.Table("DataProviderMonitoring")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("RequestId").AsGuid().Indexed().NotNullable()
                .WithColumn("SearchType").AsString().NotNullable()
                .WithColumn("SearchTerm").AsString()
                .WithColumn("ElapsedTime").AsString().NotNullable()
                .WithColumn("BucketId").AsString().NotNullable()
                .WithColumn("Action").AsString().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable();

        }
    }
}
