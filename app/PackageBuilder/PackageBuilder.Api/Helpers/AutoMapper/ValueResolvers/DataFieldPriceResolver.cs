using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.ValueResolvers
{
    //public class DataFieldPriceResolver : ValueResolver<IDataField, double>
    //{
    //    protected override double ResolveCore(IDataField source)
    //    {
    //        var dataProvider = ServiceLocator.Current.GetInstance<INEventStoreRepository<DataProvider>>().GetById(source.DataProviderId);
    //        var dataField = dataProvider.DataFields.Traverse(fld => fld.DataFields).FirstOrDefault(fld => fld.Name.Trim().ToLower() == source.Name.Trim().ToLower());
    //        return dataField != null ? dataField.Price : source.Price;
    //    }
    //}
}