using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerAccountNumberMappingOverride : IAutoMappingOverride<CustomerAccountNumber>
    {
        public void Override(AutoMapping<CustomerAccountNumber> mapping)
        {
            mapping.HasOne(x => x.Customer).PropertyRef(x => x.CustomerAccountNumber);
        }
    }
}