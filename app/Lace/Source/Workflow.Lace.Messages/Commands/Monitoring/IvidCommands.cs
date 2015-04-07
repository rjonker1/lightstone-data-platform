﻿using System;
using DataPlatform.Shared.Enums;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    public class StartIvidExecution : DataProviderCommand
    {
        public StartIvidExecution(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class EndIvidExecution : DataProviderCommand
    {
        public EndIvidExecution(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class StartIvidDataSourceCall : DataProviderCommand
    {
        public StartIvidDataSourceCall(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class EndIvidDataSourceCall : DataProviderCommand
    {
        public EndIvidDataSourceCall(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class RaiseIvidSecurityFlag : DataProviderCommand
    {
        public RaiseIvidSecurityFlag(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class ConfigureIvid : DataProviderCommand
    {
        public ConfigureIvid(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }

    [Serializable]
    public class TransformIvidResponse : DataProviderCommand
    {
        public TransformIvidResponse(Guid id, DataProviderCommandSource dataProvider, string message,
            object payload,
            object metadata, DateTime date, Category category)
            : base(id, dataProvider, message, payload, metadata, date, category)
        {

        }
    }
}