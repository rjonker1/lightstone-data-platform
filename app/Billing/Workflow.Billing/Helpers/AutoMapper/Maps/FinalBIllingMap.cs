using System;
using AutoMapper;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class FinalBillingMap : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<StageBilling, FinalBilling>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(dest => dest.StageBillingId, opt => opt.MapFrom(s => s.Id));

            Mapper.CreateMap<FinalBilling, ArchiveBillingTransaction>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => typeof(FinalBilling).Name));
        }
    }
}