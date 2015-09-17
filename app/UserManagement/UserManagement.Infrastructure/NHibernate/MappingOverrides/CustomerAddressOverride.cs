using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerAddressOverride : IAutoMappingOverride<CustomerAddress>
    {
        public void Override(AutoMapping<CustomerAddress> mapping)
        {
            mapping.References(x => x.Customer).Cascade.SaveUpdate();
            mapping.References(x => x.Address).Cascade.SaveUpdate();
        }
    }
}