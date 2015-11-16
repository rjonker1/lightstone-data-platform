using System;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Moq;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Unit.Tests
{
    public class when_mapping_id_to_entity : BaseTestHelper
    {
        private readonly Mock<IRepository<User>> _repository = new Mock<IRepository<User>>();
        private readonly Guid _id = Guid.NewGuid();
        private readonly User _channel;

        public when_mapping_id_to_entity()
        {
            _repository.Setup(r => r.Get(It.IsAny<Guid>())).Returns(() => new User { Id = _id });

            Container.Register(Component.For<IRepository<User>>().Instance(_repository.Object));

            _channel = Mapper.Map<Guid, User>(_id);
        }

        public override void Observe()
        {
        }

        [Observation]
        public void should_map()
        {
            _channel.ShouldNotBeNull();
            _channel.Id.ShouldEqual(_id);
            //_channel.SystemId.ShouldEqual(_systemId);
        }
    }
}