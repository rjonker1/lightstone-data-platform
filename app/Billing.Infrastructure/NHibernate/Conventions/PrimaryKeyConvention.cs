using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Billing.Infrastructure.NHibernate.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
            instance.UniqueKey(instance.EntityType.Name + "_PK_UK");
        }
    }
}