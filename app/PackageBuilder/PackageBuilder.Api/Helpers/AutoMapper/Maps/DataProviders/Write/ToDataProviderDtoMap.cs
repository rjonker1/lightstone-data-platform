using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class ToDataProviderDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataProvider, DataProviderDto>()
                //.ForMember(d => d.CostOfSale, opt => opt.ResolveUsing(new DataProviderCostPriceResolver()))
                //.ForMember(d => d.FieldLevelCostPriceOverride, opt => opt.ResolveUsing(new DataProviderCostPriceOverrideResolver()))
                .ForMember(d => d.RequestFields, opt => opt.MapFrom(x => x.RequestFields != null ? Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>(x.RequestFields.Where(fld => fld != null)) : Enumerable.Empty<DataProviderFieldItemDto>()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<IDataField>, IEnumerable<DataProviderFieldItemDto>>(x.DataFields)))
                .AfterMap((s, d) => d.DataFields.ToNamespace());
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