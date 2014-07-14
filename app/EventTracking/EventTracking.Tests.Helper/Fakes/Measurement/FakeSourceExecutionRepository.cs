using System;
using System.Collections.Generic;
using System.Linq;
using EventTracking.Measurement.Dto;

namespace EventTracking.Measurement.Repository
{
    public class FakeSourceExecutionRepository : IRepository<ExternalSourceExecutionResultDto>
    {
        private static List<KeyValuePair<Guid, ExternalSourceExecutionResultDto>> Database =
            new List<KeyValuePair<Guid, ExternalSourceExecutionResultDto>>();

        public ExternalSourceExecutionResultDto Get(Guid id)
        {
            return Database.Single(w => w.Key == id).Value;
        }

        public IQueryable<ExternalSourceExecutionResultDto> GetAll()
        {
            return Database
                .Select(s => s.Value)
                .AsQueryable();
        }

        public void Save(ExternalSourceExecutionResultDto item)
        {
            if (item == null) return;

            if(Database.Count(c => c.Value.AggregateId == item.AggregateId && c.Value.Source == item.Source && c.Value.Order == item.Order) != 0)return;

            Database.Add(new KeyValuePair<Guid, ExternalSourceExecutionResultDto>(item.AggregateId, item));
        }
    }
}
