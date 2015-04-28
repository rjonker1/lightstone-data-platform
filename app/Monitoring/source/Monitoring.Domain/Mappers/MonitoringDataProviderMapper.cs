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
                    "Id", "RequestId", "SearchType", "SearchTerm", "ElapsedTime", "BucketId", "Date", "Action"
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
                    new SearchIdentifier(match.SearchType, match.SearchTerm, match.ElapsedTime, match.RequestId,
                        match.BucketId), new MonitoringActionIdentifier(match.Action)));
        }

        public override void Insert(IDbConnection connection, object instance)
        {
            var transaction = instance as MonitoringDataProviderTransaction;
            var sql = GenerateInsertStatement();
            var values = new
            {
                Id = transaction.Monitoring.Id,
                RequestId = transaction.Monitoring.DataProviderSearch.RequestId,
                SearchType = transaction.Monitoring.DataProviderSearch.SearchType,
                SearchTerm = transaction.Monitoring.DataProviderSearch.SearchTerm,
                ElapsedTime = transaction.Monitoring.DataProviderSearch.ElapsedTime,
                BucketId = transaction.Monitoring.DataProviderSearch.BucketId,
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
