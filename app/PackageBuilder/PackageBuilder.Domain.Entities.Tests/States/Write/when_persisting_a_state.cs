using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.States.Write
{
    public class when_persisting_a_state : when_persisting_entities_to_memory
    {
        public override void Observe()
        {
            base.Observe();
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