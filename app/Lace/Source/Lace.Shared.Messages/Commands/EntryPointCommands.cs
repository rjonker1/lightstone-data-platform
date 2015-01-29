using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class EntryPointReceivingRequest
    {
        public CommandDto Command { get; private set; }

        public EntryPointReceivingRequest(CommandDto command)
        {
            Command = command;
        }

        public EntryPointReceivingRequest()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EntryPointProcessedAndReturningRequest
    {
      public CommandDto Command { get; private set; }

        public EntryPointProcessedAndReturningRequest(CommandDto command)
        {
            Command = command;
        }

        public EntryPointProcessedAndReturningRequest()
        {
        }
    }
}
