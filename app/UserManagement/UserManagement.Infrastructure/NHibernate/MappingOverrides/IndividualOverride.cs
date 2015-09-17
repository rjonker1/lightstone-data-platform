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
            mapping.HasMany(x => x.ContactNumbers).Cascade.SaveUpdate();
            mapping.HasMany(x => x.Emails).Cascade.SaveUpdate();
        }
    }
}