using System;

namespace PackageBuilder.Core.NHibernate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DomainSignatureAttribute : Attribute
    {
        
    }
}