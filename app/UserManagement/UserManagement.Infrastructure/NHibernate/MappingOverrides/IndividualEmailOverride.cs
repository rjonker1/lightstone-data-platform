using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class IndividualEmailOverride : IAutoMappingOverride<IndividualEmail>
    {
        public void Override(AutoMapping<IndividualEmail> mapping)
        {
            mapping.References(x => x.Individual).Cascade.SaveUpdate();
        }
    }
}