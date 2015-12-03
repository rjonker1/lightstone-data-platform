using System.Collections.Generic;
using System.Linq;
using Lim.Test.Helper.Fakes.Repository;
using Toolbox.LightstoneAuto.Database.Domain;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;
namespace Lim.Unit.Tests.LSAuto.Helpers
{
    public class FakeDataSetReadModel : IReadModelFacade
    {
        public IEnumerable<DataSetDto> GetDataSets()
        {
            return FakeDatabase.DataSetList.Select(s => new DataSetDto
            {
                Id = s.Id,
                Name = s.Name,
                Version = s.Version,
                Activated = s.Activated,
                DateCreated = s.DateCreated,
                DataFields = FakeDatabase.DataFieldList.Where(w => w.DataSetId == s.Id).Select(f => new DataFieldDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Activated = f.Activated,
                    DateCreated = f.DateCreated,
                    DataSetId = f.DataSetId,
                    DisplayName = f.DisplayName,
                    Selected = f.Selected,
                    DateModified = f.DateModified
                }).ToList(),
                DateModified = s.DateModified,
                Description = s.Description
                
            });
        }

        //public DataSetDetailsDto GetDataSet(Guid id)
        //{
        //    return FakeDatabase.Details[id];
        //}

    }
}
