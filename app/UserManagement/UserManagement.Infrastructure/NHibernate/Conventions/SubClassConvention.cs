using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class SubClassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Key.ForeignKey(string.Format("{0}_Subclass_FK", instance.EntityType.Name));
        }
    }
}