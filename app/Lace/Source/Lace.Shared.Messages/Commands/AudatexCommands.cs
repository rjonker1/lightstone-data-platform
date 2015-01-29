using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingAudatexExecution
    {
        public CommandDto Command { get; private set; }

        public StartingAudatexExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingAudatexExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingAudatexExecution
    {
        public CommandDto Command { get; private set; }

        public EndingAudatexExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingAudatexExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingAudatexDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingAudatexDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingAudatexDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingAudatexDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingAudatexDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingAudatexDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseAudatexSecurityFlag
    {
        public CommandDto Command { get; private set; }

        public RaiseAudatexSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseAudatexSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureAudatex
    {
        public CommandDto Command { get; private set; }

        public ConfigureAudatex(CommandDto command)
        {
            Command = command;
        }

        public ConfigureAudatex()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformAudatexResponse
    {
        public CommandDto Command { get; private set; }

        public TransformAudatexResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformAudatexResponse()
        {
        }
    }
}
