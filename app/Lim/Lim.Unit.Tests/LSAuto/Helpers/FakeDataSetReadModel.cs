using System.Collections.Generic;
using System.Linq;
using Lim.Dtos;
using Lim.Test.Helper.Fakes.Repository;
using Toolbox.LightstoneAuto.Domain.Base;

namespace Lim.Unit.Tests.LSAuto.Helpers
{
    public class FakeDataSetReadModel : IReadDatabaseExtractFacade
    {
        public List<DatabaseExtractDto> GetDataExtracts()
        {
            return FakeLsAutoDatabase.DataSetList.Select(s => new DatabaseExtractDto
            {
                AggregateId = s.AggregateId,
                Name = s.Name,
                Version = s.Version,
                Activated = s.Activated,
                DateCreated = s.DateCreated,
                Fields = new List<DatabaseExtractFieldDto>(),
                //DataFields = FakeDatabase.DataFieldList.Where(w => w.DataSet.Id == s.Id).Select(f => new DataFieldDto
                //{
                //    Id = f.Id,
                //    Name = f.Name,
                //    Activated = f.Activated,
                //    DateCreated = f.DateCreated,
                //    DataSetId = f.DataSet.Id,
                //    DisplayName = f.DisplayName,
                //    Selected = f.Selected,
                //    DateModified = f.DateModified
                //}).ToList(),
                DateModified = s.DateModified,
                Description = s.Description

            }).ToList();
        }

        public DatabaseExtractDto GetDataExtract(long id)
        {
            return FakeLsAutoDatabase.DataSetList.Where(w => w.Id == id).Select(s => new DatabaseExtractDto
            {
                AggregateId = s.AggregateId,
                Name = s.Name,
                Version = s.Version,
                Activated = s.Activated,
                DateCreated = s.DateCreated,
                Fields = new List<DatabaseExtractFieldDto>(),
                //DataFields = FakeDatabase.DataFieldList.Where(w => w.DataSet.Id == s.Id).Select(f => new DataFieldDto
                //{
                //    Id = f.Id,
                //    Name = f.Name,
                //    Activated = f.Activated,
                //    DateCreated = f.DateCreated,
                //    DataSetId = f.DataSet.Id,
                //    DisplayName = f.DisplayName,
                //    Selected = f.Selected,
                //    DateModified = f.DateModified
                //}).ToList(),
                DateModified = s.DateModified,
                Description = s.Description

            }).FirstOrDefault();
        }
    }
}
