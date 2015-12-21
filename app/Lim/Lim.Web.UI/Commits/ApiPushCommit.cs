using System;
using System.Linq;
using Lim.Domain.Base;
using Lim.Domain.Entities.Repository;
using Lim.Domain.Push;
using Lim.Entities;
using Lim.Enums;

namespace Lim.Web.UI.Commits
{
    public class ApiPushCommit : AbstractPersistenceRepository<PushApiDataPlatformConfiguration>
    {
        private readonly ISaveApiConfiguration _save;

        public ApiPushCommit(ISaveApiConfiguration save)
        {
            _save = save;
        }

        public override bool Persist(PushApiDataPlatformConfiguration pushApiDataPlatformConfig)
        {
            var configuration = new Configuration()
            {
                Id = pushApiDataPlatformConfig.Id,
                IsActive = pushApiDataPlatformConfig.IsActive,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushApiDataPlatformConfig.User ?? Environment.MachineName,
                CustomFrequencyTime =
                    pushApiDataPlatformConfig.FrequencyType == (int) Frequency.Custom ? pushApiDataPlatformConfig.CustomFrequency.TimeOfDay : TimeSpan.Parse("00:00"),
                CustomFrequencyDay = pushApiDataPlatformConfig.FrequencyType == (int) Frequency.Custom ? pushApiDataPlatformConfig.CustomDay : null
            };

            var apiConfiguration = new ConfigurationApi()
            {
                Id = pushApiDataPlatformConfig.ConfigurationApiId,
                Configuration = configuration,
                BaseAddress = pushApiDataPlatformConfig.BaseAddress,
                Suffix = pushApiDataPlatformConfig.Suffix,
                Username = pushApiDataPlatformConfig.Username,
                Password = pushApiDataPlatformConfig.Password,
                HasAuthentication = pushApiDataPlatformConfig.HasAuthentication,
                AuthenticationToken = pushApiDataPlatformConfig.AuthenticationToken,
                AuthenticationKey = pushApiDataPlatformConfig.AuthenticationKey //,
                //AuthenticationType = pushConfig.AuthenticationType
            };

            var packages = pushApiDataPlatformConfig.IntegrationPackages.Select(s => new IntegrationPackage()
            {
                Id = 0,
                Configuration = configuration,
                PackageId = s,
                ContractId = pushApiDataPlatformConfig.SelectableDataPlatformClients.SelectMany(c => c.Contracts)
                    .FirstOrDefault(c => c.Packages.Select(p => p.PackageId).Contains(s)).ContractId,
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushApiDataPlatformConfig.User ?? Environment.MachineName
            }).ToList();

            var contracts = pushApiDataPlatformConfig.IntegrationContracts.Select(s => new IntegrationContract()
            {
                Id = 0,
                Configuration = configuration,
                Contract = s,
                ClientCustomerId =
                    pushApiDataPlatformConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.Contracts.Select(c => c.ContractId).Contains(s)).ClientCustomerId,
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushApiDataPlatformConfig.User ?? Environment.MachineName
            }).ToList();

            var clients = pushApiDataPlatformConfig.IntegrationClients.Select(s => new IntegrationClient()
            {
                Id = 0,
                Configuration = configuration,
                ClientCustomerId = s,
                AccountNumber = GetAccountNumber(pushApiDataPlatformConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.ClientCustomerId == s) != null ? pushApiDataPlatformConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.ClientCustomerId == s).AccountNumber : string.Empty),
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushApiDataPlatformConfig.User ?? Environment.MachineName
            }).ToList();

            return _save.SaveConfiguration(pushApiDataPlatformConfig.ClientId, pushApiDataPlatformConfig.ActionType, pushApiDataPlatformConfig.FrequencyType, pushApiDataPlatformConfig.IntegrationType, pushApiDataPlatformConfig.AuthenticationType,
                configuration, apiConfiguration, packages, contracts, clients);
        }

        private static int GetAccountNumber(string accountNumber)
        {
            return !string.IsNullOrEmpty(accountNumber) ? int.Parse(string.Join("", accountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1;
        }
    }
}