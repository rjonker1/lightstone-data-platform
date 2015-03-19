using Billing.Domain.Entities.DemoEntities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Mapping;

namespace Billing.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerMappingOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.HasMany(x => x.InvoicePreBillings).Cascade.SaveUpdate();
            mapping.HasMany(x => x.Users).Cascade.SaveUpdate();
        }
    }
}