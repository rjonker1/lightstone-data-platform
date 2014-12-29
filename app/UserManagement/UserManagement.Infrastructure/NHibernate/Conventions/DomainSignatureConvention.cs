using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class DomainSignatureConvention : AttributePropertyConvention<DomainSignatureAttribute>
    {
        protected override void Apply(DomainSignatureAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(instance.EntityType.Name + "DomainSignature");
        }
    }
}
