﻿using System;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_contact_detail : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address("Type", "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Type", "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            new PersistenceSpecification<ContactDetail>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.LegalEntityName, "LegalEntityName")
                .CheckProperty(c => c.AccountsContactName, "AccountsContactName")
                .CheckProperty(c => c.EmailAddress, "EmailAddress")
                .CheckProperty(c => c.TelephoneNumber, "TelephoneNumber")
                .CheckReference(c => c.PhysicalAddress, physicalAddress)
                .CheckReference(c => c.PostalAddress, postalAddress)
                .VerifyTheMappings();
        }
    }
}