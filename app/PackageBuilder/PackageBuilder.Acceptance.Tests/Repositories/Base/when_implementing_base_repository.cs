using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Read;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.Base
{
    public class when_implementing_base_repository : TestDataBaseHelper
    {
        private readonly IRepository<DataProvider> _repository;
        private readonly Guid _id;

        public when_implementing_base_repository() 
        {
            RefreshDb();

            _repository = new DataProviderRepository(Session);
            var dataProvider = ReadDataProviderMother.Ivid;
            _repository.Save(dataProvider);
            _repository.Save(ReadDataProviderMother.Rgt);

            Session.Flush();

            _id = GetFromDb(dataProvider).Id;
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void should_save()
        {
            _repository.Count().ShouldEqual(2);
        }

        [Observation]
        public void should_get()
        {
            _repository.Get(_id).Name.ShouldEqual(DataProviderName.Ivid);
        }
    }
}