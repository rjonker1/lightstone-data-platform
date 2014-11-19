using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMappers
{
    public class DataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<IDataProvider, DataProviderDto>));
            Mapper.CreateMap<IDataProvider, DataProviderDto>()
                .ForMember(d => d.DataFields,
                    opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>(x.DataFields)));

            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing(x => new DataProvider(x.Id, (DataProviderName)Enum.Parse(typeof(DataProviderName), x.Name, true),
                                x.CostOfSale,
                                x.FieldLevelCostPriceOverride, Mapper.Map<IEnumerable<DataProviderFieldItemDto>, 
                                IEnumerable<IDataField>>(x.DataFields)));
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>).ToList());
        }
    }
}