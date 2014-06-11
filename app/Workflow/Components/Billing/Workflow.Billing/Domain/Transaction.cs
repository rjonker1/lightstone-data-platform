using System;
using DataPlatform.Shared.Public.Identifiers;

namespace Workflow.Billing.Domain
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(Guid id, DateTime date, PackageIdentifier package, RequestIdentifier request, UserIdentifier user)
        {
            Id = id;
            Date = date;
            Package = package;
            Request = request;
            User = user;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public PackageIdentifier Package { get; private set; }
        public RequestIdentifier Request { get; private set; }
        public UserIdentifier User { get; private set; }
    }
}