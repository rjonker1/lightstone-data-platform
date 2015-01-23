using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class IvidTitleHolderExcutionHasStarted : DataProviderCommand
    {
        public IvidTitleHolderExcutionHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderExcutionHasEnded : DataProviderCommand
    {
        public IvidTitleHolderExcutionHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }


    [Serializable]
    [DataContract]
    public class IvidTitleHolderDataSourceCallHasStarted : DataProviderCommand
    {
        public IvidTitleHolderDataSourceCallHasStarted(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderDataSourceCallHasEnded : DataProviderCommand
    {
        public IvidTitleHolderDataSourceCallHasEnded(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
    
    [Serializable]
    [DataContract]
    public class IvidTitleHolderSecurityFlag : DataProviderCommand
    {
        public IvidTitleHolderSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderConfigured : DataProviderCommand
    {
        public IvidTitleHolderConfigured(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class IvidTitleHolderResponseTransformed : DataProviderCommand
    {
        public IvidTitleHolderResponseTransformed(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}
