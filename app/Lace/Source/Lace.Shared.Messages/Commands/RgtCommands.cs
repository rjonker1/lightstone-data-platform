using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingRgtExecution
    {
        public CommandDto Command { get; private set; }

        public StartingRgtExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingRgtExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingRgtExecution
    {
        public CommandDto Command { get; private set; }

        public EndingRgtExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingRgtExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingRgtDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingRgtDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingRgtDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingRgtDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingRgtDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingRgtDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseRgtSecurityFlag
    {
        public CommandDto Command { get; private set; }

        public RaiseRgtSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseRgtSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureRgt
    {
        public CommandDto Command { get; private set; }

        public ConfigureRgt(CommandDto command)
        {
            Command = command;
        }

        public ConfigureRgt()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformRgtResponse
    {
        public CommandDto Command { get; private set; }

        public TransformRgtResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformRgtResponse()
        {
        }
    }
}
