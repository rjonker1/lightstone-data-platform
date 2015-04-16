using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class UserMetaMaps : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Used: Entity Consumer
            Mapper.CreateMap<UserMessage, UserMeta>();

            //Used: Transaction Consumer
            Mapper.CreateMap<UserMeta, User>();
        }
    }
}