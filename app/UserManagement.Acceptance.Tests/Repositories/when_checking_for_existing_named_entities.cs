using System;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.Repositories
{
    public class when_checking_for_existing_named_entities : TestDataBaseHelper
    {
        private INamedEntityRepository<Client> _repository;
        private Guid _id = Guid.NewGuid();
        public override void Observe()
        {
            RefreshDb(false);
            _repository = new NamedEntityRepository<Client>(Session);
            SaveAndFlush(new Client { Id = _id, Name = "Test Client" });
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), "Test Client").ShouldBeTrue();
        }

        [Observation]
        public void should_return_false_if_not_exists()
        {
            _repository.Exists(_id, "Test Client").ShouldBeFalse();
        }
    }
}