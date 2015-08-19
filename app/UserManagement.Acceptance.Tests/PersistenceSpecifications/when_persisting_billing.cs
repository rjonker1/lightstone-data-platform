using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_billing : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Billing>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.LegalEntityName, "LegalEntityName")
                .CheckProperty(c => c.AccountContactName, "AccountContactName")
                .CheckProperty(c => c.CompanyRegistration, "CompanyRegistration")
                .CheckProperty(c => c.DebitOrderDate, DateTime.Now.Date)
                .CheckProperty(c => c.PastelId, "PastelId")
                .CheckProperty(c => c.VatNumber, "VatNumber")
                .CheckProperty(c => c.PaymentType, PaymentType.Eft)
                .VerifyTheMappings();
        }
    }
}