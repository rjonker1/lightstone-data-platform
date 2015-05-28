using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Repository;
using Lim.Push.RestApi;
using Lim.Schedule.Core.Commands;
using Newtonsoft.Json;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiPullIntegration
    {
        public ApiPullIntegration(Guid key, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier integrationClient)
        {
            Key = key;
            Configuration = configuration;
            IntegrationClient = integrationClient;
        }

        [DataMember]
        public Guid Key { get; private set; }


        [DataMember]
        public ApiConfigurationIdentifier Configuration { get; private set; }

        [DataMember]
        public IntegrationClientIdentifier IntegrationClient { get; private set; }
    }


    [DataContract]
    public class ApiPushIntegration
    {
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

        public void Get(IReadLimRepository repository, ILog log)
        {
            _transaction = new List<PackageTransactionDto>();
            if (!Packages.Packages.Any())
                return;

            Packages.Packages.ToList().ForEach(f =>
            {
                var response =
                    repository.Items<PackageResponseDto>(PackageResponseDto.SelectStatement, new {@PackageId = f.PackageId, @ContractId = f.ContractId})
                        .ToList();

                if (response.Any())
                {
                    log.InfoFormat("Found {0} Package Responses for Package Id {1} on Contract {2} to Push using API", response.Count, f.PackageId,
                        f.ContractId);
                    _transaction.AddRange(
                        response.Select(
                            s =>
                                new PackageTransactionDto(s.PackageId, s.UserId, s.Username, s.ContractId, s.AccountNumber, s.ResponseDate, s.RequestId,
                                    s.Payload, s.HasResponse)));
                }
            });

        }

        public void Push(AuditIntegrationCommand audit)
        {
            if (!_transaction.Any())
                return;

            var client = _pushClients.FirstOrDefault(w => w.Key == (Enums.AuthenticationType) Configuration.Authentication.AuthenticationType.Id);
            if(client.Value == null)
                throw new Exception(string.Format("Push Client for Authentication Type {0} could not be found", Configuration.Authentication.AuthenticationType.Type));
            foreach (var packageTransaction in _transaction)
            {
                client.Value(Configuration).Post(packageTransaction);
                audit.SetPayload(JsonConvert.SerializeObject(packageTransaction));
            }
            
        }

        private readonly IDictionary<Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>> _pushClients = new Dictionary
            <Enums.AuthenticationType, Func<ApiConfigurationIdentifier, PushClient>>()
        {
            {Enums.AuthenticationType.Basic, Basic},
            {Enums.AuthenticationType.None, Standard},
            {Enums.AuthenticationType.Stateless, Stateless}
        };

        private static readonly Func<ApiConfigurationIdentifier, PushClient> Standard =
            (configuration) => PushClient.Push(configuration.BaseAddress, configuration.Suffix);

        private static readonly Func<ApiConfigurationIdentifier, PushClient> Basic =
            (configuration) =>
                PushClient.PushWithBasic(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                    configuration.Authentication.AuthenticationToken, configuration.Authentication.Username, configuration.Authentication.Password);

        private static readonly Func<ApiConfigurationIdentifier, PushClient> Stateless =
            (configuration) =>
                PushClient.PushWithStateless(configuration.BaseAddress, configuration.Suffix, configuration.Authentication.AuthenticationKey,
                    configuration.Authentication.AuthenticationToken);
    }

    [DataContract]
    public class ApiAuthenticationTypeIdentifier
    {
        public ApiAuthenticationTypeIdentifier(int id, string type)
        {
            Type = type;
            Id = id;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Type { get; private set; }
    }

    [DataContract]
    public class ApiAuthenticationIdentifier
    {
        public ApiAuthenticationIdentifier(bool hasAuthentication, ApiAuthenticationTypeIdentifier authenticationType, string username,
            string password, string authenticationKey, string authenticationToken)
        {
            Username = username;
            Password = password;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
            AuthenticationKey = authenticationKey;
            AuthenticationToken = authenticationToken;
        }

        [DataMember]
        public bool HasAuthentication { get; private set; }

        [DataMember]
        public ApiAuthenticationTypeIdentifier AuthenticationType { get; private set; }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        [DataMember]
        public string AuthenticationKey { get; private set; }

        [DataMember]
        public string AuthenticationToken { get; private set; }
    }

    [DataContract]
    public class ApiConfigurationIdentifier
    {

        public ApiConfigurationIdentifier(string baseAddress, string suffix, ApiAuthenticationIdentifier authentication,
            IntegrationActionIdentifier action, IntegrationTypeIdentifier type)
        {
            BaseAddress = baseAddress;
            Suffix = suffix;
            Authentication = authentication;
            Action = action;
            Type = type;
        }

        [DataMember]
        public string BaseAddress { get; private set; }

        [DataMember]
        public string Suffix { get; private set; }

        [DataMember]
        public ApiAuthenticationIdentifier Authentication { get; private set; }

        [DataMember]
        public IntegrationActionIdentifier Action { get; private set; }

        [DataMember]
        public IntegrationTypeIdentifier Type { get; private set; }

        //[DataMember]
        //public ApiFrequencyIdentifier Frequency { get; private set; }

    }

    //[DataContract]
    //public class ApiFrequencyIdentifier
    //{
    //    public ApiFrequencyIdentifier(int seconds, int minutes, int hours, string dayOfMonth, Month month, WeekDay dayOfWeek, Frequency frequency)
    //    {
    //        Seconds = seconds;
    //        Minutes = minutes;
    //        Hours = hours;
    //        DayOfMonth = dayOfMonth;
    //        Month = month;
    //        DayofWeek = dayOfWeek;
    //        Frequency = frequency;
    //    }

    //    [DataMember]
    //    public int Seconds { get; private set; }
    //    [DataMember]
    //    public int Minutes { get; private set; }
    //    [DataMember]
    //    public int Hours { get; private set; }
    //    [DataMember]
    //    public string DayOfMonth { get; private set; }
    //    [DataMember]
    //    public Month Month { get; private set; }
    //    [DataMember]
    //    public WeekDay DayofWeek { get; private set; }
    //    [DataMember]
    //    public Frequency Frequency { get; private set; }
    //}
}
