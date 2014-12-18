using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders
{
    public class ToDataProviderMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<DataProviderDto, IDataProvider>).ToList());
            Mapper.CreateMap<DataProviderDto, IDataProvider>()
                .ConvertUsing(
                    x => new DataProvider(x.Id, (DataProviderName)Enum.Parse(typeof(DataProviderName), x.Name, true),
                        x.CostOfSale,
                        x.FieldLevelCostPriceOverride, Mapper.Map<IEnumerable<DataProviderFieldItemDto>,
                            IEnumerable<IDataField>>(x.DataFields)));


            Mapper.CreateMap<IEnumerable<DataProviderOverride>, IEnumerable<IDataProvider>>()
               .ConvertUsing(s => s.Select(Mapper.Map<DataProviderOverride, IDataProvider>));
            Mapper.CreateMap<DataProviderOverride, IDataProvider>()
                .ConvertUsing(s =>
                {
                    var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(s.Id);

                    dataProvider.OverrideCostValuesFromPackage(s.CostOfSale);

                    var currentDataFields = dataProvider.DataFields.Traverse().ToList();
                    foreach (var dataFieldValueOverride in s.DataFieldOverrides.Traverse())
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