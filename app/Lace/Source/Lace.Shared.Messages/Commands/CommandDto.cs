using System;
using DataPlatform.Shared.Enums;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class CommandDto
    {
        public Guid Id { get; private set; }
        public MonitoringSource Source { get; private set; }
        public string Payload { get; private set; }
        public DateTime Date { get; private set; }

        public CommandDto()
        {

        }

        public CommandDto(Guid id, MonitoringSource source, string payload, DateTime date)
        {
            Id = id;
            Source = source;
            Payload = payload;
            Date = date;
        }
    }
}
