using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class IndustryConverter : TypeConverter<DataProviderFieldItemDto, IEnumerable<IIndustry>>
    {
        private readonly IRepository<Industry> _repository;

        public IndustryConverter(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<IIndustry> ConvertCore(DataProviderFieldItemDto source)
        {
            return source.Industries != null 
                ? source.Industries.ToList().Where(x => x.IsSelected).Select(x => _repository.Get(x.Id)) 
                : Enumerable.Empty<IIndustry>();
        }
    }
}