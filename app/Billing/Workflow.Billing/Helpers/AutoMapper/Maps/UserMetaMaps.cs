using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    //public class UserMetaMaps : ICreateAutoMapperMaps
    //{
    //    public void CreateMaps()
    //    {
    //        Mapper.CreateMap<UserMessage, UserMeta>();


    //        Mapper.CreateMap<IEnumerable<UserMeta>, PreBilling>()
    //            .ForMember(d => d.Users, opt => opt.MapFrom(x => x.Select(u => u)));
    //        //    .ConvertUsing(s => s.Select(Mapper.Map<UserMeta, PreBilling>));
    //        //Mapper.CreateMap<UserMeta, PreBilling>();
    //        //.ForMember(d => d.Users, opt => opt.MapFrom(x => x.Username));
    //    }
    //}
}