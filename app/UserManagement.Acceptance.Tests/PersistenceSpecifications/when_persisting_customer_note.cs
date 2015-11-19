using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_customer_note : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<CustomerNote>(Session, new CustomEqualityComparer())
                .CheckReference(c => c.Entity, new Customer("Name"))
                .CheckReference(c => c.Note, new Note("NoteText"))
                .VerifyTheMappings();
        }
    }
}