using System;
using Billing.Domain.Core.Entities;
using Billing.Domain.Core.NHibernate;
using Billing.Domain.Core.NHibernate.Attributes;
using Billing.Domain.Entities;
using Billing.Infrastructure.NHibernate.Conventions;
using FluentNHibernate.Automapping;

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
            return AutoMap.AssemblyOf<PreBilling>(this)
                //.Where(type => type.IsSubclassOf(typeof (Entity)))
                //.IncludeBase<NamedEntity>()
                .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
                .OverrideAll(x => x.IgnoreProperties(member => member.MemberInfo.GetCustomAttributes(typeof(DoNotMapAttribute), false).Length > 0));
        }
    }
}