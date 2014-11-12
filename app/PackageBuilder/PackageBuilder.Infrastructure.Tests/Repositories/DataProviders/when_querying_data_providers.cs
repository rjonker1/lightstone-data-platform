using System;
using DataPlatform.Shared.Enums;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.DbPersistence;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Infrastructure.Tests.Repositories.DataProviders
{
    public class when_querying_data_providers : when_persisting_entities_to_db
    {
        private DataProviderRepository _repository;
        public override void Observe()
        {
            base.Observe();

            SaveAndFlush(ReadDataProviderMother.Ivid, ReadDataProviderMother.Rgt);

            _repository = new DataProviderRepository(Session);
        }

        [Observation]
        public void should_return_true_if_industry_exists()
        {
            _repository.Exists(Guid.NewGuid(), DataProviderName.Ivid).ShouldBeTrue();
        }
    }
}