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
using PackageBuilder.Domain.Entities.Packages.Commands;

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
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>(x.DataFields)));
                //.BeforeMap((src, dest) =>
                //{
                //    var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(src.Id);
                //    if (dataProvider == null) return;

                //    if (src.Version == dataProvider.Version) return; // Source has the latest data field prices, no override with the latest from the repository

                //    var currentDataFields = dataProvider.DataFields.Traverse();
                //    foreach (var currentDataField in currentDataFields)
                //    {
                //        var dataField = src.DataFields.Traverse().FirstOrDefault(fld => fld.Namespace.Trim().ToLower() == currentDataField.Namespace.Trim().ToLower());
                //        if(dataField != null) 
                //            dataField.SetPrice(currentDataField.CostOfSale);
                //    }
                //});


            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing(
                    x => new DataProvider(x.Id, (DataProviderName) Enum.Parse(typeof (DataProviderName), x.Name, true),
                        x.CostOfSale,
                        x.FieldLevelCostPriceOverride, Mapper.Map<IEnumerable<DataProviderFieldItemDto>,
                            IEnumerable<IDataField>>(x.DataFields)));
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>).ToList());


            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<DataProviderOverride>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProviderDto, DataProviderOverride>));
            Mapper.CreateMap<DataProviderDto, DataProviderOverride>()
                .ForMember(d => d.DataFieldValueOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)));


            Mapper.CreateMap<IEnumerable<DataProviderOverride>, IEnumerable<IDataProvider>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProviderOverride, IDataProvider>));
            Mapper.CreateMap<DataProviderOverride, IDataProvider>()
                .ConvertUsing(s =>
                {
                    var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(s.Id);

                    dataProvider.OverrideCostValuesFromPackage(s.CostOfSale);

                    var currentDataFields = dataProvider.DataFields.Traverse().ToList();
                    foreach (var dataFieldValueOverride in s.DataFieldValueOverrides.Traverse())
                    {
                        var dataField = currentDataFields.FirstOrDefault(fld => fld.Namespace.Trim().ToLower() == dataFieldValueOverride.Namespace.Trim().ToLower());
                        if (dataField != null)
                            dataField.SetPrice(dataFieldValueOverride.CostOfSale);
                    }

                    return dataProvider;
                });

        }
    }
}