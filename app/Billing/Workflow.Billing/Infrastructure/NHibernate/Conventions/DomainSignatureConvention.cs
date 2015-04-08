using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Workflow.Billing.Domain.NHibernate.Attributes;

namespace Workflow.Billing.Infrastructure.NHibernate.Conventions
{
    public class DomainSignatureConvention : AttributePropertyConvention<DomainSignatureAttribute>
    {
        protected override void Apply(DomainSignatureAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(instance.EntityType.Name + "DomainSignature");
        }
    }
}