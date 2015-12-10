using System.Linq;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoViewCommit : AbstractPersistenceRepository<ViewDto>
    {
        public override bool Persist(ViewDto dto)
        {
            var viewEntitiy = new View
            {
                Id = dto.Id,
                AggregateId = dto.AggregateId,
                Activated = dto.Activated,
                Name = dto.Name,
                Version = dto.Version,
                DisplayName = dto.DisplayName
            };

            var dataFields = dto.ViewColumns.Select(s => new ViewColumn()
            {
                Id = s.Id,
                Name = s.Name,
                View = viewEntitiy,
                DisplayName = s.DisplayName
            });

            FakeLsAutoDatabase.ViewList.Add(viewEntitiy);
            foreach (var field in dataFields)
            {
                FakeLsAutoDatabase.ViewColumnList.Add(field);
            }

            return true;
        }
    }
}
