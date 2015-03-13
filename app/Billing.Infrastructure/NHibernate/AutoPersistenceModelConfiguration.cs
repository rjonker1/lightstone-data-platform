using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Data;

namespace Billing.Infrastructure.NHibernate
{
    public class AutoPersistenceModelConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(Entity));
        }

        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            //return AutoMap.AssemblyOf<User>(this)
            //    //.Where(type => type.IsSubclassOf(typeof (Entity)))
            //    .IncludeBase<NamedEntity>() //todo: need to store duplicated Name column in NamedEntity
            //    .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
            //    .UseOverridesFromAssemblyOf<UserMappingOverride>()
            //    .OverrideAll(x => x.IgnoreProperties(member => member.MemberInfo.GetCustomAttributes(typeof(DoNotMapAttribute), false).Length > 0));

            return null;
        }
    }
}