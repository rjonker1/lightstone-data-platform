using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Infrastructure.NEventStore;


namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class DataProviderCostPriceResolver : ValueResolver<IDataProvider, Task<decimal>>
    {
        protected override async Task<decimal> ResolveCore(IDataProvider source)
        {
            var dataProvider = await ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.Id);
            return dataProvider != null ? dataProvider.CostOfSale : source.CostOfSale;
        }
    }
}