using System;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.Packages
{
    public class when_querying_packages : MemoryTestDataBaseHelper
    {
        private readonly Guid _id;
        private readonly PackageRepository _repository;

        public when_querying_packages()
        {
            RefreshDb();

            var state = StateMother.Published;
            SaveAndFlush(state);
            _id = Guid.NewGuid();
            Session.Save(new ReadPackageMother(_id, state).VVi);
            Session.Save(new ReadPackageMother(_id, state).VVi);
            Session.Save(new ReadPackageMother(state).VLi);
            Session.Flush();

            _repository = new PackageRepository(Session);
        }

        public override void Observe()
        {
            
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