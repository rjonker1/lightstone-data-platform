using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class IndividualContactNumberOverride : IAutoMappingOverride<IndividualContactNumber>
    {
        public void Override(AutoMapping<IndividualContactNumber> mapping)
        {
            mapping.References(x => x.Individual).Cascade.SaveUpdate();
        }
    }
}