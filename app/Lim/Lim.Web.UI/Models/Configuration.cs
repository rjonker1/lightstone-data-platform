using System;

namespace Lim.Web.UI.Models
{
    public class Configuration
    {
        public readonly int ActionType;
        public readonly int IntegrationType;

        public Configuration()
        {
            
        }

        public Configuration(int actionType, int integrationType)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
        }

        public Configuration(long id, Guid key, int actionType, int integrationType, int frequency, Guid clientId, Guid contractId,string accountNumber, bool isActive)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
            Id = id;
            Key = key;
            FrequencyType = frequency;
            ClientId = clientId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            IsActive = isActive;
        }

        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public int FrequencyType { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
    }
}