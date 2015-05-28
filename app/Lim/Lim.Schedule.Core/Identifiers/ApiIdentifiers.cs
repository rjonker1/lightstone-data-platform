﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lim.Domain.Models;
using Lim.Domain.Repository;
using Lim.Enums;
using Lim.Push.RestApi;
using Lim.Schedule.Core.Commands;
using Newtonsoft.Json;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiPullIntegration
    {
        public ApiPullIntegration(Guid key, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier client)
        {
            Key = key;
            Configuration = configuration;
            Client = client;
        }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public ApiConfigurationIdentifier Configuration { get; private set; }

        [DataMember]
        public IntegrationClientIdentifier Client { get; private set; }
    }


    [DataContract]
    public class ApiPushIntegration
    {
        public ApiPushIntegration(Guid key, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier client,
            IntegrationPackageIdentifier packages)
        {
            Key = key;
            Configuration = configuration;
            Client = client;
            Packages = packages;
        }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public ApiConfigurationIdentifier Configuration { get; private set; }

        [DataMember]
        public IntegrationClientIdentifier Client { get; private set; }

        [DataMember]
        public IntegrationPackageIdentifier Packages { get; private set; }

        [DataMember] private List<PackageTransaction> _transaction;

        public void Get(ILimRepository repository)
        {
            _transaction = new List<PackageTransaction>();
            if (!Packages.PackageIds.Any())
                return;

            Packages.PackageIds.ToList().ForEach(f =>
            {
                var response =
                    repository.Items<PackageResponse>(PackageResponse.SelectStatement, new {@PackageId = f, @ContractId = Client.ClientId}).ToList();
                if (response.Any())
                {
                    _transaction.AddRange(
                        response.Select(
                            s =>
                                new PackageTransaction(s.PackageId, s.UserId, s.Username, s.ContractId, s.AccountNumber, s.ResponseDate, s.RequestId,
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

            client.Value(Configuration).Post(_transaction);
            audit.SetPayload(JsonConvert.SerializeObject(_transaction));
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

        [DataMember]
        public ApiFrequencyIdentifier Frequency { get; private set; }

    }

    [DataContract]
    public class ApiFrequencyIdentifier
    {
        public ApiFrequencyIdentifier(int seconds, int minutes, int hours, string dayOfMonth, Month month, WeekDay dayOfWeek, Frequency frequency)
        {
            Seconds = seconds;
            Minutes = minutes;
            Hours = hours;
            DayOfMonth = dayOfMonth;
            Month = month;
            DayofWeek = dayOfWeek;
            Frequency = frequency;
        }

        [DataMember]
        public int Seconds { get; private set; }
        [DataMember]
        public int Minutes { get; private set; }
        [DataMember]
        public int Hours { get; private set; }
        [DataMember]
        public string DayOfMonth { get; private set; }
        [DataMember]
        public Month Month { get; private set; }
        [DataMember]
        public WeekDay DayofWeek { get; private set; }
        [DataMember]
        public Frequency Frequency { get; private set; }
    }
}