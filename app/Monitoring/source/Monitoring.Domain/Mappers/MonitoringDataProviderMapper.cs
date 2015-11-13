using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Monitoring.Domain.Identifiers;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Mappers
{
    public class MonitoringDataProviderMapper : TypeMapper
    {
        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "Id", "RequestId", "PackageName", "PackageVersion", "ElapsedTime", "DataProviderCount", "Date", "Action"
                };
            }
        }

        public override object Get(IDbConnection connection, Guid id)
        {
            var sql = GenerateSelectByIPrimaryKeyStatement();

            var match = connection.Query(sql, new {Id = id}).FirstOrDefault();

            if (match == null)
                return null;

            return
                new MonitoringDataProviderTransaction(new MonitoringDataProviderIdentifier(match.Id, match.Date,
                    new SearchIdentifier(match.PackageName, match.PackageVersion, match.ElapsedTime, match.RequestId,
                        match.DataProviderCount), new MonitoringActionIdentifier(match.Action)));
        }

        public override void Insert(IDbConnection connection, object instance)
        {
            var transaction = instance as MonitoringDataProviderTransaction;
            var sql = GenerateInsertStatement();
            var values = new
            {
                Id = transaction.Monitoring.Id,
                RequestId = transaction.Monitoring.DataProviderSearch.RequestId,
                PackageName = transaction.Monitoring.DataProviderSearch.PackageName,
                PackageVersion = transaction.Monitoring.DataProviderSearch.PackageVersion,
                ElapsedTime = transaction.Monitoring.DataProviderSearch.ElapsedTime,
                DataProviderCount = transaction.Monitoring.DataProviderSearch.DataProviderCount,
                Date = transaction.Monitoring.Date,
                Action = transaction.Monitoring.Action.Name
            };
            connection.Execute(sql, values);
        }

        protected override string TableName
        {
            get { return "DataProviderMonitoring"; }
        }
    }
}
