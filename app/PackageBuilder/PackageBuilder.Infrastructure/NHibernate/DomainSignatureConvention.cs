using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using PackageBuilder.Core.NHibernate.Attributes;

namespace PackageBuilder.Infrastructure.NHibernate
{
    public class DomainSignatureConvention : AttributePropertyConvention<DomainSignatureAttribute>
    {
        protected override void Apply(DomainSignatureAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(instance.EntityType.Name + "DomainSignature");
        }
    }
}