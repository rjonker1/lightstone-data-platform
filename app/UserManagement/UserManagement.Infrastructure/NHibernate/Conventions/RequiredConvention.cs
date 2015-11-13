using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class RequiredConvention : AttributePropertyConvention<RequiredAttribute>
    {
        protected override void Apply(RequiredAttribute attribute, IPropertyInstance instance)
        {
            instance.Not.Nullable();
        }
    }
}
