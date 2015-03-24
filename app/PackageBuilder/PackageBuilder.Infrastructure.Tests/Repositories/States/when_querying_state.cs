using System;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Infrastructure.Tests.Repositories.States
{
    public class when_querying_state : when_persisting_entities_to_memory
    {
        private StateRepository _repository;
        public override void Observe()
        {
            base.Observe();

            SaveAndFlush(StateMother.Draft, StateMother.Published);

            _repository = new StateRepository(Session);
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), StateName.Draft).ShouldBeTrue();
        }
    }
}