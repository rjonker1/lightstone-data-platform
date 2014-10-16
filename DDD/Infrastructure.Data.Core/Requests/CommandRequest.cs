using System;
using Raven.Imports.Newtonsoft.Json;

namespace LightstoneApp.Infrastructure.Data.Core.Requests
{
    public class CommandRequest
    {
        [JsonConstructor]
        private CommandRequest()
        {
        }

        public CommandRequest(String correlationId, Object rawCommand, String userAccount)
        {
            CreatedOn = DateTimeOffset.Now;
            CorrelationId = correlationId;
            Command = rawCommand;
            UserAccount = userAccount;
        }

        public String Id { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public String CorrelationId { get; private set; }

        public Object Command { get; private set; }

        public String UserAccount { get; private set; }
    }
}