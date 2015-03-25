using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class ToDataProviderDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<IDataProvider>, IEnumerable<DataProviderDto>>()
                .ConvertUsing(s => s != null ? s.Select(Mapper.Map<IDataProvider, DataProviderDto>) : Enumerable.Empty<DataProviderDto>());
            Mapper.CreateMap<IDataProvider, DataProviderDto>()
                //.ForMember(d => d.CostOfSale, opt => opt.ResolveUsing(new DataProviderCostPriceResolver()))
                //.ForMember(d => d.FieldLevelCostPriceOverride, opt => opt.ResolveUsing(new DataProviderCostPriceOverrideResolver()))
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
        }
    }
}