using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.DataProviders
{
    public class when_querying_data_providers : TestDataBaseHelper
    {
        private DataProviderRepository _repository;

        public override void Observe()
        {
            RefreshDb();

            SaveAndFlush(ReadDataProviderMother.Ivid, ReadDataProviderMother.Rgt);

            _repository = new DataProviderRepository(Session);
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), DataProviderName.IVIDVerify_E_WS).ShouldBeTrue();
        }
    }
}