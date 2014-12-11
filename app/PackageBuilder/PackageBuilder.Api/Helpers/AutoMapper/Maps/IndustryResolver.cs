using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class IndustryResolver : ValueResolver<IEnumerable<Industry>, IEnumerable<Industry>>
    {
        private readonly IRepository<Industry> _industryRepo;

        public IndustryResolver(IRepository<Industry> industryRepo)
        {
            _industryRepo = industryRepo;
        }

        protected override IEnumerable<Industry> ResolveCore(IEnumerable<Industry> source)
        {
            return _industryRepo.Union(source);
        }
    }
}