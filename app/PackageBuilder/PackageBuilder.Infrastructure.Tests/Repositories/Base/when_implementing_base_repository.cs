using System;
using System.Linq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.DbPersistence;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Infrastructure.Tests.Repositories.Base
{
    public class when_implementing_base_repository : when_persisting_entities_to_db
    {
        private IRepository<DataProvider> _repository;
        private Guid _id;
        public override void Observe()
        {
            base.Observe();

            _repository = new DataProviderRepository(Session);
            var dataProvider = ReadDataProviderMother.Ivid;
            _repository.Save(dataProvider);
            _repository.Save(ReadDataProviderMother.Audatex);

            Session.Flush();

            _id = GetFromDb(dataProvider).Id;
        }

        [Observation]
        public void should_save()
        {
            _repository.Count().ShouldEqual(2);
        }

        [Observation]
        public void should_get()
        {
            _repository.Get(_id).Name.ShouldEqual("Ivid");
        }
    }
}