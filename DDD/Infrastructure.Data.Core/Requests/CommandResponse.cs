using System;
using Raven.Imports.Newtonsoft.Json;

namespace LightstoneApp.Infrastructure.Data.Core.Requests
{
    public class CommandResponse
    {
        [JsonConstructor]
        private CommandResponse()
        {
        }

        public CommandResponse(String correlationId, Object rawResponse, String userAccount)
        {
            CreatedOn = DateTimeOffset.Now;
            CorrelationId = correlationId;
            Response = rawResponse;
            UserAccount = userAccount;
        }

        public String Id { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public String CorrelationId { get; private set; }

        public Object Response { get; private set; }

        public String UserAccount { get; private set; }
    }
}