using System;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.InMemoryPersistence;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Infrastructure.Tests.Repositories.Packages
{
    public class when_querying_packages : when_persisting_entities_to_memory
    {
        private PackageRepository _repository;
        public override void Observe()
        {
            base.Observe();

            var state = StateMother.Published;
            SaveAndFlush(state);
            Session.Save(new ReadPackageMother(state).VVi);
            Session.Save(new ReadPackageMother(state).VLi);
            Session.Flush();

            _repository = new PackageRepository(Session);
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), "VVi").ShouldBeTrue();
        }
    }
}