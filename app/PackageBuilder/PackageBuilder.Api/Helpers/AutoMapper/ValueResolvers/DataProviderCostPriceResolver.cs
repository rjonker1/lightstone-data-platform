using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;


namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class DataProviderCostPriceResolver : ValueResolver<IDataProvider, decimal>
    {
        protected override decimal ResolveCore(IDataProvider source)
        {
            var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.Id);
            return dataProvider != null ? dataProvider.CostOfSale : source.CostOfSale;
        }
    }
}