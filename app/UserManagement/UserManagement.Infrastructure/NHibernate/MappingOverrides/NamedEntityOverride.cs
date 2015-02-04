using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Cfg;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class NamedEntityOverride : IAutoMappingOverride<NamedEntity>
    {
        public void Override(AutoMapping<NamedEntity> mapping)
        {
            //mapping.Polymorphism.Implicit();
        }
    }
}