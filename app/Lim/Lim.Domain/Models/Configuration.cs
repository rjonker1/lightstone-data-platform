using System;

namespace Lim.Domain.Models
{
    public class Configuration
    {
        public const string Select =
            @"select c.*,ft.Type Frequency, ac.Type Action, it.Type from Configuration c join FrequencyType ft on c.FrequencyType = ft.Id join ActionType ac on c.ActionType = ac.Id  join IntegrationType it on c.IntegrationType = it.Id";

        public Configuration()
        {

        }

        public Configuration(long id, Guid key, int actionType, int integrationType, int frequency, long clientId, bool isActive)
        {
            ActionType = actionType;
            IntegrationType = integrationType;
            Id = id;
            Key = key;
            FrequencyType = frequency;
            ClientId = clientId;
            IsActive = isActive;
        }

        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public int FrequencyType { get; set; }
        public int ActionType { get; set; }
        public int IntegrationType { get; set; }
        public long ClientId { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; private set; }
        public string Frequency { get; private set; }
        public string Type { get; private set; }
    }
}