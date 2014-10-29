using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.States.WriteModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.Industries.WriteModels
{
    public class when_persisting_a_state : when_persisting_entities
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
                .CheckProperty(c => c.Name, "Name")
                .VerifyTheMappings();
        }
    }
}