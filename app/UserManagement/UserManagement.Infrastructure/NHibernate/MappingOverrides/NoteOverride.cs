using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class NoteOverride : IAutoMappingOverride<Note>
    {
        public void Override(AutoMapping<Note> mapping)
        {
            mapping.References(x => x.User).Cascade.SaveUpdate();
            //mapping.Map(x => x.NoteText).Length(256);
        }
    }
}