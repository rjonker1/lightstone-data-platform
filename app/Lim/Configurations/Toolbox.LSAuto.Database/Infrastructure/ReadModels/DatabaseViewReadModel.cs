using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Repository;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Infrastructure.ReadModels
{
    public class DatabaseViewReadModel : IReadDatabaseViewFacade
    {
        private readonly IReadOnlyRepository _repository;

        public DatabaseViewReadModel(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public DatabaseViewReadModel()
        {
            _repository = new LsAutoReadRepository();
        }

        public List<DatabaseViewDto> GetDatabaseViews()
        {
            var results = _repository.GetAll<DatabaseView>().ToList();
            return !results.Any() ? new List<DatabaseViewDto>() : AutoMapper.Mapper.Map<List<DatabaseView>, List<DatabaseViewDto>>(results.ToList());
        }

        public DatabaseViewDto GetDatabaseView(long id)
        {
            var result = _repository.Get<DatabaseView>(w => w.Id == id).FirstOrDefault();
            return result == null ? null : AutoMapper.Mapper.Map<DatabaseView,DatabaseViewDto>(result);
        }
    }
}