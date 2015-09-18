using System;
using System.Runtime.Serialization;
using Common.Logging;
using Lim.Core;
using Lim.Enums;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiPushIntegration
    {
        private readonly ILog _log = LogManager.GetLogger<ApiPushIntegration>();
        public readonly IPush<ApiInitializePushCommand> Pusher;
        public ApiPushIntegration(Guid key, long configurationId, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier integrationClient, IntegrationContractIdentifier integrationContract,
            IntegrationPackageIdentifier packages, ClientIdentifier client, IPush<ApiInitializePushCommand> pusher)
        {
            Key = key;
            ConfigurationId = configurationId;
            Configuration = configuration;
            IntegrationClient = integrationClient;
            IntegrationContract = integrationContract;
            Packages = packages;
            Client = client;
            Pusher = pusher;
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

        [DataMember]
        public ApiInitializePushCommand Command
        {
            get { return new ApiInitializePushCommand(Packages.Packages,(AuthenticationType)Configuration.Authentication.AuthenticationType.Id, Audit,Configuration,ConfigurationId); }
        }

        [DataMember]
        public AuditIntegrationCommand Audit
        {
            get
            {
                return new AuditIntegrationCommand(Client.ClientId, ConfigurationId, DateTime.UtcNow, (short) IntegrationAction.Push,
                    (short) IntegrationType.Api,
                    Configuration.BaseAddress, Configuration.Suffix);
            }
        }
    }
}