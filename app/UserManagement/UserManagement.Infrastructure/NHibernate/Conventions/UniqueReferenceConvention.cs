using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class UniqueReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            var p = instance.Property.MemberInfo;
            if (Attribute.IsDefined(p, typeof (UniqueAttribute)))
                instance.UniqueKey(instance.EntityType.Name + "Unique");
        }
    }
}