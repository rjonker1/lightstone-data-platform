using FluentNHibernate.Conventions;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            if (instance.EntityType != typeof (CustomerAccountNumber))
                instance.GeneratedBy.Assigned();
            instance.UniqueKey(instance.EntityType.Name + "_PK_UK");
        }
    }
}