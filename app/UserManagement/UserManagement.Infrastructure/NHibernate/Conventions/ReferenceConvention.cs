using System;
using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            if (Attribute.IsDefined(instance.Property.MemberInfo, typeof(RequiredAttribute)))
                instance.Not.Nullable();

            instance.ForeignKey(string.Format("{0}_{1}_{2}_FK", instance.EntityType.Name , instance.Class.Name, instance.Property.Name));
        }
    }
}
