using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class DataFieldMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>()
                //.ForMember(d => d.Price, opt => opt.ResolveUsing( new DataFieldPriceResolver()))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x => 
                    x.Industries != null 
                    ? x.Industries.ToList().Concat(ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()).DistinctBy(c => c.Id) 
                    : ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()));

            Mapper.CreateMap<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>()
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<DataProviderFieldItemDto>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>).ToList();
                    return dataProviderFieldItemDtos;
                });

            Mapper.CreateMap<DataProviderFieldItemDto, IDataField>()
                .ConvertUsing<ITypeConverter<DataProviderFieldItemDto, IDataField>>();
            Mapper.CreateMap<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>()
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<IDataField>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<DataProviderFieldItemDto, IDataField>).ToList();
                    return dataProviderFieldItemDtos;
                });
        }
    }
}