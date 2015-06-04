using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class IndustryDtoConverter : TypeConverter<IDataField, IEnumerable<IndustryDto>>
    {
        private readonly IRepository<Industry> _repository;

        public IndustryDtoConverter(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<IndustryDto> ConvertCore(IDataField source)
        {
            var allIndustries = Mapper.Map<IEnumerable<IIndustry>, IEnumerable<IndustryDto>>(_repository);
            if (source.Industries == null) return allIndustries;

            var dataFieldIndustries = Mapper.Map<IEnumerable<IIndustry>, IEnumerable<IndustryDto>>(source.Industries).ToList();
            foreach (var industry in dataFieldIndustries)
                industry.IsSelected = true;

            return source.Industries.Any()
                ? dataFieldIndustries.Concat(allIndustries).DistinctBy(c => c.Id)
                : allIndustries;
        }
    }
}