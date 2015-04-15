using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class UserMappingOverride : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            instance.DiscriminatorValue("User");
        }
    }
}