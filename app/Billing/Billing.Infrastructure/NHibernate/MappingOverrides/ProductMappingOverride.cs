using Billing.Domain.Entities.DemoEntities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Billing.Infrastructure.NHibernate.MappingOverrides
{
    public class ProductMappingOverride : IAutoMappingOverride<Product>
    {
        public void Override(AutoMapping<Product> mapping)
        {
            //mapping.HasMany(x => x.Transactions).Cascade.SaveUpdate();
        }
    }
}