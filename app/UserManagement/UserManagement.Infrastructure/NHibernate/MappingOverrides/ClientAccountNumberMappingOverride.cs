using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientAccountNumberMappingOverride : IAutoMappingOverride<ClientAccountNumber>
    {
        public void Override(AutoMapping<ClientAccountNumber> mapping)
        {
            mapping.HasOne(x => x.Client).PropertyRef(x => x.ClientAccountNumber);
        }
    }
}