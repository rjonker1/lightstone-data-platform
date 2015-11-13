using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using PackageBuilder.Domain.Entities.CommandStore;

namespace PackageBuilder.Infrastructure.NHibernate.MappingOverrides
{
    public class CommandMappingOverride : IAutoMappingOverride<Command>
    {
        public void Override(AutoMapping<Command> mapping)
        {
            mapping.SchemaAction.All();
            mapping.Schema("PackageBuilderCommandStore.dbo"); //todo refactor
            mapping.Map(x => x.CommandData).Length(int.MaxValue);
        }
    }
}