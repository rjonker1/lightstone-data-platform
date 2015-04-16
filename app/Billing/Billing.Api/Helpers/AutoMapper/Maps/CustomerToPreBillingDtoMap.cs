using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Api.Modules;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities.DemoEntities;
using DataPlatform.Shared.Repositories;

namespace Billing.Api.Helpers.AutoMapper.Maps
{
    public class CustomerToPreBillingDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IRepository<Customer>, IEnumerable<PreBillingDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Customer, PreBillingDto>));

            Mapper.CreateMap<Customer, PreBillingDto>()
                //.ConvertUsing(s => new PreBillingDto{ CustomerName =  s.Name});
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(x => x.Name));
        }
    }
}