using Billing.Domain.Core.NHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Billing.Infrastructure.NHibernate.Conventions
{
    public class DomainSignatureConvention : AttributePropertyConvention<DomainSignatureAttribute>
    {
        protected override void Apply(DomainSignatureAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(instance.EntityType.Name + "DomainSignature");
        }
    }
}