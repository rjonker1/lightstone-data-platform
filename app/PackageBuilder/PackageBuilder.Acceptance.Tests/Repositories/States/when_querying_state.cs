using System;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.States
{
    public class when_querying_state : MemoryTestDataBaseHelper
    {
        private StateRepository _repository;

        public override void Observe()
        {
            RefreshDb();

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