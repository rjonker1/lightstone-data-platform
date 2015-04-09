using System;

namespace Workflow.Billing.Domain.NHibernate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DomainSignatureAttribute : Attribute
    {

    }
}