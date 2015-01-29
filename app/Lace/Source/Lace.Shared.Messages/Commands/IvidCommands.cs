using System;
using System.Runtime.Serialization;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class StartIvidExecution
    {
        public CommandDto Command { get; private set; }

        public StartIvidExecution(CommandDto command)
        {
            Command = command;
        }

        public StartIvidExecution()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndIvidExecution
    {
      public CommandDto Command { get; private set; }

        public EndIvidExecution(CommandDto command)
        {
            Command = command;
        }

        public EndIvidExecution()
        {
        }

    }

    [Serializable]
    [DataContract]
    public class StartIvidDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public StartIvidDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public StartIvidDataSourceCall()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class EndIvidDataSourceCall
    {
        public CommandDto Command { get; private set; }

        public EndIvidDataSourceCall(CommandDto command)
        {
            Command = command;
        }

        public EndIvidDataSourceCall()
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
