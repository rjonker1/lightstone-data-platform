using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerNoteOverride : IAutoMappingOverride<CustomerNote>
    {
        public void Override(AutoMapping<CustomerNote> mapping)
        {
            mapping.References(x => x.Customer).Cascade.SaveUpdate();
            mapping.References(x => x.Note).Cascade.SaveUpdate();
        }
    }
}