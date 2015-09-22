using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.PersistenceSpecifications.States.Read
{
    public class when_persisting_a_state : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist_state()
        {
            new PersistenceSpecification<State>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Name, StateName.Published)
                .CheckProperty(c => c.Alias, StateName.Published.ToString())
                .VerifyTheMappings();
        }
    }
}