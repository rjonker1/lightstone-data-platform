using System.Linq;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLsAutoDataSetCommit : AbstractPersistenceRepository<DataSetDto>
    {
        public override bool Persist(DataSetDto dto)
        {
            var dataSetEntity = new DataSet
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

            var dataFields = dto.DataFields.Select(s => new DataField
            {
                Id = s.Id,
                Name = s.Name,
                Activated = s.Activated,
                DataSet = dataSetEntity,
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
