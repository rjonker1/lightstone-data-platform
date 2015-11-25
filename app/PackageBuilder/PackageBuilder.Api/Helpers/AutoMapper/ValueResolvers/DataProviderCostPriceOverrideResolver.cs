using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Infrastructure.NEventStore;

namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    public class DataProviderCostPriceOverrideResolver : ValueResolver<IDataProvider, Task<bool>>
    {
        protected override async Task<bool> ResolveCore(IDataProvider source)
        {
            var dataProvider = await ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.Id);
            return dataProvider != null ? dataProvider.FieldLevelCostPriceOverride : source.FieldLevelCostPriceOverride;
        }
    }
}