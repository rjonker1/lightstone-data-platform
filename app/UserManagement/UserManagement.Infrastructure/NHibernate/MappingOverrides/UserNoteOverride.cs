using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class UserNoteOverride : IAutoMappingOverride<UserNote>
    {
        public void Override(AutoMapping<UserNote> mapping)
        {
            mapping.References(x => x.Entity).Column("UserId").Cascade.SaveUpdate();
            mapping.References(x => x.Note).Cascade.SaveUpdate();
        }
    }
}