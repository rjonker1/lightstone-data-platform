using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartingIvidExecution
    {
        public CommandDto Command { get; private set; }

        public StartingIvidExecution(CommandDto command)
        {
            Command = command;
        }

        public StartingIvidExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingIvidExecution
    {
      public CommandDto Command { get; private set; }

        public EndingIvidExecution(CommandDto command)
        {
            Command = command;
        }

        public EndingIvidExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartingIvidDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartingIvidDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartingIvidDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndingIvidDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndingIvidDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndingIvidDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class RaiseIvidSecurityFlag
    {
       public CommandDto Command { get; private set; }

        public RaiseIvidSecurityFlag(CommandDto command)
        {
            Command = command;
        }

        public RaiseIvidSecurityFlag()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class ConfigureIvid
    {
        public CommandDto Command { get; private set; }

        public ConfigureIvid(CommandDto command)
        {
            Command = command;
        }

        public ConfigureIvid()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class TransformIvidResponse
    {
        public CommandDto Command { get; private set; }

        public TransformIvidResponse(CommandDto command)
        {
            Command = command;
        }

        public TransformIvidResponse()
        {
        }
    }
}
