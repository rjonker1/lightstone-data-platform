using System;
using System.Collections.Generic;
using Lim.Enums;

namespace Lim.Web.UI.Models
{
    public class Configuration
    {
        public readonly int ActionType;
        public readonly int IntegrationType;

        public Configuration(int actionType, int integrationType)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
        }

        public Configuration(long id, Guid configurationKey, int actionType, int integrationType, int frequency, Guid clientId, Guid contractId,string accountNumber, bool isActive)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
            Id = id;
            ConfigurationKey = configurationKey;
            FrequencyType = frequency;
            ClientId = clientId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            IsActive = isActive;
        }

        public long Id { get; private set; }
        public Guid ConfigurationKey { get; private set; }
        public int FrequencyType { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
    }
}