using System.Linq;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoDataSetCommit : AbstractPersistenceRepository<DatabaseExtractDto>
    {
        public override bool Persist(DatabaseExtractDto dto)
        {
            var dataSetEntity = new DatabaseExtract
            {
                Id = dto.Id,
                AggregateId = dto.AggregateId,
                Activated = dto.Activated,
                Name = dto.Name,
                Version = dto.Version,
                Description = dto.Description
                //CreatedBy = dto.CreatedBy,
                //ModifiedBy = dto.ModifiedBy
            };

            var dataFields = dto.Fields.Select(s => new DatabaseExtractField
            {
                Id = s.Id,
                Name = s.Name,
                DatabaseExtract = dataSetEntity,
                DisplayName = s.DisplayName,
                Selected = s.Selected
            });


            FakeLsAutoDatabase.DataSetList.Add(dataSetEntity);
            foreach (var field in dataFields)
            {
                FakeLsAutoDatabase.DataFieldList.Add(field);
            }

            return false;
        }
    }
}
