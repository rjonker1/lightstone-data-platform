using System;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests.ValueTypes
{
    public class when_persisting_escalation_type : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<EscalationType>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Value, "test")
                .VerifyTheMappings();
        }
    }
}