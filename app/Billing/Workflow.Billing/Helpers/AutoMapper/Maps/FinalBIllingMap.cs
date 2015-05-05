using System;
using AutoMapper;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class FinalBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PreBilling, FinalBilling>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(dest => dest.PreBillingId, opt => opt.MapFrom(s => s.Id));
        }
    }
}