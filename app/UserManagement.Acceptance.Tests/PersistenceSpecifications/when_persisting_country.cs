﻿using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_country : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Country>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Value, "South Africa")
                .VerifyTheMappings();
        }
    }
}