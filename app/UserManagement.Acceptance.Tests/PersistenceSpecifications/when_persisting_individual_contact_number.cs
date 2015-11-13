using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_individual_contact_number : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<IndividualContactNumber>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckReference(c => c.Individual, new Individual("Name", "Surname", "IdNumber"))
                .CheckProperty(c => c.ContactNumber, "082123456")
                .CheckProperty(c => c.ContactNumberType, ContactNumberType.Work)
                .VerifyTheMappings();
        }
    }
}