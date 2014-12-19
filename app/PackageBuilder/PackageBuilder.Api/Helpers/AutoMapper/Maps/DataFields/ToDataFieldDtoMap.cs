using System.Collections.Generic;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataFields
{
    public class ToDataFieldDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing<ITypeConverter<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>>();
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(d => d.Industries, opt => opt.ResolveUsing(new IndustryResolver(ServiceLocator.Current.GetInstance<IRepository<Industry>>())));
        }
    }
}