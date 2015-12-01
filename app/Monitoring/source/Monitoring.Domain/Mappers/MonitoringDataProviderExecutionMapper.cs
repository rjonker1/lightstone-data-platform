using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Mappers
{
    public class MonitoringDataProviderExecutionMapper : TypeMapper
    {
        protected override IEnumerable<string> FieldNames
        {
            get
            {
                return new[]
                {
                    "DataProviderId", "DataProviderName", "CommandTypeId", "CommandTypeName", "ElapsedTime", "RequestId"
                };
            }
        }

        public override object Get(System.Data.IDbConnection connection, Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(System.Data.IDbConnection connection, object instance)
        {
            var request = instance as MonitoringDataProviderExecution;
            var sql = GenerateInsertStatement();
            var values = new
            {
                DataProviderId = request.DataProvider.Id,
                DataProviderName = request.DataProvider.Name,
                CommandTypeId = request.Command.Id,
                CommandTypeName = request.Command.Name,
                ElapsedTime = request.ElapsedTime,
                RequestId = request.DataProvider.RequestId
            };

            connection.Execute(sql, values);
        }

        protected override string TableName
        {
            get { return "DataProviderResponseTime"; }
        }
    }
}
