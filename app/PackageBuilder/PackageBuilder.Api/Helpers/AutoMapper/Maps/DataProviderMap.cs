using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class DataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>()
                .ConvertUsing(s => s.Select(Mapper.Map<IDataProvider, DataProviderDto>));
            Mapper.CreateMap<IDataProvider, DataProviderDto>()
                .ForMember(d => d.CostOfSale, opt => opt.ResolveUsing(new DataProviderCostPriceResolver()))
                .ForMember(d => d.FieldLevelCostPriceOverride,
                    opt => opt.ResolveUsing(new DataProviderCostPriceOverrideResolver()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>(x.DataFields)))
                .BeforeMap((src, dest) =>
                {
                    var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(src.Id);
                    if (dataProvider == null) return;

                    if (src.Version == dataProvider.Version) return; // Source has the latest data field prices, no override with the latest from the repository

                    var currentDataFields = dataProvider.DataFields.Traverse();
                    foreach (var currentDataField in currentDataFields)
                    {
                        var dataField = src.DataFields.Traverse().FirstOrDefault(fld => fld.Namespace.Trim().ToLower() == currentDataField.Namespace.Trim().ToLower());
                        if(dataField != null) 
                            dataField.SetPrice(currentDataField.Price);
                    }
                });

            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing(
                    x => new DataProvider(x.Id, (DataProviderName) Enum.Parse(typeof (DataProviderName), x.Name, true),
                        x.CostOfSale,
                        x.FieldLevelCostPriceOverride, Mapper.Map<IEnumerable<DataProviderFieldItemDto>,
                            IEnumerable<IDataField>>(x.DataFields)));
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>).ToList());
        }
    }
}