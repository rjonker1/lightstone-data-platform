using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Read.ReadModel.Models;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class DataProviderRepository : IDataProviderRepository
    {
        private readonly IQueryStorage _storage;

        public DataProviderRepository(IQueryStorage storage)
        {
            _storage = storage;
        }

        public IEnumerable<DataProviderResponseDto> GetAllDataProviderInformation()
        {
            return _storage.Items<MonitoringStorageModel>(SelectStatements.GetEventsBySource,
                new {@Source = (int) MonitoringSource.Lace})
                .Select(
                    s =>
                        new DataProviderResponseDto(s.AggregateId, string.Empty, string.Empty,
                            Encoding.UTF8.GetString(s.Payload), s.Date, string.Empty, string.Empty));
        }
    }
}