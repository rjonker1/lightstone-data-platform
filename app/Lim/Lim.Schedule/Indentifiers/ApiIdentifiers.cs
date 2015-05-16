using System;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using Lim.Enums;
using Lim.Push.Models;
using Lim.Push.RestApi;
using Lim.Schedule.Commands;
using Lim.Schedule.Repositories;
using Newtonsoft.Json;

namespace Lim.Schedule.Indentifiers
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

        private Transaction _transaction;
        public void Get(IRepository repository)
        {
            //TOOD: Need to get from the repository
            //_transaction = repository.Get<Transaction>("", new {}).First();
            _transaction = new Transaction();
        }

        public void Push(AuditIntegrationCommand audit)
        {
            if (Configuration.Authentication.HasAuthentication)
            {
                var authenticationClient = new HttpPushClient<Transaction, string>(Configuration.BaseAddress, Configuration.Suffix,
                    Configuration.Authentication.AuthenticationKey, Configuration.Authentication.AuthenticationToken, GetAuthentication());

                authenticationClient.PostWithNoResponse(_transaction);
                authenticationClient.Dispose();
                audit.SetPayload(JsonConvert.SerializeObject(_transaction));
                return;
            }

            var client = new HttpPushClient<Transaction, string>(Configuration.BaseAddress, Configuration.Suffix);
            client.PostWithNoResponse(_transaction);
            client.Dispose();
            audit.SetPayload(JsonConvert.SerializeObject(_transaction));
        }

        private AuthenticationHeaderValue GetAuthentication()
        {
            return new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Configuration.Authentication.Username + ":" + Configuration.Authentication.Password)));
        }
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
