﻿using System;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    public class DataProviderHasFaultCommand
    {
        public DataProviderCommandDto DataProviderCommand { get; private set; }

        public DataProviderHasFaultCommand(DataProviderCommandDto command)
        {
            DataProviderCommand = command;
        }

        //public Guid Id { get; private set; }
        // public DataProvider DataProvider { get; private set; }
        // public string Message { get; private set; }
        // public string Payload { get; private set; }
        // public DateTime Date { get; private set; }
        // public Category Category { get; private set; }
        // public string MetaData { get; private set; }
        // public bool IsJson { get; private set; }

        // public DataProviderHasFaultCommand()
        // {

        // }

        // public DataProviderHasFaultCommand(Guid id, DataProvider dataProvider, string message, string payload,
        //     string metadata,
        //     DateTime date, Category category, bool isJson)
        // {
        //     Id = id;
        //     DataProvider = dataProvider;
        //     Message = message;
        //     Payload = payload;
        //     Date = date;
        //     Category = category;
        //     MetaData = metadata;
        //     IsJson = isJson;
        // }
    }
}
