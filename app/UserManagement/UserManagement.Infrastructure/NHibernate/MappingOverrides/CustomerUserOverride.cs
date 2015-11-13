using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerUserOverride : IAutoMappingOverride<CustomerUser>
    {
        public void Override(AutoMapping<CustomerUser> mapping)
        {
            mapping.References(x => x.Customer).Cascade.All();
            mapping.References(x => x.User).Cascade.All();
        }
    }
}