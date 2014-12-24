using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Shared.Monitoring.Messages.Core;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Projection.Core.Contracts;
using Monitoring.Projection.Core.Models;
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

        public DataProviderPerformanceDto[] ShowPerformanceResults()
        {
            var results =
                _storage.Items<MonitoringDataProviderModel>().Where(w => w.CategoryId == (int) Category.Performance);

            if (results.Any())
            {
                return
                    results.Select(
                        s =>
                            new DataProviderPerformanceDto(s.DataProvider, s.Payload, s.Message, s.Metadata,
                                s.Date.ToString(), s.RequestAggregateId).GetElapsedTime()).ToArray();
            }

            return new List<DataProviderPerformanceDto>().ToArray();
        }
    }
}
