using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ContactDetailOverride : IAutoMappingOverride<ContactDetail>
    {
        public void Override(AutoMapping<ContactDetail> mapping)
        {
            mapping.References(x => x.PhysicalAddress).Cascade.SaveUpdate();
            mapping.References(x => x.PostalAddress).Cascade.SaveUpdate();
        }
    }
}