using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<MonitoringResponse> GetAllMonitoringInformation(int source)
        {
            var commands = _storage.Items<MonitoringStorageModel>(SelectStatements.GetEventsBySource,
                new {@Source = source})
                .Select(
                    s =>
                        new MonitoringResponseDto(s.AggregateId,
                            (object) Encoding.UTF8.GetString(s.Payload).JsonToObject(),
                            s.Date));

            if (!commands.Any())
                return new List<MonitoringResponse>();

            return commands
                .OrderBy(o => o.Date)
                .GroupBy(g => g.Id, g => g.Payload, (aggId, payload) => new
                {
                    Id = aggId,
                    Payload = payload
                })
                .Select(
                    s =>
                        new MonitoringResponse(s.Id, s.Payload.ObjectToJson(),
                            commands.Where(w => w.Id == s.Id).Max(m => m.Date)))
                .OrderByDescending(o => o.Date);
        }
    }
}