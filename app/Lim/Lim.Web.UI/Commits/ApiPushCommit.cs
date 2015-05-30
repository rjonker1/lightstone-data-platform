using System;
using System.Linq;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Contracts;
using Lim.Domain.Entities.Repository;
using Lim.Enums;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Commits
{
    public class ApiPushCommit : IPersistObject<PushConfiguration>
    {
        private readonly ISaveApiConfiguration _save;

        public ApiPushCommit(ISaveApiConfiguration save)
        {
            _save = save;
        }

        public bool Persist(PushConfiguration pushConfig)
        {
            var configuration = new Configuration()
            {
                Id = pushConfig.Id,
                IsActive = pushConfig.IsActive,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushConfig.User ?? Environment.MachineName,
                CustomFrequencyTime =
                    pushConfig.FrequencyType == (int) Frequency.Custom ? pushConfig.CustomFrequency.TimeOfDay : TimeSpan.Parse("00:00"),
                CustomFrequencyDay = pushConfig.FrequencyType == (int) Frequency.Custom ? pushConfig.CustomDay : null
            };

            var apiConfiguration = new ConfigurationApi()
            {
                Id = pushConfig.ConfigurationApiId,
                Configuration = configuration,
                BaseAddress = pushConfig.BaseAddress,
                Suffix = pushConfig.Suffix,
                Username = pushConfig.Username,
                Password = pushConfig.Password,
                HasAuthentication = pushConfig.HasAuthentication,
                AuthenticationToken = pushConfig.AuthenticationToken,
                AuthenticationKey = pushConfig.AuthenticationKey //,
                //AuthenticationType = pushConfig.AuthenticationType
            };

            var packages = pushConfig.IntegrationPackages.Select(s => new IntegrationPackage()
            {
                Id = 0,
                Configuration = configuration,
                PackageId = s,
                ContractId = pushConfig.SelectableDataPlatformClients.SelectMany(c => c.Contracts)
                    .FirstOrDefault(c => c.Packages.Select(p => p.PackageId).Contains(s)).ContractId,
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushConfig.User ?? Environment.MachineName
            }).ToList();

            var contracts = pushConfig.IntegrationContracts.Select(s => new IntegrationContract()
            {
                Id = 0,
                Configuration = configuration,
                Contract = s,
                ClientCustomerId =
                    pushConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.Contracts.Select(c => c.ContractId).Contains(s)).ClientCustomerId,
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushConfig.User ?? Environment.MachineName
            }).ToList();

            var clients = pushConfig.IntegrationClients.Select(s => new IntegrationClient()
            {
                Id = 0,
                Configuration = configuration,
                ClientCustomerId = s,
                AccountNumber = GetAccountNumber(pushConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.ClientCustomerId == s) != null ? pushConfig.SelectableDataPlatformClients.FirstOrDefault(w => w.ClientCustomerId == s).AccountNumber : string.Empty),
                IsActive = true,
                DateModified = DateTime.UtcNow,
                ModifiedBy = pushConfig.User ?? Environment.MachineName
            }).ToList();

            return _save.SaveConfiguration(pushConfig.ClientId, pushConfig.ActionType, pushConfig.FrequencyType, pushConfig.IntegrationType, pushConfig.AuthenticationType,
                configuration, apiConfiguration, packages, contracts, clients);
        }

        private static int GetAccountNumber(string accountNumber)
        {
            return !string.IsNullOrEmpty(accountNumber) ? int.Parse(string.Join("", accountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1;
        }
    }
}