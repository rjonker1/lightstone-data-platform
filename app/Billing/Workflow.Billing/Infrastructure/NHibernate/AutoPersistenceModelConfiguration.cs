using System;
using Billing.Domain.Entities.DemoEntities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
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
            //var isStatic = type.IsAbstract && type.IsSealed;
            //return type.Namespace == typeof (Domain.Entities.Billing).Namespace && !isStatic;
        }

        public override bool IsDiscriminated(Type type)
        {
            //return true;
            if (type.IsSubclassOf(typeof(Domain.Entities.Billing)))
            {
                return true;
            }

            return false;
        }

        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<UserMeta>(this)
                //.AddEntityAssembly(typeof(Customer).Assembly)
                .IgnoreBase<Entity>()
                .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
                .Conventions.Add<SubclassConvention>()
                .UseOverridesFromAssemblyOf<BillingMappingOverride>()
                .OverrideAll(x => x.IgnoreProperties(member => member.MemberInfo.GetCustomAttributes(typeof(DoNotMapAttribute), false).Length > 0));
        }
    }

    public class SubclassConvention : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            // Use the short name of the type, not the full name
            instance.DiscriminatorValue(instance.EntityType.Name);
        }
    }
}