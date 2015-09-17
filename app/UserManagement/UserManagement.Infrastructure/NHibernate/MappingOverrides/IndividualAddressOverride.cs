using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class IndividualAddressOverride : IAutoMappingOverride<IndividualAddress>
    {
        public void Override(AutoMapping<IndividualAddress> mapping)
        {
            mapping.References(x => x.Individual).Cascade.SaveUpdate();
            mapping.References(x => x.Address).Cascade.SaveUpdate();
        }
    }
}