using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lim.Domain.Push
{
    [DataContract]
    public class PushConfigurationView
    {
        private PushConfigurationView(long id, long apiConfigurationId, Guid key, long clientId, string clientName, short frequencyType, short actionType,
            short integrationType, IEnumerable<Guid> integrationClients, IEnumerable<Guid> integrationContracts,
            DateTime? dateCreated, bool isActive, string baseAddress, string suffix, string userName, string password,
            bool hasAuthentication, string authenticationKey, string authenticationToken, short authenticationType,
            IEnumerable<Guid> packages, TimeSpan? customTime, string customDay)
        {
            Id = id;
            ApiConfigurationId = apiConfigurationId;
            Key = key;
            ClientId = clientId;
            ClientName = clientName;
            FrequencyType = frequencyType;
            ActionType = actionType;
            IntegrationType = integrationType;
            IntegrationClients = integrationClients;
            IntegrationContracts = integrationContracts;
            DateCreated = dateCreated;
            IsActive = isActive;
            BaseAddress = baseAddress;
            Suffix = suffix;
            Username = userName;
            Password = password;
            HasAuthentication = hasAuthentication;
            AuthenticationKey = authenticationKey;
            AuthenticationToken = authenticationToken;
            AuthenticationType = authenticationType;
            IntegrationPackages = packages;
            CustomFrequencyTime = customTime;
            CustomFrequencyDay = customDay;
        }

        public static PushConfigurationView Set(long id, long apiConfigurationId, Guid key, long clientId, string clientName, short frequencyType, short actionType,
            short integrationType, IEnumerable<Guid> integrationClients, IEnumerable<Guid> integrationContracts,
            DateTime? dateCreated, bool isActive, string baseAddress, string suffix, string userName, string password,
            bool hasAuthentication,string authenticationKey, string authenticationToken, short authenticationType,
            IEnumerable<Guid> packages, TimeSpan? customTime, string customDay)
        {
            return new PushConfigurationView(id, apiConfigurationId, key, clientId, clientName, frequencyType, actionType, integrationType, integrationClients,
                integrationContracts, dateCreated, isActive, baseAddress, suffix, userName, password, hasAuthentication,authenticationKey,
                authenticationToken, authenticationType, packages, customTime, customDay);
        }
        
        [DataMember]
        public long Id { get;  private set;}

        [DataMember]
        public long ApiConfigurationId { get; private set; }

        [DataMember]
        public Guid Key { get;  private set;}

        [DataMember]
        public long ClientId { get;  private set;}

        [DataMember]
        public string ClientName { get;  private set;}

        [DataMember]
        public short FrequencyType { get;  private set;}

        [DataMember]
        public short ActionType { get;  private set;}

        [DataMember]
        public short IntegrationType { get;  private set;}
     
        [DataMember]
        public IEnumerable<Guid> IntegrationClients { get; private set; }

        [DataMember]
        public IEnumerable<Guid> IntegrationContracts { get; private set; }

        [DataMember]
        public DateTime? DateCreated { get;  private set;}

        [DataMember]
        public bool IsActive { get;  private set;}

        [DataMember]
        public string BaseAddress { get;  private set;}

        [DataMember]
        public string Suffix { get;  private set;}

        [DataMember]
        public string Username { get;  private set;}

        [DataMember]
        public string Password { get;  private set;}

        [DataMember]
        public bool HasAuthentication { get;  private set;}

        [DataMember]
        public string AuthenticationToken { get;  private set;}

        [DataMember]
        public string AuthenticationKey { get;  private set;}

        [DataMember]
        public short AuthenticationType { get;  private set;}

        [DataMember]
        public IEnumerable<Guid> IntegrationPackages { get; private set; }
        [DataMember]
        public TimeSpan? CustomFrequencyTime { get;  private set;}
        [DataMember]
        public string CustomFrequencyDay { get;  private set;}
    }
}