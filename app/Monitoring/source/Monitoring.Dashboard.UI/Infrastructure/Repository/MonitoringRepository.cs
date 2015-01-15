using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Dto;
using Monitoring.Read.ReadModel.Models;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly IQueryStorage _storage;

        public MonitoringRepository(IQueryStorage storage)
        {
            _storage = storage;
        }

        public IEnumerable<MonitoringResponse> GetAllMonitoringInformation()
        {
            return _storage.Items<MonitoringStorageModel>(SelectStatements.GetEventsBySource,
                new {@Source = (int) MonitoringSource.Lace})
                .Select(
                    s =>
                        new MonitoringResponseDto(s.AggregateId,
                            (object) Encoding.UTF8.GetString(s.Payload).JsonToObject(),
                            s.Date))
                .GroupBy(g => g.Id, g => g.Payload, (aggId, payload) => new
                {
                    Id = aggId,
                    Payload = payload

                }).Select(s => new MonitoringResponse(s.Id, s.ObjectToJson()));
        }
    }
}