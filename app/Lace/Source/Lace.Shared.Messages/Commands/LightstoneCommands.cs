using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingLightstoneExecution
    {
        public CommandDto Command { get; private set; }

        public StartingLightstoneExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingLightstoneExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingLightstoneExecution
    {
        public CommandDto Command { get; private set; }

        public EndingLightstoneExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingLightstoneExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingLightstoneDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingLightstoneDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingLightstoneDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingLightstoneDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingLightstoneDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingLightstoneDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseLightstoneSecurityFlag
    {
        public CommandDto Command { get; private set; }

        public RaiseLightstoneSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseLightstoneSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureLightstone
    {
        public CommandDto Command { get; private set; }

        public ConfigureLightstone(CommandDto command)
        {
            Command = command;
        }

        public ConfigureLightstone()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformLightstoneResponse
    {
        public CommandDto Command { get; private set; }

        public TransformLightstoneResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformLightstoneResponse()
        {
        }
    }
}
