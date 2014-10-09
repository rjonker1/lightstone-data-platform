using System;
using Raven.Imports.Newtonsoft.Json;

namespace LightstoneApp.Infrastructure.Data.Core.Requests
{
    public class CommandException
    {
        [JsonConstructor]
        private CommandException()
        {
        }

        public CommandException(String correlationId, Object rawCommand, String userAccount, Exception error)
        {
            CreatedOn = DateTimeOffset.Now;
            CorrelationId = correlationId;
            Command = rawCommand;
            UserAccount = userAccount;
            Error = error;
        }

        public String Id { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public String CorrelationId { get; private set; }

        public Object Command { get; private set; }

        public String UserAccount { get; private set; }

        public Exception Error { get; private set; }
    }
}