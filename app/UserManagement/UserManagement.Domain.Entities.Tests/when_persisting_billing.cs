using System;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_billing : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Billing>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.ContactNumber, "BillingContactNumber")
                .CheckProperty(c => c.ContractPerson, "BillingContractPerson")
                .CheckProperty(c => c.CompanyRegistration, "CompanyRegistration")
                .CheckProperty(c => c.DebitOrderDate, DateTime.Now.Date)
                .CheckProperty(c => c.PastelId, "PastelId")
                .CheckProperty(c => c.VatNumber, "VatNumber")
                .CheckReference(c => c.PaymentType, new PaymentType("PaymentType"))
                .VerifyTheMappings();
        }
    }
}