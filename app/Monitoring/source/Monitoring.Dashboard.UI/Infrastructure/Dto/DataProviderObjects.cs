﻿using System;
using DataPlatform.Shared.Enums;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto
{
    public class DataProviderViewDto
    {
        public readonly int SourceId;

        public DataProviderViewDto(int source)
        {
            SourceId = source;
        }
    }

    public class DataProviderResponseDto
    {
        public readonly Guid Id;
        public readonly string DataProvider;
        public readonly string Message;
        public readonly string Payload;
        public readonly DateTime Date;
        public readonly string Category;
        public readonly string Metadata;

        public DataProviderResponseDto(Guid id, string dataProvider, string message, string payLoad, DateTime date,
            string category, string metadata)
        {
            Id = id;
            DataProvider = dataProvider;
            Message = message;
            Payload = payLoad;
            Date = date;
            Category = category;
            Metadata = metadata;
        }
    }
}