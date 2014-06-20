using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Billing.Domain
{
    public class InvoiceTransaction : Transaction
    {
        public InvoiceTransaction()
        {
        }

        public InvoiceTransaction(Guid id, DateTime date, PackageIdentifier package, RequestIdentifier request, UserIdentifier user)
            : base(id, date, package, request, user)
        {
        }
    }
}