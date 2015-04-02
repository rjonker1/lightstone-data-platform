using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    public class StartIvidTitleHolderExecution : DataProviderCommand
    {
        public StartIvidTitleHolderExecution(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class EndIvidTitleHolderExecution : DataProviderCommand
    {
        public EndIvidTitleHolderExecution(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class StartIvidTitleHolderDataSourceCall : DataProviderCommand
    {
        public StartIvidTitleHolderDataSourceCall(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class EndIvidTitleHolderDataSourceCall : DataProviderCommand
    {
        public EndIvidTitleHolderDataSourceCall(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class RaiseIvidTitleHolderSecurityFlag : DataProviderCommand
    {
        public RaiseIvidTitleHolderSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class ConfigureIvidTitleHolder : DataProviderCommand
    {
        public ConfigureIvidTitleHolder(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class TransformIvidTitleHolderResponse : DataProviderCommand
    {
        public TransformIvidTitleHolderResponse(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}
