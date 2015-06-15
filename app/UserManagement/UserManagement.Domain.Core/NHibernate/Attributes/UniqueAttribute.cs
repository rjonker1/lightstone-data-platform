using System;

namespace UserManagement.Domain.Core.NHibernate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UniqueAttribute : Attribute
    {

    }
}
