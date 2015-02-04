using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class ManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Key.ForeignKey(string.Format("{0}_{1}_{2}_FK", instance.EntityType.Name, instance.ChildType.Name, instance.Member.Name));
            instance.Relationship.ForeignKey(string.Format("{0}_{1}_{2}_RelFK", instance.EntityType.Name, instance.ChildType.Name, instance.Member.Name));
        }
    }
}