using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class ProductMaps : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IEnumerable<DataProviderTransaction>, IEnumerable<Product>>()
                .ConvertUsing(s => s.Select(Mapper.Map<DataProviderTransaction, Product>));

            Mapper.CreateMap<DataProviderTransaction, Product>();
        }
    }
}