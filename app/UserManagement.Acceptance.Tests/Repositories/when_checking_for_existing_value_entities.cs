using System;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.Repositories
{
    public class when_checking_for_existing_value_entities : TestDataBaseHelper
    {
        private IValueEntityRepository<Role> _repository;
        private Guid _id = Guid.NewGuid();
        public override void Observe()
        {
            RefreshDb();
            _repository = new ValueEntityRepository<Role>(Session);
            SaveAndFlush(new Role { Id = _id, Value = "Admin" });
        }

        [Observation]
        public void should_return_true_if_exists()
        {
            _repository.Exists(Guid.NewGuid(), "Admin").ShouldBeTrue();
        }

        [Observation]
        public void should_return_false_if_not_exists()
        {
            _repository.Exists(_id, "Admin").ShouldBeFalse();
        }
    }
}