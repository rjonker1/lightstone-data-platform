﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Api.Modules;
using Billing.Domain.Entities;
using Billing.Domain.Entities.DemoEntities;
using Transaction = Billing.Domain.Entities.Transaction;

namespace Billing.Api.Helpers.AutoMapper.Maps
{
    public class PreBillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<Transaction>, IEnumerable<PreBillingDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Transaction, PreBillingDto>));
            Mapper.CreateMap<Transaction, PreBillingDto>();
            //.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(x => x.NumUsers));

            Mapper.CreateMap<IEnumerable<Customer>, IEnumerable<PreBillingDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<Customer, PreBillingDto>));
            Mapper.CreateMap<Customer, PreBillingDto>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(x => x.Name));
        }
    }
}