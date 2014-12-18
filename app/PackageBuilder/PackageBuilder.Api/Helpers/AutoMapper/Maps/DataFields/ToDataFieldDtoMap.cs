using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Extensions;
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
                .ConvertUsing(s =>
                {
                    if (s == null) return Enumerable.Empty<DataProviderFieldItemDto>();
                    var dataProviderFieldItemDtos = s.Select(Mapper.Map<IDataField, DataProviderFieldItemDto>).ToList();
                    return dataProviderFieldItemDtos;
                });
            Mapper.CreateMap<IDataField, DataProviderFieldItemDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(x => x.CostOfSale))
                .ForMember(dest => dest.Industries, opt => opt.MapFrom(x =>
                    x.Industries != null
                        ? x.Industries.ToList().Concat(ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()).DistinctBy(c => c.Id)
                        : ServiceLocator.Current.GetInstance<IRepository<Industry>>().ToList()));
        }
    }
}