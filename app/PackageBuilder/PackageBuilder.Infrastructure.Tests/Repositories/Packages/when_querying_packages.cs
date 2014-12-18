using System;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Infrastructure.Tests.Repositories.Packages
{
    public class when_querying_packages : when_persisting_entities_to_memory
    {
        private Guid _id;
        private PackageRepository _repository;
        public override void Observe()
        {
            base.Observe();

            var state = StateMother.Published;
            SaveAndFlush(state);
            _id = Guid.NewGuid();
            Session.Save(new ReadPackageMother(_id, state).VVi);
            Session.Save(new ReadPackageMother(_id, state).VVi);
            Session.Save(new ReadPackageMother(state).VLi);
            Session.Flush();

            _repository = new PackageRepository(Session);
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), "VVi").ShouldBeTrue();
        }

        [Observation]
        public void should_return_true_if_has_published_versions()
        {
            _repository.HasPublishedVersions(_id).ShouldBeTrue();
        }

        [Observation]
        public void should_return_all_versions()
        {
            _repository.GetAllVersions(_id).ShouldNotBeEmpty();
        }
    }
}