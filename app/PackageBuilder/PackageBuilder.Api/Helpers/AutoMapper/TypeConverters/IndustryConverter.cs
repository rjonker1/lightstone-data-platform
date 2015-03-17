using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.Industries.Read;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.TypeConverters
{
    public class IndustryConverter : TypeConverter<IDataField, IEnumerable<IIndustry>>
    {
        private readonly IRepository<Industry> _industryRepository;

        public IndustryConverter(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;
        }

        protected override IEnumerable<IIndustry> ConvertCore(IDataField source)
        {
            return source.Industries != null
                ? source.Industries.ToList().Concat(_industryRepository.ToList()).DistinctBy(c => c.Id)
                : ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList();
        }
    }
}