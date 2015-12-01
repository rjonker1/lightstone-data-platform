using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Mappers
{
    public class MonitoringDataProviderRequestFieldMapper : TypeMapper
    {
        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                   "DataProviderId", "DataProviderName", "RequestFields", "RequestId", "PackageName"
                };
            }
        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = instance as MonitoringDataProviderRequestField;
            var sql = GenerateInsertStatement();
            var values = new
            {
                DataProviderId = request.DataProvider.Id,
                DataProviderName = request.DataProvider.Name,
                RequestFields = request.RequestField.Payload,
                RequestId = request.DataProvider.RequestId,
                PackageName = request.DataProvider.PackageName
            };

            connection.Execute(sql, values);
        }

        protected override string TableName
        {
            get { return "DataProviderRequestField"; }
        }
    }
}
