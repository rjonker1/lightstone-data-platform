using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Meta
{
    public class when_persisting_new_account_meta : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Customer>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.AccountNumber, "CUS001")
                .CheckProperty(c => c.AccountOwner, "AccountOwner1")
                .CheckProperty(c => c.BillingType, "INTERNAL")
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "Customer 1")
                .CheckProperty(c => c.AccountType, 1)
                .CheckProperty(c => c.BankAccountName, "TCC 132")
                .CheckProperty(c => c.BillingAccountContactEmail, "")
                .CheckProperty(c => c.BillingAccountContactName, "")
                .CheckProperty(c => c.BillingAccountContactNumber, "")
                .CheckProperty(c => c.BillingCompanyRegistration, "")
                .CheckProperty(c => c.BillingDebitOrderAccountNumber, "")
                .CheckProperty(c => c.BillingDebitOrderAccountOwner, "")
                .CheckProperty(c => c.BillingDebitOrderBranchCode, "124598")
                .CheckProperty(c => c.BillingDebitOrderDate, "")
                .CheckProperty(c => c.BillingPastelId, "124598")
                .CheckProperty(c => c.BillingPaymentType, "DebitOrder")
                .CheckProperty(c => c.BillingVatNumber, "124598")
                .VerifyTheMappings();

            new PersistenceSpecification<Client>(Session)
               .CheckProperty(c => c.Id, Guid.NewGuid())
               .CheckProperty(c => c.AccountNumber, "CLIENT001")
               .CheckProperty(c => c.AccountOwner, "AccountOwner1")
               .CheckProperty(c => c.BillingPaymentType, "DebitOrder")
                .CheckProperty(c => c.BillingType, "INTERNAL")
               .CheckProperty(c => c.ClientId, Guid.NewGuid())
               .CheckProperty(c => c.ClientName, "Client 1")
                .CheckProperty(c => c.AccountType, 1)
                .CheckProperty(c => c.BankAccountName, "TCL 132")
                .CheckProperty(c => c.BillingAccountContactEmail, "")
                .CheckProperty(c => c.BillingAccountContactName, "")
                .CheckProperty(c => c.BillingAccountContactNumber, "")
                .CheckProperty(c => c.BillingCompanyRegistration, "")
                .CheckProperty(c => c.BillingDebitOrderAccountNumber, "")
                .CheckProperty(c => c.BillingDebitOrderAccountOwner, "")
                .CheckProperty(c => c.BillingDebitOrderBranchCode, "124598")
                .CheckProperty(c => c.BillingDebitOrderDate, "")
                .CheckProperty(c => c.BillingPastelId, "124598")
                .CheckProperty(c => c.BillingPaymentType, "DebitOrder")
                .CheckProperty(c => c.BillingVatNumber, "124598")
               .VerifyTheMappings();
        }
    }
}