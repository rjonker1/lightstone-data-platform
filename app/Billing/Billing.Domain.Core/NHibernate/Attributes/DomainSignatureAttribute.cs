using System;

namespace Billing.Domain.Core.NHibernate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DomainSignatureAttribute : Attribute
    {

    }
}