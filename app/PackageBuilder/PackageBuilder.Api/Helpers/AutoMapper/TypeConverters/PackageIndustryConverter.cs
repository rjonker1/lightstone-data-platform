using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class PackageIndustryConverter : TypeConverter<PackageDto, IEnumerable<Industry>>
    {
        private readonly IRepository<Industry> _repository;

        public PackageIndustryConverter(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<Industry> ConvertCore(PackageDto source)
        {
            return source.Industries != null
                ? source.Industries.Where(x => x.IsSelected).Select(x => _repository.Get(x.Id)).ToList()
                : _repository.ToList();
        }
    }
}