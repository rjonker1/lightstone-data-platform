using System.Linq;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoViewCommit : AbstractPersistenceRepository<DatabaseViewDto>
    {
        public override bool Persist(DatabaseViewDto dto)
        {
            var viewEntitiy = new DatabaseView
            {
                Id = dto.Id,
                AggregateId = dto.AggregateId,
                Activated = dto.Activated,
                Name = dto.Name,
                Version = dto.Version,
                DisplayName = dto.DisplayName
            };

            var dataFields = dto.ViewColumns.Select(s => new DatabaseViewColumn()
            {
                Id = s.Id,
                Name = s.Name,
                DatabaseView = viewEntitiy,
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
