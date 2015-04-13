using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class PreBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Mapper.CreateMap<PreBillingDto, PreBilling>();

            //Mapper.CreateMap<IEnumerable<PreBillingDto>, IEnumerable<PreBilling>>()
            //    .ConvertUsing(s => s.Select(Mapper.Map<PreBillingDto, PreBilling>));
            //Mapper.CreateMap<PreBillingDto, PreBilling>()
            //    .ForMember(d => d.Users, opt => opt.MapFrom(x => x.Users));
        }
    }
}
