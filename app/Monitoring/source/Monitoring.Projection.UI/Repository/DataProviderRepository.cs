using System;
using System.Data;
using System.Linq;
using Monitoring.Projection.UI.Repository.Framework;
using Monitoring.Projection.UI.Repository.Framework.Orm;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Projection.UI.Repository
{
    public class DataProviderRepository
    {
        private readonly IDbConnection _connection;

        public DataProviderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public MonitoringDataProviderModel[] GetMonitoringFromDataProviders()
        {
            var results =
                _connection.Query<MonitoringDataProviderModel>(SelectStatements.GetMonitoringFromAllDataProviders)
                    .ToList();

            return results.Any() ? results.ToArray() : new MonitoringDataProviderModel[0];
        }

        public MonitoringDataProviderModel[] GetMonitoringFromDataProvidersByCategory(int categoryId)
        {
            var results =
                _connection.Query<MonitoringDataProviderModel>(
                    SelectStatements.GetMonitoringFromDataProvidersByCategory, new {@CategoryId = categoryId}).ToList();

            return results.Any() ? results.ToArray() : new MonitoringDataProviderModel[0];
        }

        public MonitoringDataProviderModel[] GetMonitoringFromDataProvidersByType(int dataProviderId)
        {
            var results =
                _connection.Query<MonitoringDataProviderModel>(
                    SelectStatements.GetMonitoringFromDataProvidersByType, new {@DataProviderId = dataProviderId})
                    .ToList();

            return results.Any() ? results.ToArray() : new MonitoringDataProviderModel[0];
        }

        public MonitoringDataProviderModel[] GetMonitoringFromDataProviderByAggregate(Guid aggregateId)
        {
            var results =
                _connection.Query<MonitoringDataProviderModel>(
                    SelectStatements.GetMonitoringFromDataProvidersByAggregate, new { @AggregateId = aggregateId })
                    .ToList();

            return results.Any() ? results.ToArray() : new MonitoringDataProviderModel[0];
        }
    }
}