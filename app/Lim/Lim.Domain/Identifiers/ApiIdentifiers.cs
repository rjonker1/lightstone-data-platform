using System;
using System.Runtime.Serialization;
using Lim.Enums;

namespace Lim.Domain.Identifiers
{
    [DataContract]
    public class ApiIntegrationIdentifier
    {
        public ApiIntegrationIdentifier(Guid key, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier client, IntegrationPackageIdentifier packages)
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
            string password)
        {
            Username = username;
            Password = password;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
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
