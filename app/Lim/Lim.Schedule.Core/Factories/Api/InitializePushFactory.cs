using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Dtos;
using Lim.Entities;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Factories.Api
{
    public class InitializePushFactory : AbstractInitilizationFactory<ApiInitializePushCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<InitializePushFactory>();
        private readonly IRepository _repository;

        public InitializePushFactory(IRepository repository)
        {
            _repository = repository;
        }

        public override void Init(ApiInitializePushCommand command)
        {

            if (!command.Packages.Any())
                return;

            command.Packages.ToList().ForEach(f =>
            {
                var packages = AutoMapper.Mapper.Map<List<PackageResponse>, List<PackageTransactionDto>>
                (_repository.Get<PackageResponse>(
                    w => w.PackageId == f.PackageId && w.ContractId == f.ContractId && w.CommitDate > GetDateRange(command.ConfigurationId)).ToList());

                if(!packages.Any())
                    return;

                Log.InfoFormat("Found {0} Package Responses for Package Id {1} on Contract {2} to Push using API", packages.Count, f.PackageId, f.ContractId);
                command.PackageTransactions.AddRange(packages);
            });

        }

        private DateTime GetDateRange(long configurationId)
        {
            var tracking = _repository.Find<IntegrationTracking>(w => w.Configuration.Id == configurationId);
            return tracking == null ? DateTime.Now.AddYears(-10) : tracking.MaxTransactionDate.AddSeconds(1);
        }
    }
}