using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Push.RestApi;
using Lim.Schedule.Core.Commands;
using Newtonsoft.Json;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiPushIntegration
    {
        private readonly ILog _log = LogManager.GetLogger<ApiPushIntegration>();
        public ApiPushIntegration(Guid key, long configurationId, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier integrationClient, IntegrationContractIdentifier integrationContract,
            IntegrationPackageIdentifier packages, ClientIdentifier client)
        {
            Key = key;
            ConfigurationId = configurationId;
            Configuration = configuration;
            IntegrationClient = integrationClient;
            IntegrationContract = integrationContract;
            Packages = packages;
            Client = client;
        }

        private readonly IDictionary<Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>> _pushClients = new Dictionary
            <Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>>()
        {
            {
                Enums.AuthenticationType.Basic, (configuration) =>
                    PushClient.PushWithBasic(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                        configuration.Authentication.AuthenticationToken, configuration.Authentication.Username, configuration.Authentication.Password)
            },
            {Enums.AuthenticationType.None, (configuration) => PushClient.Push(configuration.BaseAddress, configuration.Suffix)},
            {
                Enums.AuthenticationType.Stateless, (configuration) =>
                    PushClient.PushWithStateless(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                        configuration.Authentication.AuthenticationToken)
            }
        };

     

        private static string GetPayload(byte[] payload, bool hasResponse)
        {
            if (!hasResponse || payload == null || payload.Length == 0)
                return "[{'Error': 'Report could not be generated}]";

            return Encoding.UTF8.GetString(payload);
        }

        public void Get(IRepository repository, DateTime dateRange)
        {
            _transaction = new List<PackageTransactionDto>();
            if (!Packages.Packages.Any())
                return;

            Packages.Packages.ToList().ForEach(f =>
            {
                var packages = repository.Get<PackageResponses>(w => w.PackageId == f.PackageId && w.ContractId == f.ContractId && w.CommitDate > dateRange).ToList();

                if (packages.Any())
                {
                    _log.InfoFormat("Found {0} Package Responses for Package Id {1} on Contract {2} to Push using API", packages.Count, f.PackageId,
                        f.ContractId);
                    _transaction.AddRange(
                        packages.Select(
                            s =>
                                PackageTransactionDto.Set(s.PackageId, s.Userid, s.Username, s.ContractId, s.AccountNumber, s.ResponseDate,
                                    s.RequestId,
                                    GetPayload(s.Payload, s.HasResponse), s.HasResponse, s.CommitDate)));
                }
            });

        }

        public void Push(AuditIntegrationCommand audit, ILog log)
        {
            if (!_transaction.Any())
                return;

            var client = _pushClients.FirstOrDefault(w => w.Key == (Enums.AuthenticationType)Configuration.Authentication.AuthenticationType.Id);
            if (client.Value == null)
                throw new Exception(string.Format("Push Client for Authentication Type {0} could not be found", Configuration.Authentication.AuthenticationType.Type));
            foreach (var packageTransaction in _transaction)
            {
                try
                {
                    client.Value(Configuration).Post(packageTransaction);
                    audit.SetPayload(JsonConvert.SerializeObject(packageTransaction), true, packageTransaction.CommitDate);
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("An error occurred executing API configuration because of {0}", ex, ex.Message);
                    audit.SetPayload(JsonConvert.SerializeObject(packageTransaction), false, DateTime.MinValue);
                }
            }
        }

        public long GetTransactionCount()
        {
            return _transaction.Count;
        }


        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public long ConfigurationId { get; private set; }

        [DataMember]
        public ApiConfigurationIdentifier Configuration { get; private set; }

        [DataMember]
        public ClientIdentifier Client { get; private set; }

        [DataMember]
        public IntegrationClientIdentifier IntegrationClient { get; private set; }

        [DataMember]
        public IntegrationContractIdentifier IntegrationContract { get; private set; }

        [DataMember]
        public IntegrationPackageIdentifier Packages { get; private set; }

        [DataMember] private List<PackageTransactionDto> _transaction;
    }
}