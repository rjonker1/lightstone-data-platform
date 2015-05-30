using System;

namespace Lim.Domain.Dto
{
    public class ConfigurationDto
    {
        public ConfigurationDto()
        {

        }

        private ConfigurationDto(long id, Guid key, short actionType, short integrationType, short frequencyType, long clientId, bool isActive,
            string action, string frequency, string type)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
            Id = id;
            Key = key;
            FrequencyType = frequencyType;
            ClientId = clientId;
            IsActive = isActive;
            Action = action;
            Frequency = frequency;
            Type = type;
        }

        public static ConfigurationDto Existing(long id, Guid key, short actionType, short integrationType, short frequencyType, long clientId,
            bool isActive, string action, string frequency, string type)
        {
            return new ConfigurationDto(id, key, actionType, integrationType, frequencyType, clientId, isActive, action, frequency, type);
        }

        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public short FrequencyType { get; set; }
        public short ActionType { get; set; }
        public short IntegrationType { get; set; }
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; private set; }
        public string Frequency { get; private set; }
        public string Type { get; private set; }
    }
}