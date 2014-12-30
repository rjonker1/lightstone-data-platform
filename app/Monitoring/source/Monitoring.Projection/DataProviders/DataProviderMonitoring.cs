using System.Collections.Generic;
using System.Linq;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Projection.Core.Contracts;
using Monitoring.Projection.Core.Models.DataProviders;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Projection.DataProviders
{
    public class DataProviderMonitoring : IDataProviderProjection
    {

        private readonly IAccessToStorage _storage;

        public DataProviderMonitoring(IAccessToStorage storage)
        {
            _storage = storage;
        }

        public DataProviderPerformanceDto[] ShowPerformanceResults(int categoryId)
        {
            var results =
                _storage.Items<MonitoringDataProviderModel>().Where(w => w.CategoryId == categoryId);

            if (results.Any())
            {
                return
                    results.Select(
                        s =>
                            new DataProviderPerformanceDto(s.DataProvider, s.Payload, s.Message, s.Metadata,
                                s.Date.ToString(), s.RequestAggregateId, s.TimeStamp).GetElapsedTime()).ToArray();
            }

            return new List<DataProviderPerformanceDto>().ToArray();
        }
    }
}
