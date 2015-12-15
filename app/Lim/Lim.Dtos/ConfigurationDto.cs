using System;
using System.Collections.Generic;

namespace Lim.Dtos
{
    public class ConfigurationDto
    {
        public ConfigurationDto()
        {

        }

        private ConfigurationDto(long id, Guid key, short actionType, short integrationType, short frequencyType, long clientId, bool isActive,
            string action, string frequency, string type, DateTime? dateCreated, TimeSpan? customFrequencyTime, string customFrequencyDay)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
            Id = id;
            ConfigurationKey = key;
            FrequencyType = frequencyType;
            ClientId = clientId;
            IsActive = isActive;
            Action = action;
            Frequency = frequency;
            Type = type;
            DateCreated = dateCreated;
            CustomFrequencyTime = customFrequencyTime;
            CustomFrequencyDay = customFrequencyDay;
        }

        public static ConfigurationDto Existing(long id, Guid key, short actionType, short integrationType, short frequencyType, long clientId,
            bool isActive, string action, string frequency, string type, DateTime? dateCreated, TimeSpan? customFrequencyTime, string customFrequencyDay)
        {
            return new ConfigurationDto(id, key, actionType, integrationType, frequencyType, clientId, isActive, action, frequency, type,dateCreated, customFrequencyTime, customFrequencyDay);
        }

        public ConfigurationDto WithPackages(List<IntegrationPackageDto> packages)
        {
            IntegrationPackages = packages;
            return this;
        }

        public ConfigurationDto WithClients(List<IntegrationClientDto> clients)
        {
            IntegrationClients = clients;
            return this;
        }


        public ConfigurationDto WithContracts(List<IntegrationContractDto> contracts)
        {
            IntegrationContracts = contracts;
            return this;
        }


        public long Id { get; private set; }
        public Guid ConfigurationKey { get; private set; }
        public short FrequencyType { get; set; }
        public short ActionType { get; set; }
        public short IntegrationType { get; set; }
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; private set; }
        public string Frequency { get; private set; }
        public string Type { get; private set; }
        public DateTime? DateCreated { get; private set; }
        public TimeSpan? CustomFrequencyTime { get; private set; }
        public string CustomFrequencyDay { get; private set; }
        public List<IntegrationPackageDto> IntegrationPackages { get; private set; }
        public List<IntegrationClientDto> IntegrationClients { get; private set; }
        public List<IntegrationContractDto> IntegrationContracts { get; private set; }
    }
}