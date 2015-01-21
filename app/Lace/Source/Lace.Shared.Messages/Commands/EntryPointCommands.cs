﻿using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class EntryPointReceivedRequest : DataProviderCommand
    {
        public EntryPointReceivedRequest(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class EntryPointFinishedProcessingRequest : DataProviderCommand
    {
        public EntryPointFinishedProcessingRequest(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class EntryPointErrorOccurred : DataProviderCommand
    {
        public EntryPointErrorOccurred(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    

    //[Serializable]
    //[DataContract]
    //public class StartedCallingDataProviderSource : DataProviderCommand
    //{
    //    public StartedCallingDataProviderSource(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class EndCallingDataProviderSource : DataProviderCommand
    //{
    //    public EndCallingDataProviderSource(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class StartDataProvider : DataProviderCommand
    //{
    //    public StartDataProvider(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class EndDataProvider : DataProviderCommand
    //{
    //    public EndDataProvider(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class DataProviderHasFault : DataProviderCommand
    //{
    //    public DataProviderHasFault(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class DataProviderSecurityFlag : DataProviderCommand
    //{
    //    public DataProviderSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class DataProviderConfigured : DataProviderCommand
    //{
    //    public DataProviderConfigured(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}

    //[Serializable]
    //[DataContract]
    //public class DataProviderResponseTransformed : DataProviderCommand
    //{
    //    public DataProviderResponseTransformed(Guid id, DataProviderCommandSource dataProvider, string message,
    //        object payload,
    //        object metadata, DateTime date, Category category)
    //        : base(id, dataProvider, message, payload, metadata, date, category)
    //    {

    //    }
    //}


}