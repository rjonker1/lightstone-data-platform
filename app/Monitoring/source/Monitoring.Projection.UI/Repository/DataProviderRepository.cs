using System.Linq;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Projection.UI.Repository.Framework;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Projection.UI.Repository
{
    public class DataProviderRepository
    {
        private readonly IQueryStorage _queryStorage;

        public DataProviderRepository(IQueryStorage queryStorage)
        {
            _queryStorage = queryStorage;
        }

        public MonitoringDataProviderModel[] GetMonitoringFromDataProviders()
        {
            var results =
                _queryStorage.Items<MonitoringDataProviderModel>(SelectStatements.GetMonitoringFromAllDataProviders);

            return results.Any() ? results.ToArray() : new MonitoringDataProviderModel[0];

            //if (results.Any())
            //{
            //    return
            //        results.Select(
            //            s =>
            //                new DataProviderPerformanceDto(s.DataProvider, s.Payload, s.Message, s.Metadata,
            //                    s.Date.ToString(), s.RequestAggregateId, s.TimeStamp).GetElapsedTime()).ToArray();
            //}

            //return new List<DataProviderPerformanceDto>().ToArray();
        }
    }
}