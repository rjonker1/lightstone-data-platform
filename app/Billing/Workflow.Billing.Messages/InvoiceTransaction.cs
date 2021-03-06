﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class InvoiceTransaction : Transaction
    {
        public InvoiceTransaction()
        {
        }

        public InvoiceTransaction(Guid id, DateTime date, PackageIdentifier package, RequestIdentifier request, UserIdentifier user, StateIdentifier state, ContractIdentifier contract, AccountIdentifier account)
            : base(id, date, package, request, user, state, contract, account)
        {
        }
    }
}