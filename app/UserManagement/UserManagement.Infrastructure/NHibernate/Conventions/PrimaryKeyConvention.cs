using FluentNHibernate.Conventions;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            if (instance.EntityType.BaseType != typeof (IntEntity))
                instance.GeneratedBy.Assigned();
            instance.UniqueKey(instance.EntityType.Name + "_PK_UK");
        }
    }
}