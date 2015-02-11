using System;
using System.Collections;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Customers
{
    public class CustomerMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.CommercialState, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.CommercialStateId, typeof(CommercialState)))))
                .ForMember(dest => dest.CreateSource, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.CreateSourceId, typeof(CreateSource)))))
                .ForMember(dest => dest.PlatformStatus, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.PlatformStatusId, typeof(PlatformStatus)))))
                .ForMember(dest => dest.Billing, opt => opt.MapFrom(x => Mapper.Map<BillingDto, Billing>(x.BillingDto)));
        }
    }

    public class BillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Billing, BillingDto>();
            Mapper.CreateMap<BillingDto, Billing>();
        }
    }

    public class EntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Tuple<Guid, Type>, Entity>()
                .ConvertUsing<ITypeConverter<Tuple<Guid, Type>, Entity>>();
        }
    }

    public class IdToEntityConverter : TypeConverter<Tuple<Guid, Type>, Entity>
    {
        private readonly IWindsorContainer _container;

        public IdToEntityConverter(IWindsorContainer container)
        {
            _container = container;
        }

        protected override Entity ConvertCore(Tuple<Guid, Type> source)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(source.Item2);
            var repository = (IEnumerable)_container.Resolve(executorType);
            var entities = (from Entity item in repository where item.Id == source.Item1 select item);
            return entities.Any() ? entities.First() : null;
        }
    }
}