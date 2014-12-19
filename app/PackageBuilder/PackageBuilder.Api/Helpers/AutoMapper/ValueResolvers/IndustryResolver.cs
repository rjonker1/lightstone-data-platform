using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class IndustryResolver : ValueResolver<IDataField, IEnumerable<Industry>>
    {
        private readonly IRepository<Industry> _industryRepository;

        public IndustryResolver(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;
        }

        protected override IEnumerable<Industry> ResolveCore(IDataField source)
        {
            return source.Industries != null
                ? source.Industries.ToList().Concat(_industryRepository.ToList()).DistinctBy(c => c.Id)
                : ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList();
        }
    }
}