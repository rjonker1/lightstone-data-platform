﻿using System.Collections.Generic;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;

namespace DataProvider.Infrastructure.Base.Handlers
{
    public interface IHandleDataProviderErrors
    {
        List<DataProviderDto> ErrorResponse { get; }
        void Handle(GetMonitoringCommand command);
    }
}