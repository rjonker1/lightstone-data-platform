using System;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Billing.Domain
{
    public class InvoiceResponse : Response
    {
        public InvoiceResponse()
        {
        }

        public InvoiceResponse(Guid id, DateTime date, PackageIdentifier package, RequestIdentifier request,
            UserIdentifier user)
            : base(id, date, package, request, user)
        {
        }
    }
}