using System;
using System.Collections.Generic;

namespace Lim.Schedule.Core.Commands
{
    public class AuditIntegrationCommand
    {
        public AuditIntegrationCommand(long clientId, long configurationId, DateTime date, short action, short type, string address, string suffix)
        {
            ClientId = clientId;
            ConfigurationId = configurationId;
            Date = date;
            Action = action;
            Type = type;
            Address = address;
            Suffix = suffix;
        }

        public void Successful()
        {
            WasSuccessful = true;
        }

        public void Failed()
        {
            WasSuccessful = false;
        }

        public void SetPayload(string payload, bool successful, DateTime transactionDate)
        {
            if (Payloads == null)
                Payloads = new List<AuditPayload>();

            Payloads.Add(new AuditPayload(payload, successful, transactionDate));
        }

        public long ClientId { get; private set; }
        public long ConfigurationId { get; private set; }
        public DateTime Date { get; private set; }
        public short Action { get; private set; }
        public short Type { get; private set; }
        public bool WasSuccessful { get; private set; }
        public string Address { get; private set; }
        public string Suffix { get; private set; }
        public IList<AuditPayload> Payloads { get; private set; }
    }

    public class AuditPayload
    {
        public AuditPayload(string payload, bool wasSuccessful, DateTime transactionDate)
        {
            Payload = payload;
            WasSuccessful = wasSuccessful;
            TransactionDate = wasSuccessful ? transactionDate : DateTime.MinValue;
        }

        public string Payload { get; private set; }
        public bool WasSuccessful { get; private set; }
        public DateTime TransactionDate { get; private set; }
    }
}