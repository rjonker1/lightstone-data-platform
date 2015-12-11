using System;
using System.Linq;
using System.Text;
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
                var packages =
                    _repository.Get<PackageResponses>(
                        w => w.PackageId == f.PackageId && w.ContractId == f.ContractId && w.CommitDate > GetDateRange(command.ConfigurationId) ).ToList();

                if (packages.Any())
                {
                    Log.InfoFormat("Found {0} Package Responses for Package Id {1} on Contract {2} to Push using API", packages.Count, f.PackageId,
                        f.ContractId);
                    command.PackageTransactions.AddRange(
                        packages.Select(
                            s =>
                                PackageTransactionDto.Set(s.PackageId, s.Userid, s.Username, s.ContractId, s.AccountNumber, s.ResponseDate,
                                    s.RequestId,
                                    GetPayload(s.Payload, s.HasResponse), s.HasResponse, s.CommitDate)));
                }
            });

        }

        private static string GetPayload(byte[] payload, bool hasResponse)
        {
            if (!hasResponse || payload == null || payload.Length == 0)
                return "[{'Error': 'Report could not be generated}]";

            return Encoding.UTF8.GetString(payload);
        }

        private DateTime GetDateRange(long configurationId)
        {
            var tracking = _repository.Find<IntegrationTracking>(w => w.Configuration.Id == configurationId);
            return tracking == null ? DateTime.Now.AddYears(-10) : tracking.MaxTransactionDate.AddSeconds(1);
        }
    }
}