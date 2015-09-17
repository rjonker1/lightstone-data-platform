using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class IndividualOverride : IAutoMappingOverride<Individual>
    {
        public void Override(AutoMapping<Individual> mapping)
        {
            mapping.HasMany(x => x.Addresses).Cascade.SaveUpdate();
        }
    }

    public class IndividualAddressOverride : IAutoMappingOverride<IndividualAddress>
    {
        public void Override(AutoMapping<IndividualAddress> mapping)
        {
            mapping.References(x => x.Individual).Cascade.SaveUpdate();
            mapping.References(x => x.Address).Cascade.SaveUpdate();
        }
    }

    public class AddressOverride : IAutoMappingOverride<Address>
    {
        public void Override(AutoMapping<Address> mapping)
        {
            mapping.References(x => x.Country).Cascade.SaveUpdate();
            mapping.References(x => x.Province).Cascade.SaveUpdate();
        }
    }
}