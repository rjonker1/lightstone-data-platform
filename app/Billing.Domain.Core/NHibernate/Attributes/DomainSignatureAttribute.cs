using System;

namespace Billing.Domain.Core.NHibernate
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DomainSignatureAttribute : Attribute
    {

    }
}