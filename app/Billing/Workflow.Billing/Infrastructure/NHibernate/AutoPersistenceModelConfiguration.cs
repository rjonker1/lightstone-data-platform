using System;
using Billing.Domain.Entities.DemoEntities;
using FluentNHibernate.Automapping;
using Shared.Messaging.Billing.Helpers;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Domain.NHibernate.Attributes;
using Workflow.Billing.Helpers.AutoMapper.MappingOverrides;
using Workflow.Billing.Infrastructure.NHibernate.Conventions;

namespace Workflow.Billing.Infrastructure.NHibernate
{
    public class AutoPersistenceModelConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(Entity));
        }

        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<UserMeta>(this)
                //.AddEntityAssembly(typeof(Customer).Assembly)
                .IgnoreBase<Entity>()
                .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
                //.UseOverridesFromAssemblyOf<PreBillingMappingOverride>()
                .UseOverridesFromAssemblyOf<BillingMappingOverride>()
                .OverrideAll(x => x.IgnoreProperties(member => member.MemberInfo.GetCustomAttributes(typeof(DoNotMapAttribute), false).Length > 0));
        }
    }
}