using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Repository;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Infrastructure.ReadModels
{
    public class DatabaseExtractReadModel : IReadDatabaseExtractFacade
    {
        private readonly IReadOnlyRepository _repository;

        public DatabaseExtractReadModel(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public DatabaseExtractReadModel()
        {
            _repository = new LsAutoReadRepository();
        }

        public List<DatabaseExtractDto> GetDataExtracts()
        {
            var results = _repository.GetAll<DatabaseExtract>().ToList();
            return !results.Any()
                ? new List<DatabaseExtractDto>()
                : AutoMapper.Mapper.Map<List<DatabaseExtract>, List<DatabaseExtractDto>>(results.ToList());
        }

        public DatabaseExtractDto GetDataExtract(long id)
        {
            var result = _repository.Get<DatabaseExtract>(w => w.Id == id).FirstOrDefault();
            return result == null ? null : AutoMapper.Mapper.Map<DatabaseExtract, DatabaseExtractDto>(result);
        }
    }
}