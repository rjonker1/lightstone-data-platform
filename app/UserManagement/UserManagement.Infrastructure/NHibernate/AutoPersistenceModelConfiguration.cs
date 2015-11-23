using System;
using FluentNHibernate.Automapping;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.NHibernate.Conventions;
using UserManagement.Infrastructure.NHibernate.MappingOverrides;

namespace UserManagement.Infrastructure.NHibernate
{
    public class AutoPersistenceModelConfiguration : DefaultAutomappingConfiguration
    {
       public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(Entity)) || type.IsSubclassOf(typeof(IntEntity));
        }

        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<User>(this)
                .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
                .UseOverridesFromAssemblyOf<UserOverride>()
                .OverrideAll(x => x.IgnoreProperties(member => member.MemberInfo.GetCustomAttributes(typeof(DoNotMapAttribute), false).Length > 0));
        }
    }
}