using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class UniquePropertyConvention : AttributePropertyConvention<UniqueAttribute>
    {
        protected override void Apply(UniqueAttribute attribute, IPropertyInstance instance)
        {
            instance.UniqueKey(instance.EntityType.Name + "Unique");
        }
    }
}
