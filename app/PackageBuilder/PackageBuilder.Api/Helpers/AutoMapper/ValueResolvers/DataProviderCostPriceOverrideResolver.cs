using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class DataProviderCostPriceOverrideResolver : ValueResolver<IDataProvider, bool>
    {
        protected override bool ResolveCore(IDataProvider source)
        {
            var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.Id);
            return dataProvider != null ? dataProvider.FieldLevelCostPriceOverride : source.FieldLevelCostPriceOverride;
        }
    }
}