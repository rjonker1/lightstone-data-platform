using System;
using System.Collections.Generic;
using Lim.Core;
using Lim.Domain.Entities.Repository;
using Lim.Dtos;
using Lim.Entities;
using Lim.Enums;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Factories.Api;
using Lim.Schedule.Core.Identifiers;
using Xunit.Extensions;
using AuthenticationType = Lim.Enums.AuthenticationType;

namespace Lim.Acceptance.Tests.Integrations.Push
{
    public class when_initializing_api_push_factory_for_package_responses : AbstractTest
    {
        private readonly IInitialize<ApiInitializePushCommand> _pusher;
        private readonly IRepository _repository;
        private ApiInitializePushCommand _command;

        public when_initializing_api_push_factory_for_package_responses()
        {
            _repository = new LimRepository();
            _pusher = new InitializePushFactory(_repository);
        }

        public override void Observe()
        {
            var packages = AutoMapper.Mapper.Map<IEnumerable<IntegrationPackage>, IEnumerable<IntegrationPackageDto>>(
                _repository.Get<IntegrationPackage>(w => w.IsActive));
            _command = new ApiInitializePushCommand(packages, AuthenticationType.Basic,
                new AuditIntegrationCommand(1, 1, DateTime.Now, (short) IntegrationAction.Push, (short)Enums.IntegrationType.Api, "", ""), ApiConfigurationIdentifier.Empty(),1);
            _pusher.Init(_command);
        }

        [Observation]
        public void then_package_transactions_should_exist()
        {
            _command.PackageTransactions.ShouldNotBeNull();
            _command.PackageTransactions.Count.ShouldNotEqual(0);
        }
    }
}
