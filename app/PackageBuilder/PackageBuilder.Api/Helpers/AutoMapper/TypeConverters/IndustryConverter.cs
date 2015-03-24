using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class IndustryConverter : TypeConverter<IDataField, IEnumerable<IIndustry>>
    {
        private readonly IRepository<Industry> _repository;

        public IndustryConverter(IRepository<Industry> repository)
        {
            _repository = repository;
        }

        protected override IEnumerable<IIndustry> ConvertCore(IDataField source)
        {
            return source.Industries != null
                ? source.Industries.ToList().Concat(_repository.ToList()).DistinctBy(c => c.Id)
                : _repository;
        }
    }
}