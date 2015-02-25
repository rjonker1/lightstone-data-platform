using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class AddressOverride : IAutoMappingOverride<Address>
    {
        public void Override(AutoMapping<Address> mapping)
        {
            mapping.References(x => x.Province).Cascade.SaveUpdate();
        }
    }
}