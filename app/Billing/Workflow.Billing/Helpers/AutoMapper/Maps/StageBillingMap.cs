using System;
using AutoMapper;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class StageBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PreBilling, StageBilling>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(dest => dest.PreBillingId, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.HasTransactions, opt => opt.MapFrom(s => true))
                .ForMember(dest => dest.IsBillable, opt => opt.MapFrom(s => true));
        }
    }
}