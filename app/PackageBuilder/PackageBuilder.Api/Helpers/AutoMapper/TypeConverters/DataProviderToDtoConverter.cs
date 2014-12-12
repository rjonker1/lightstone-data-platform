using System.Collections.Generic;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class DataProviderToDtoConverter : ITypeConverter<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>
    {
        private IDataProviderRepository _repository;

        public DataProviderToDtoConverter(IDataProviderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DataProviderDto> Convert(ResolutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}