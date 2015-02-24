using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class BillingOverride : IAutoMappingOverride<Billing>
    {
        public void Override(AutoMapping<Billing> mapping)
        {
            mapping.References(x => x.PaymentType).Cascade.SaveUpdate();
        }
    }
}