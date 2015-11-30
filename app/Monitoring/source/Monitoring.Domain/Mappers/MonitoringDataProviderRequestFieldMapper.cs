using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;

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
                    "DataProviderId", "DataProviderName", "RequestFieldType", "RequestFieldTypeValue", "RequestId", "PackageName"
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
                RequestFieldType = request.RequestField.Name,
                RequestFieldTypeValue = request.RequestField.Value,
                RequestId = request.DataProvider.RequestId,
                PackageName = request.DataProvider.PackageName
            };
        }

        protected override string TableName
        {
            get { return "DataProviderRequestField"; }
        }
    }
}
