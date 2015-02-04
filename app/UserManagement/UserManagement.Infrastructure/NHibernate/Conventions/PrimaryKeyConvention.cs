using FluentNHibernate.Conventions;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
            instance.UniqueKey(instance.EntityType.Name + "_PK_UK");
        }
    }
}