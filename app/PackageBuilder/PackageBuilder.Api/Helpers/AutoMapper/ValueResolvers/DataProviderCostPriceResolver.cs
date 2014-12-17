using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class DataProviderCostPriceResolver : ValueResolver<IDataProvider, double>
    {
        protected override double ResolveCore(IDataProvider source)
        {
            var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.Id);
            return dataProvider != null ? dataProvider.CostOfSale : source.CostOfSale;
        }
    }
}