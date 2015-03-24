using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Api.Modules;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;

namespace Billing.Api.Helpers.AutoMapper.Maps
{
    public class PreBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<PreBilling>, IEnumerable<PreBillingDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<PreBilling, PreBillingDto>));
            Mapper.CreateMap<PreBilling, PreBillingDto>();
            //.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(x => x.NumUsers));
        }
    }
}