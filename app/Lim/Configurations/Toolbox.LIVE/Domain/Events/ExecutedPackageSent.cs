using System;
using System.Linq;
using Lim.Domain.Events;
using Lim.Domain.Extensions;

namespace Toolbox.LIVE.Domain.Events
{
    public class ExecutedPackageSent : LimEvent
    {
        public ExecutedPackageSent(Guid packageId, Guid userId, Guid contractId, string accountNumber, Guid requestId, Type type, Guid correlationId,
            string eventType, int eventTypeId, bool hasData, string payload, string userName)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber.HasDigit() ? (string.Join("", accountNumber.Where(char.IsNumber)).TrimStart('0')).Check() : -1;
            ResponseDate = DateTime.UtcNow;
            RequestId = requestId;
            AggregateId = packageId;
            EventType = eventType;
            EventTypeId = eventTypeId;
            Type = type;
            TypeName = type.Name;
            AggregateNew = true;
            CorrelationId = correlationId;
            User = userId;
            HasData = hasData;
            Payload = payload.Fix().RemoveWhiteSpace().RemoveNewLine();
            //Payload = !string.IsNullOrEmpty(payload) ? Encoding.UTF8.GetBytes(payload) : null;
            Username = userName ?? "unavailable";
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public int AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
        public string Payload { get; private set; }
        public bool HasData { get; private set; }
        public string Username { get; private set; }
    }
}