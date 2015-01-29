using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingIvidTitleHolderExecution
    {
        public CommandDto Command { get; private set; }

        public StartingIvidTitleHolderExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingIvidTitleHolderExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingIvidTitleHolderExecution
    {
        public CommandDto Command { get; private set; }

        public EndingIvidTitleHolderExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingIvidTitleHolderExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingIvidTitleHolderDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingIvidTitleHolderDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingIvidTitleHolderDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingIvidTitleHolderDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingIvidTitleHolderDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingIvidTitleHolderDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseIvidTitleHolderSecurityFlag
    {
        public CommandDto Command { get; private set; }

        public RaiseIvidTitleHolderSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseIvidTitleHolderSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureIvidTitleHolder
    {
        public CommandDto Command { get; private set; }

        public ConfigureIvidTitleHolder(CommandDto command)
        {
            Command = command;
        }

        public ConfigureIvidTitleHolder()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformIvidTitleHolderResponse
    {
        public CommandDto Command { get; private set; }

        public TransformIvidTitleHolderResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformIvidTitleHolderResponse()
        {
        }
    }
}
