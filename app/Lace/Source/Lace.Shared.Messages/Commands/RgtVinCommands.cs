using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingRgtVinExecution
    {
        public CommandDto Command { get; private set; }

        public StartingRgtVinExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingRgtVinExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingRgtVinExecution
    {
        public CommandDto Command { get; private set; }

        public EndingRgtVinExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingRgtVinExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingRgtVinDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingRgtVinDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingRgtVinDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingRgtVinDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingRgtVinDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingRgtVinDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseRgtVinSecurityFlag
    {
        public CommandDto Command { get; private set; }

        public RaiseRgtVinSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseRgtVinSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureRgtVin
    {
        public CommandDto Command { get; private set; }

        public ConfigureRgtVin(CommandDto command)
        {
            Command = command;
        }

        public ConfigureRgtVin()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformRgtVinResponse
    {
        public CommandDto Command { get; private set; }

        public TransformRgtVinResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformRgtVinResponse()
        {
        }
    }
}
